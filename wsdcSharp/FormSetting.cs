using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wsdcSharp
{
    public partial class FormSetting : Form
    {
        private bool hex = false;
        public FormSetting()
        {
            InitializeComponent();
        }
        
        private void FormSetting_Load(object sender, EventArgs e)
        {
            comboBox_SerialPort.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            string default_sericalPort = "没有发现串口";
            string[] serialPortList = System.IO.Ports.SerialPort.GetPortNames();
            if (0 != serialPortList.Count())
            {
                default_sericalPort = System.IO.Ports.SerialPort.GetPortNames()[0];
            }
            else
            {
                MessageBox.Show("没有发现串口");
            }
            comboBox_SerialPort.Text = default_sericalPort;
            string[] sBandRate = { "115200", "9600" };
            comboBox_BandRate.Items.AddRange(sBandRate);
            comboBox_BandRate.Text = sBandRate[0];

            if (MySerialPort.Get().serialPortOrig.IsOpen)
            {
                button_openSerialPort.Text = "关闭";
            }
            else
            {
                button_openSerialPort.Text = "打开";
            }
        }
        public string ToHexString(byte[] bytes)
        {
            string byteStr = string.Empty;
            if (bytes != null || bytes.Length > 0)
            {
                foreach (var item in bytes)
                {
                    byteStr += string.Format("{0:X2}", item);
                }
            }
            return byteStr;
        }
        public string ByteToHexString(byte b)
        {
            string byteStr = string.Format("{0:X2}", b);
            return byteStr;
        }

        private void serialPort1_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
        {
            MessageBox.Show("serialPort error");
        }

        private void button_send_test_Click(object sender, EventArgs e)
        {
            try
            {
                MySerialPort.Get().serialPortOrig.Write(textBox_in.Text);

                //MySerialPort.Get().SendFrameTest();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button_openSerialPort_Click(object sender, EventArgs e)
        {
            try
            {
                bool status = true;
                if (button_openSerialPort.Text.Equals("打开"))
                {
                    button_openSerialPort.Text = "关闭";
                    status = true;
                }
                else
                {
                    status = false;
                    button_openSerialPort.Text = "打开";
                }
                if (status == true)
                {
                    if (!MySerialPort.Get().serialPortOrig.IsOpen)
                    {
                        MySerialPort.Get().serialPortOrig.PortName = comboBox_SerialPort.Text;
                        MySerialPort.Get().serialPortOrig.BaudRate = int.Parse(comboBox_BandRate.Text);
                        MySerialPort.Get().serialPortOrig.Open();

                    }
                }
                else
                {
                    MySerialPort.Get().serialPortOrig.Close();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void comboBox_BandRate_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox_SerialPort_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void checkBox_hex_CheckStateChanged(object sender, EventArgs e)
        {
            hex = !hex;
        }

        private void FormSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            ;
        }

        private void textBox_in_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox_hex_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox_RecvData_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_RecvData_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                //读取串口中一个字节的数据  
                this.textBox_RecvData.Invoke(
                    //在拥有此控件的基础窗口句柄的线程上执行委托Invoke(Delegate)  
                    //即在textBox_RecvData控件的父窗口form中执行委托.  
                 new MethodInvoker(
                    /*表示一个委托，该委托可执行托管代码中声明为 void 且不接受任何参数的任何方法
                     * 在对控件的 Invoke 方法进行调用时或需要一个简单委托又不想自己定义时可以使用该委托。*/
                 delegate
                 {
                     /*匿名方法,C#2.0的新功能，这是一种允许程序员将一段完整代码区块当成参数传递的程序代码编写技术，
                      * 通过此种方法可  以直接使用委托来设计事件响应程序以下就是你要在主线程上实现的功能但是有一点要注意，
                      * 这里不适宜处理过多的方法，因为C#消息机制是消息流水线响应机制，
                      * 如果这里在主线程上处理语句的时间过长会导致主UI线程阻塞，停止响应或响应不顺畅,
                      * 这时你的主form界面会延迟或卡死      */
                     string s = "";
                     for (int l = 0; l < MySerialPort.Get().RecvBuffer.Count; l++)
                     {
                         if (hex)
                         {
                            s += ByteToHexString((byte)MySerialPort.Get().RecvBuffer[l]);
                         }
                         else
                         {
                             s += ((byte)MySerialPort.Get().RecvBuffer[l]).ToString();
                         }
                         s += " ";
                     }

                     this.textBox_RecvData.Text = s;
                 }
                 )
                 );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
