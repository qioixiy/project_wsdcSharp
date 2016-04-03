using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wsdcSharp
{
    class Protocal
    {
        // 设备地址
        public const byte DeviceAddr_PC = 0x01;
        public const byte DeviceAddr_MCU = 0x02;
        //功能码
        public const byte FuncID_ReadData = 0x68;
        public const byte FuncID_WriteData = 0x94;
        //数据值
        public const byte DataDestAddr_CanPan = 0x14;
        public const byte DataDestAddr_TaoCanJinE = 0x15;
        public const byte DataDestAddr_YongHuID = 0x04;
        public const byte DataDestAddr_YongHuYuE = 0x05;
        //响应结果
        public const byte Response_OK = 0xff;
        public const byte Response_Fail = 0x00;
        public struct Frame
        {
            public byte DeviceAddr;
            public byte FuncID;

            public struct _DataField
            {
                public byte Size;
                public byte DataDestAddr;
                public byte[] Data;
                public int GetSize()
                {
                    return 1 + 1 + Data.Length;
                }
            };
            public _DataField DataField;

            public byte CheckSum;
            //public byte CRC1;
            //public byte CRC2;

            public int GetSize()
            {
                int size = 1 + 1 + DataField.GetSize() + 1;
                return size;
            }
        };

        public static Frame MakeFrame(byte DeviceAddr, byte FuncID, byte DataDestAddr, byte[] Data)
        {
            Frame frame = new Frame();

            frame.DeviceAddr = DeviceAddr;
            frame.FuncID = FuncID;

            frame.DataField.Size = (byte)(2 + Data.Length);
            frame.DataField.DataDestAddr = DataDestAddr;
            frame.DataField.Data = Data;

            frame.CheckSum = (byte)(frame.DeviceAddr + frame.FuncID
                + frame.DataField.Size + frame.DataField.DataDestAddr);
            for (int i = 0; i < frame.DataField.Data.Length; i++)
            {
                frame.CheckSum += frame.DataField.Data[i];
            }

            return frame;
        }

        public static int ParserFrame(List<byte> bytes)
        {
            int ret = 0;

            if (bytes.Count >= 5)
            {
                byte size = (byte)(2 + bytes[2]);
                if (size <= bytes.Count - 1)//check sum
                {
                    Frame frame = ListByteToFrame(bytes);
                    ret = frame.GetSize();
                }
            }
            else
            {
                ;
            }

            return ret;
        }

        public static List<byte> FrameToListByte(Frame frame)
        {
            List<byte> bytes = new List<byte>();

            bytes.Add(frame.DeviceAddr);
            bytes.Add(frame.FuncID);

            bytes.Add(frame.DataField.Size);
            bytes.Add(frame.DataField.DataDestAddr);
            bytes.AddRange(frame.DataField.Data);

            bytes.Add(frame.CheckSum);

            return bytes;
        }

        public static Frame ListByteToFrame(List<byte> bytes)
        {
            Frame frame = new Frame();
            int index = 0;

            frame.DeviceAddr = bytes[index++];
            frame.FuncID = bytes[index++];

            frame.DataField.Size = bytes[index++];
            frame.DataField.DataDestAddr = bytes[index++];
            frame.DataField.Data = new byte[frame.DataField.Size - 2];

            for (int i = 0; i < frame.DataField.Size-2; i++)
            {
                frame.DataField.Data[i] = bytes[index++];
            }

            frame.CheckSum = bytes[index++];

            return frame;
        }

        public static byte[] ListByteToBytes(List<byte> listByte)
        {
            byte[] bytes = new byte[listByte.Count];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = listByte[i];
            }

            return bytes;
        }

        public static string FrameToString(Frame frame)
        {
            string ret = "", ss = "";

            ss = string.Format("设备地址:0x{0:x2} ", frame.DeviceAddr);
            ret += ss;
            ss = string.Format("功能码:0x{0:x2} ", frame.FuncID);
            ret += ss;
            ss = string.Format("数据长度:0x{0:x2} ", frame.DataField.Size);
            ret += ss;
            ss = string.Format("目的地址:0x{0:x2} ", frame.DataField.DataDestAddr);
            ret += ss;
            ss = string.Format("累加和校验:0x{0:x2}", frame.CheckSum);
            ret += ss;
            

            return ret;
        }
    }
}
