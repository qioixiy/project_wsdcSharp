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
            byte[] bs = System.Text.Encoding.Default.GetBytes(textBox_xiaofeikaID.Text);

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
            byte[] bs = new byte[4];
            int index = 0;
            for (; index < 4; index++)
            {
                bs[index] = totol_bs[3 - index];
            }

            Protocal.Frame frame = Protocal.MakeFrame(
                Protocal.DeviceAddr_PC,
                Protocal.FuncID_WriteData,
                Protocal.DataDestAddr_YongHuYuE,
                bs);

            MySerialPort.Get().SendFrame(frame);
        }
    }
}
