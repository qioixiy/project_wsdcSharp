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
        class CanPanIDAndPrice
        {
            public string uuid { get; set; }
            public string ret { get; set; }
            public string id { get; set; }
            public string xuehao { get; set; }
            public string repeat { get; set; }
            public string price { get; set; }
            public string dish_id { get; set; }
        }
        CanPanIDAndPrice mCanPanIDAndPrice;
        class Order
        {
            public string id { get; set; }
            public string timestamp { get; set; }
            public string userid { get; set; }
            public string username { get; set; }
            public string xuehao { get; set; }
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
        string mCurCardStatusStr;

        public FormMain(Form _retForm)
        {
            retForm = _retForm;
            InitializeComponent();
            mCurCardStatusStr = "CARD_NONE";
        }

        int BindCanPan(string orderID, string canpanID)
        {
            Session session = Session.GetSessionInstance();
            string ret = session.HttpPost(session.SetServerUrl(), "id=orderBindCanPan"
                + "&uuid=" + session.GetUuid()
                + "&orderID=" + orderID
                + "&canpanID=" + canpanID);
            //MessageBox.Show(ret);

            return 0;
        }
        int UpdateOrderList()
        {
            Session session = Session.GetSessionInstance();
            string ret = session.HttpPost(session.SetServerUrl(), "id=orderlist"
                + "&uuid=" + session.GetUuid());
            //MessageBox.Show(ret);

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            mOrderList = jsonSerializer.Deserialize<OrderList>(ret);
            
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
            listView_orderList.Columns.Add("xuehao", "学号");
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
            listView_orderList.Columns["xuehao"].Width = 100;
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
                item.SubItems.Add(mOrderList.orderlist[i].xuehao);
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
            MySerialPort.SetUiMode(MySerialPort.UiMode.Setting);
            new FormManager().ShowDialog();
            MySerialPort.SetUiMode(MySerialPort.UiMode.Normal);
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
            // 需要先放上餐盘
            if (MySerialPort.mCardStatus != MySerialPort.CardStatus.CARD_CANPAN)
            {
                MessageBox.Show("需要先放上餐盘");
                return;
            }

            if (listView_orderList.FocusedItem != null)
            {
                string id = listView_orderList.FocusedItem.SubItems[0].Text;
                //MessageBox.Show("将要处理订单id:" + id);
                BindCanPan(id, MySerialPort.CardId);

                UpdateOrderList();
            }
            else {
                MessageBox.Show("选择你将要处理的订单");
            }
        }
        string GetCanPanIdAndTotalPriceWithXuehao(string xuehao)
        {
            Session session = Session.GetSessionInstance();
            string ret = session.HttpPost(session.SetServerUrl(), "id=GetCanPanIdAndTotalPrice"
                + "&uuid=" + session.GetUuid()
                + "&userID=" + xuehao);
            //MessageBox.Show(ret);

            return ret;
        }
        int HandleFrame(byte[] bs)
        {
            List<byte> lbs = new List<byte>();
            string s = "\r\nframe:";
            foreach (byte b in bs) {
                string ss = string.Format("0x{0:x2} ", b);
                s += ss;
                lbs.Add(b);
            }
            s += "\r\n";
            textBox_process.AppendText(s);

            Protocal.Frame f = Protocal.ListByteToFrame(lbs);

            textBox_process.AppendText(Protocal.FrameToString(f));

            if (f.DeviceAddr == Protocal.DeviceAddr_PC)
            { 
                // 接收到MCU相应数据帧
                if (f.FuncID == Protocal.FuncID_WriteData)
                {
                    textBox_process.AppendText("MCU响应PC写数据\r\n");
                    if (f.DataField.DataDestAddr == Protocal.DataDestAddr_YongHuID)
                    {
                        textBox_process.AppendText("设置用户ID成功\r\n");
                    }
                    else if (f.DataField.DataDestAddr == Protocal.DataDestAddr_CanPan)
                    {
                        textBox_process.AppendText("设置餐盘ID成功\r\n");
                    }
                    else if (f.DataField.DataDestAddr == Protocal.DataDestAddr_YongHuYuE)
                    {
                        textBox_process.AppendText("充值成功\r\n");
                    }
                }
            }
            else if (f.DeviceAddr == Protocal.DeviceAddr_MCU)
            {
                // MCU上报写数据
                textBox_process.AppendText("MCU上报写数据\r\n");
                if (f.FuncID == Protocal.FuncID_WriteData) {
                    if (f.DataField.DataDestAddr == Protocal.DataDestAddr_YongHuID)
                    {
                        // 数据值类型为用户
                        textBox_process.AppendText("数据值类型为用户\r\n");
                        if (f.DataField.Size == 2)
                        {
                            // 发现空卡
                            textBox_process.AppendText("发现空卡\r\n");
                            // 响应 MCU
                            byte[] bss = { Protocal.Response_OK };
                            Protocal.Frame frame = Protocal.MakeFrame(
                                f.DeviceAddr,
                                f.FuncID,
                                f.DataField.DataDestAddr,
                                bss);
                            MySerialPort.Get().SendFrame(frame);
                            MySerialPort.SetCardStatus(MySerialPort.CardStatus.CARD_KONGKA);
                            MySerialPort.CardId = "";
                        }
                        else if (f.DataField.Size > 2)
                        {
                            // 发现消费卡
                            if (f.DataField.DataDestAddr == Protocal.DataDestAddr_YongHuID)
                            {
                                textBox_process.AppendText("发现消费卡\r\n");
                                // 响应 MCU
                                byte[] bss = { Protocal.Response_OK };
                                Protocal.Frame frame = Protocal.MakeFrame(
                                    f.DeviceAddr,
                                    f.FuncID,
                                    f.DataField.DataDestAddr,
                                    bss);
                                MySerialPort.Get().SendFrame(frame);
                                MySerialPort.SetCardStatus(MySerialPort.CardStatus.CARD_XIAOFEIKA);
                                byte[] Bs = f.DataField.Data;
                                byte[] b1 = new byte[2]; b1[1] = Bs[0]; b1[0] = Bs[1];
                                byte[] b2 = new byte[2]; b2[1] = Bs[2]; b2[0] = Bs[3];
                                byte[] b3 = new byte[2]; b3[1] = Bs[4]; b3[0] = Bs[5];
                                UInt16 i1 = System.BitConverter.ToUInt16(b1, 0);
                                UInt16 i2 = System.BitConverter.ToUInt16(b2, 0);
                                UInt16 i3 = System.BitConverter.ToUInt16(b3, 0);

                                string user_id = string.Format("{0:D4} {1:D4} {2:D4}", i1, i2, i3);
                                MySerialPort.CardId = user_id;
                                textBox_process.AppendText("消费卡ID:" + user_id + "\r\n");

                                if (MySerialPort.mUiMode == MySerialPort.UiMode.Normal)
                                {
                                    // 普通模式， 向MCU发送餐盘ID和套餐价格
                                    //刷卡消费
                                    textBox_process.AppendText("刷卡消费模式\r\n");

                                    string canpanID = "DF59";
                                    string price_total = "20";
                                    string xuehao = user_id.Replace(" ", "");
                                    if (true)
                                    {
                                        string ret = GetCanPanIdAndTotalPriceWithXuehao(xuehao);
                                        JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                                        mCanPanIDAndPrice = jsonSerializer.Deserialize<CanPanIDAndPrice>(ret);

                                        canpanID = mCanPanIDAndPrice.dish_id;
                                        Console.WriteLine("餐盘ID：" + canpanID);
                                        Console.WriteLine("repeat:" + mCanPanIDAndPrice.repeat);
                                        Console.WriteLine("price：" + mCanPanIDAndPrice.price);
                                        price_total = (Int32.Parse(mCanPanIDAndPrice.repeat)
                                                    * Int32.Parse(mCanPanIDAndPrice.price)).ToString();

                                        textBox_process.AppendText("餐盘ID:" + canpanID + "\r\n");
                                        textBox_process.AppendText("价格:" + price_total + "\r\n");
                                    } else {
                                        for (int i = mOrderList.orderlist.Count - 1; i >= 0; i--)
                                        {
                                            if (xuehao == mOrderList.orderlist[i].xuehao)
                                            {
                                                canpanID = mOrderList.orderlist[i].dishid;
                                                price_total = (Int32.Parse(mOrderList.orderlist[i].menuprice)
                                                            * Int32.Parse(mOrderList.orderlist[i].repeat)).ToString();
                                                break;
                                            }
                                        }
                                    }
                                    SendCanPanIDFrame(canpanID);
                                    SendTaoCanPriceFrame(price_total);
                                    
                                    UpdateOrderList();
                                }
                                else if (MySerialPort.mUiMode == MySerialPort.UiMode.Setting)
                                {
                                    Console.WriteLine("配置模式");
                                }
                            }
                        }
                    }
                    else if (f.DataField.DataDestAddr == Protocal.DataDestAddr_CanPan)
                    {
                        // 数据值类型为餐盘
                        textBox_process.AppendText("数据值类型为餐盘\r\n");
                        // 响应 MCU
                        byte[] bss = { Protocal.Response_OK };
                        Protocal.Frame frame = Protocal.MakeFrame(
                            f.DeviceAddr,
                            f.FuncID,
                            f.DataField.DataDestAddr,
                            bss);
                        MySerialPort.Get().SendFrame(frame);

                        MySerialPort.SetCardStatus(MySerialPort.CardStatus.CARD_CANPAN);
                        string canpan_id = Encoding.UTF8.GetString(f.DataField.Data);
                        MySerialPort.CardId = canpan_id;

                        textBox_process.AppendText("餐盘ID:" + canpan_id + "\r\n");
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

        // 消费刷卡，餐盘卡号下发报文
        void SendCanPanIDFrame(string canpan_id)
        {
            byte[] bs = System.Text.Encoding.Default.GetBytes(canpan_id);

            Protocal.Frame frame = Protocal.MakeFrame(
                Protocal.DeviceAddr_PC,
                Protocal.FuncID_WriteData,
                Protocal.DataDestAddr_CanPan,
                bs);

            MySerialPort.Get().SendFrame(frame);
        }
        // 消费刷卡，餐盘价格下发报文
        void SendTaoCanPriceFrame(string price)
        {
            int totol = int.Parse(price);
            byte[] totol_bs = System.BitConverter.GetBytes(totol);
            byte[] bs = utils.byteReverse(totol_bs);

            Protocal.Frame frame = Protocal.MakeFrame(
                Protocal.DeviceAddr_PC,
                Protocal.FuncID_WriteData,
                Protocal.DataDestAddr_TaoCanJinE,
                bs);

            MySerialPort.Get().SendFrame(frame);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine(MySerialPort.Get().frames.Count);
            if (MySerialPort.Get().frames.Count > 0)
            {
                Console.WriteLine("get frame");
                byte[] lb = MySerialPort.Get().frames[0];
                MySerialPort.Get().frames.RemoveAt(0);
                HandleFrame(lb);
            }
            string mCardStatusStr = MySerialPort.mCardStatus.ToString();
            if (!mCurCardStatusStr.Equals(mCardStatusStr)) {
                Console.WriteLine("mCurCardStatusStr:" + mCurCardStatusStr + ",mCardStatusStr:" + mCardStatusStr);
                mCurCardStatusStr = mCardStatusStr;
            }
        }

        private void textBox_process_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox_process_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void textBox_process_DoubleClick(object sender, EventArgs e)
        {
            textBox_process.Text = "";
        }
    }
}
