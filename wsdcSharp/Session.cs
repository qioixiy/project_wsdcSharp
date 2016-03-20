using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace wsdcSharp
{
    class Session
    {
        static Session session;
        string userName;
        string Uuid;
        string ServerUrl;

        public static Session GetSessionInstance()
        {
            if (session == null) {
                session = new Session();
            }

            return session;
        }

        public void SetUserName(string userName)
        {
            this.userName = userName;
        }
        public void SetUuid(string Uuid)
        {
            this.Uuid = Uuid;
        }
        public void SetServerUrl(string ServerUrl)
        {
            this.ServerUrl = ServerUrl;
        }
        public string GetUserName()
        {
            return userName;
        }
        public string GetUuid()
        {
            return Uuid;
        }
        public string SetServerUrl()
        {
            return ServerUrl;
        }


        public string HttpPost(string serverUrl, string paramer)
        {
            //创建一个HTTP请求
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serverUrl);
            //Post请求方式
            request.Method = "POST";
            //内容类型
            request.ContentType = "application/x-www-form-urlencoded";

            byte[] postdatabyte = Encoding.UTF8.GetBytes(paramer);
            //设置请求的ContentLength
            request.ContentLength = postdatabyte.Length;
            //发送请求，获得请求流

            Stream writer;
            try
            {
                writer = request.GetRequestStream();//获取用于写入请求数据的Stream对象
            }
            catch (Exception)
            {
                writer = null;
                Console.Write("连接服务器失败!");
            }
            //将请求参数写入流
            writer.Write(postdatabyte, 0, postdatabyte.Length);
            writer.Close();//关闭请求流

            HttpWebResponse response;
            try
            {
                //获得响应流
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
            }

            Stream s = response.GetResponseStream();
            StreamReader reader = new StreamReader(s);
            string str = reader.ReadToEnd();
            s.Close();

            return str;//返回Json数据
        }
    }
}
