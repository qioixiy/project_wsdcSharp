using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wsdcSharp
{
    class MySerialPort
    {
        static MySerialPort serialPort;
        public System.IO.Ports.SerialPort serialPortOrig;

        public List<byte> RecvBuffer;

        public MySerialPort()
        {
            serialPortOrig = new System.IO.Ports.SerialPort();
            serialPortOrig.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceived);
            RecvBuffer = new List<byte>();
        }
        public static MySerialPort Get()
        {
            if (serialPort == null)
            {
                serialPort = new MySerialPort();
            }
            return serialPort;
        }

        private bool handleRecvBuffer()
        {
            return true;
        }

        private void DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int i = serialPortOrig.ReadByte();
            RecvBuffer.Add((byte)i);

            if (RecvBuffer.Count > 3)
            {
                handleRecvBuffer();
            }
        }
    }
}
