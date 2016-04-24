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
    public partial class FormManager : Form
    {
        public FormManager()
        {
            InitializeComponent();
        }

        private void FormManager_Load(object sender, EventArgs e)
        {

        }

        private void button_setcanpanID_Click(object sender, EventArgs e)
        {
            byte[] bs = System.Text.Encoding.Default.GetBytes(textBox_canpanID.Text);

            Protocal.Frame frame = Protocal.MakeFrame(
                Protocal.DeviceAddr_PC,
                Protocal.FuncID_WriteData,
                Protocal.DataDestAddr_CanPan,
                bs);

            MySerialPort.Get().SendFrame(frame);
        }
        private void button_setxiaofeikaID_Click(object sender, EventArgs e)
        {
            string ss = textBox_xiaofeikaID.Text;
            string s = ss.Replace(" ","");
            byte[] bs1 = utils.byteReverse(System.BitConverter.GetBytes(Int16.Parse(s.Substring(0, 4))));
            byte[] bs2 = utils.byteReverse(System.BitConverter.GetBytes(Int16.Parse(s.Substring(4, 4))));
            //byte[] bs3 = new byte[1] {Byte.Parse(s.Substring(8, 4))};
            byte[] bs3 = utils.byteReverse(System.BitConverter.GetBytes(Int16.Parse(s.Substring(8, 4))));
            byte[] bs = bs1.Concat(bs2).Concat(bs3).ToArray();

            Protocal.Frame frame = Protocal.MakeFrame(
                Protocal.DeviceAddr_PC,
                Protocal.FuncID_WriteData,
                Protocal.DataDestAddr_YongHuID,
                bs);

            MySerialPort.Get().SendFrame(frame);
        }

        private void button_chongzhi_Click(object sender, EventArgs e)
        {
            int totol = int.Parse(textBox_chongzhi.Text);
            byte[] totol_bs = System.BitConverter.GetBytes(totol);
            byte[] bs = utils.byteReverse(totol_bs);

            Protocal.Frame frame = Protocal.MakeFrame(
                Protocal.DeviceAddr_PC,
                Protocal.FuncID_WriteData,
                Protocal.DataDestAddr_YongHuYuE,
                bs);

            MySerialPort.Get().SendFrame(frame);
        }
    }
}
