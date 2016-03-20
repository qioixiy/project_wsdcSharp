using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Web.Script.Serialization;

namespace wsdcSharp
{
    public partial class FormLogin : Form
    {
        public class Personnel
        {
            public string ret { get; set; }
            public string reson { get; set; }
            public string user { get; set; }
        }
        public class LoginReturn
        {
            public string ret { get; set; }
            public string reson { get; set; }
            public string user { get; set; }
            public string uuid { get; set; }
            public string detail { get; set; }
        }

        FormMain mFormMain;
        
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            string[] ss = {
                              "http://localhost:8080/onlineOrder/servlet/ClientApi",
                              "http://47.88.50.45:8080/onlineOrder/servlet/ClientApi"
                          };
            comboBox_ServerAddr.Items.AddRange(ss);

            comboBox_ServerAddr.Text = ss[0];
        }

        private void button_login_Click(object sender, EventArgs e)
        {
        
            mFormMain = new FormMain(this);

            string serverUrl = comboBox_ServerAddr.Text;
            string userName = textBoxUserName.Text;
            string passWord = textBoxPassword.Text;
            string paramer = "id=login";
            paramer += "&user=" + userName;
            paramer += "&password=" + passWord;

            Session session = Session.GetSessionInstance();
            string retJson = session.HttpPost(serverUrl, paramer);

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            Personnel personnel = new Personnel();
            personnel.ret = "1";
            personnel.reson = "小白";
            //执行序列化
            string r1 = jsonSerializer.Serialize(personnel);
            //执行反序列化
            Personnel _Personnel = jsonSerializer.Deserialize<Personnel>(r1);

            //MessageBox.Show(retJson);
            try
            {
                LoginReturn _LoginReturn = jsonSerializer.Deserialize<LoginReturn>(retJson);
                if (_LoginReturn.ret.Equals("ok"))
                {
                    session.SetUserName(_LoginReturn.user);
                    session.SetUuid(_LoginReturn.uuid);
                    session.SetServerUrl(serverUrl);

                    labelStatus.Text = "";
                    this.Hide();
                    mFormMain.Show();
                }
                else
                {
                    labelStatus.Text = "登錄失敗，密碼或者用戶名不正確";
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 把json字符串转成对象
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="data">json字符串</param>
        public static T Deserialize<T>(string data)
        {
            JavaScriptSerializer json = new JavaScriptSerializer();
            return json.Deserialize<T>(data);
        }
    }
}
