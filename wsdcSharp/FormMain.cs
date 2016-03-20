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
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_flush_Click(object sender, EventArgs e)
        {
            UpdateOrderList();
        }
    }
}
