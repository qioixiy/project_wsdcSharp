using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace wsdcSharp
{
    public partial class FormMain : Form
    {
        class Order
        {
            public string id { get; set; }
            public string timestamp { get; set; }
            public string userid { get; set; }
            public string username { get; set; }
            public string menuid { get; set; }
            public string menuname { get; set; }
            public string menuprice { get; set; }
            public string repeat { get; set; }
            public string spec { get; set; }
            public string dishid { get; set; }
        }
        class OrderList
        {
            public string uuid { get; set; }
            public List<Order> orderlist { get; set; }
        }
        Form retForm;
        OrderList mOrderList;

        public FormMain(Form _retForm)
        {
            retForm = _retForm;
            InitializeComponent();
        }

        int UpdateOrderList()
        {
            Session session = Session.GetSessionInstance();
            string ret = session.HttpPost(session.SetServerUrl(), "id=orderlist"
                + "&uuid=" + session.GetUuid());
            //MessageBox.Show(ret);

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            mOrderList = jsonSerializer.Deserialize<OrderList>(ret);
            //MessageBox.Show(ret);
            
            listView_orderList.Clear();

            listView_orderList.GridLines = true;//表格是否显示网格线
            listView_orderList.FullRowSelect = true;//是否选中整行
            listView_orderList.View = View.Details;//设置显示方式
            listView_orderList.Scrollable = true;//是否自动显示滚动条
            listView_orderList.MultiSelect = true;//是否可以选择多行

            //添加表头（列）
            listView_orderList.Columns.Add("id", "序号");
            listView_orderList.Columns.Add("timestamp", "下单时间");
            listView_orderList.Columns.Add("userid", "用户ID");
            listView_orderList.Columns.Add("username", "用户名");
            listView_orderList.Columns.Add("menuid", "菜单ID");
            listView_orderList.Columns.Add("menuname", "菜单名");
            listView_orderList.Columns.Add("menuprice", "价格");
            listView_orderList.Columns.Add("repeat", "数量");
            listView_orderList.Columns.Add("dishid", "餐盘ID");
            listView_orderList.Columns.Add("spec", "附加说明");

            listView_orderList.Columns["id"].Width = -2;
            listView_orderList.Columns["timestamp"].Width = 150;
            listView_orderList.Columns["userid"].Width = -2;
            listView_orderList.Columns["username"].Width = -2;
            listView_orderList.Columns["menuid"].Width = -2;
            listView_orderList.Columns["menuname"].Width = 100;
            listView_orderList.Columns["menuprice"].Width = 80;
            listView_orderList.Columns["repeat"].Width = -2;
            listView_orderList.Columns["dishid"].Width = 80;
            listView_orderList.Columns["spec"].Width = -2;//-1:根据内容设置宽度, -2:根据标题设置宽度

            //添加表格内容
            for (int i = mOrderList.orderlist.Count - 1; i >= 0; i--)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Clear();

                item.SubItems[0].Text = mOrderList.orderlist[i].id;
                item.SubItems.Add(mOrderList.orderlist[i].timestamp);
                item.SubItems.Add(mOrderList.orderlist[i].userid);
                item.SubItems.Add(mOrderList.orderlist[i].username);
                item.SubItems.Add(mOrderList.orderlist[i].menuid);
                item.SubItems.Add(mOrderList.orderlist[i].menuname);
                item.SubItems.Add(mOrderList.orderlist[i].menuprice);
                item.SubItems.Add(mOrderList.orderlist[i].repeat);
                item.SubItems.Add(mOrderList.orderlist[i].dishid);
                item.SubItems.Add(mOrderList.orderlist[i].spec);

                listView_orderList.Items.Add(item);
            }

            return 0;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            UpdateOrderList();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            retForm.Show();
        }

        private void button_manager_Click(object sender, EventArgs e)
        {
            new FormManager().ShowDialog();
        }

        private void button_setting_Click(object sender, EventArgs e)
        {
            new FormSetting().ShowDialog();
            if (!MySerialPort.Get().serialPortOrig.IsOpen)
            {
                serial_connect_status.Text = "设备未连接";
                btn_handle_order.Enabled = false;
                button_manager.Enabled = false;
            }
            else {
                serial_connect_status.Text = "设备已连接";
                btn_handle_order.Enabled = true;
                button_manager.Enabled = true;
                textBox_process.AppendText("连接设备成功" + "\n");
            }
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_flush_Click(object sender, EventArgs e)
        {
            UpdateOrderList();
        }

        private void btn_handle_order_Click(object sender, EventArgs e)
        {
            byte[] bytes = { 0x01, 0x02 };
            Protocal.Frame frame = Protocal.MakeFrame(
                Protocal.DeviceAddr_MCU,
                Protocal.FuncID_ReadData,
                Protocal.DataDestAddr_CanPan,
                bytes);

            List<byte> listByte = Protocal.FrameToListByte(frame);

            int ret = Protocal.ParserFrame(listByte);

            if (listView_orderList.FocusedItem != null)
            {
                string s1 = listView_orderList.FocusedItem.SubItems[0].Text;
                MessageBox.Show("将要处理订单:" + s1);
            }
            else {
                MessageBox.Show("选择你将要处理的订单");
            }
        }

        int HandleFrame(byte[] bs)
        {
            List<byte> lbs = new List<byte>();
            string s = "frame:";
            foreach (byte b in bs) {
                string ss = string.Format("0x{0:x2} ", b);
                s += ss;
                lbs.Add(b);
            }
            s += "\n";
            textBox_process.AppendText(s);

            Protocal.Frame f = Protocal.ListByteToFrame(lbs);

            textBox_process.AppendText(Protocal.FrameToString(f));

            if (f.DeviceAddr == Protocal.DeviceAddr_PC)
            { 
                // 接收到MCU相应数据帧
            }
            else if (f.DeviceAddr == Protocal.DeviceAddr_MCU)
            {
                textBox_process.AppendText("MCU上报写数据\n");
                // MCU上报写数据
                if (f.FuncID == Protocal.FuncID_WriteData) {
                    // 数据值类型为用户
                    textBox_process.AppendText("数据值类型为用户\n");
                    if (f.DataField.DataDestAddr == Protocal.DataDestAddr_YongHuID)
                    {
                        // 发现空卡
                        if (f.DataField.Data.Length == 0)
                        {
                            textBox_process.AppendText("发现空卡\n");
                            // 响应 MCU
                            byte[] bss = { Protocal.Response_OK};
                            Protocal.Frame frame = Protocal.MakeFrame(
                                f.DeviceAddr,
                                f.FuncID,
                                f.DataField.DataDestAddr,
                                bss);

                            MySerialPort.Get().SendFrame(frame);
                        }
                    }
                    else if (f.DataField.Data[1] == Protocal.DataDestAddr_CanPan)
                    {
                        ;
                    }
                }
                // MCU读数据
                else if (f.FuncID == Protocal.FuncID_ReadData)
                {
                    ;
                }
            }

            return 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (MySerialPort.Get().frames.Count > 0)
            {
                Console.WriteLine("get frame");
                byte[] lb = MySerialPort.Get().frames[0];
                HandleFrame(lb);

                MySerialPort.Get().frames.RemoveAt(0);
            }
        }
    }
}
