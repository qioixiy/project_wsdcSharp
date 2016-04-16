using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wsdcSharp
{
    class MySerialPort
    {
        static MySerialPort serialPort;
        public System.IO.Ports.SerialPort serialPortOrig;

        public List<Byte> RecvBuffer;
        public List<Byte[]> frames;

        public enum UiMode
        { 
            Normal,
            Setting,
        };
        public enum CardStatus
        {
            CARD_NONE,
            CARD_KONGKA,
            CARD_CANPAN,
            CARD_XIAOFEIKA,
        };
        public static UiMode mUiMode;
        public static CardStatus mCardStatus;
        public static string CardId = "0000";

        public static void SetUiMode(UiMode mode)
        {
            mUiMode = mode;
            Console.WriteLine("UiMode:" + mode.ToString());
        }
        public static void SetCardStatus(CardStatus cs)
        {
            mCardStatus = cs;
            Console.WriteLine("CardStatus:" + cs.ToString());
        }
        public MySerialPort()
        {
            serialPortOrig = new System.IO.Ports.SerialPort();
            serialPortOrig.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceived);
            RecvBuffer = new List<Byte>();
            frames = new List<Byte[]>();
            SetCardStatus(CardStatus.CARD_NONE);
            SetUiMode(UiMode.Normal);
        }
        public static MySerialPort Get()
        {
            if (serialPort == null)
            {
                serialPort = new MySerialPort();
            }
            return serialPort;
        }

        private int handleRecvBuffer()
        {
            return Protocal.ParserFrame(RecvBuffer);
        }

        private void DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            // 识别餐盘ID后，下位机设备主动向上位机写
            Byte[] frame1 = new Byte[] { 0x02, 0x94, 0x0a, 0x14, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0xff };
            // 上位机响应报文
            Byte[] frame1_resp = new Byte[] { 0x02, 0x94, 0x03, 0x14, 0xff, 0xff };

            // 刷卡，识别用户ID后，下位机设备主动向上位机写用户ID, 向上位机读取餐盘ID
            Byte[] frame2 = new Byte[] { 0x02, 0x68, 0x02, 0x14, 0xff };
            Byte[] frame2_resp = new Byte[] { 0x02, 0x68, 0x02, 0x14, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0xff };

            //int i = serialPortOrig.ReadByte();
            //Console.WriteLine("0x{0:x2}", i);
            //Console.WriteLine(temp);
            Byte[] buf = new Byte[serialPortOrig.ReadBufferSize];
            int size = serialPortOrig.Read(buf, 0, serialPortOrig.ReadBufferSize);

            Byte[] buf1 = new Byte[size];
            for (int index = 0; index < size; index++) {
                buf1[index] = buf[index];
            }

            RecvBuffer.AddRange(buf1);
            Console.Write("DataReceived:size[" + size + "]");
            utils.ConsoleWriteHex(buf1, size);
            //utils.ConsoleWriteHex(RecvBuffer);

            if (RecvBuffer.Count >= 5)
            {
                Console.WriteLine("handleRecvBuffer");
                int ret = handleRecvBuffer();
                if (ret > 0)
                {
                    // handle
                    Byte[] frame = new Byte[ret];

                    for (int index = 0; index < ret; index++)
                    {
                        frame[index] = RecvBuffer[index];
                    }
                    frames.Add(frame);
                    Console.WriteLine("find frame");
                    //MessageBox.Show("find frame");
                    RecvBuffer.RemoveRange(0, ret);
                }
                else if (RecvBuffer.Count > 50)
               {
                   RecvBuffer.RemoveRange(0, RecvBuffer.Count);
                   Console.WriteLine("invalid data, clear RecvBuffer");
                }
            }
        }
        public bool SendFrame(Protocal.Frame frame)
        {
            List<Byte> listByte = Protocal.FrameToListByte(frame);
            Byte[] bytes = Protocal.ListByteToBytes(listByte);
            MySerialPort.Get().serialPortOrig.Write(bytes, 0, bytes.Length);
            return true;
        }

        public bool SendFrameTest()
        {
            Byte[] bs = { System.Convert.ToByte('d'), System.Convert.ToByte('e') };
            Protocal.Frame frame = Protocal.MakeFrame(
                System.Convert.ToByte('a'),
                System.Convert.ToByte('b'),
                System.Convert.ToByte('c'), bs);
            
            return SendFrame(frame);
        }
    }
}
