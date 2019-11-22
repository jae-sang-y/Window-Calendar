using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace ServerConnector
{
    public class ServerConnector
    {
        private static ServerConnector instance = null;
        public Student student;
        protected ServerConnector()
        {
            student = new Student();
        }

        [STAThread] 
        public static ServerConnector GetInstace()
        {
            if (instance == null) instance = new ServerConnector();

            return instance;
        }

        public static int Timeout = 10;
        public Tuple<HttpStatusCode, string> SendRequest(string link, string method, string pdata)
        {
            string link12 = $@"http://192.168.137.1:8080/{ link }";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create($@"http://192.168.137.1:8080/{ link }");
            req.Method = method;
            req.ContentType = "application/json;charset=UTF-8";
            req.Accept = "*/*";

            //string postData =
            //    "{\"admin\":true,\"classOf\": 0,\"iconIndex\":0,\"id\":\"apple03550\",\"pw\":\"apple03550\",\"myCalendarId\":0}"
            //;
            byte[] data = Encoding.UTF8.GetBytes(pdata);
            req.ContentLength = data.Length;

            using (Stream requestStream = req.GetRequestStream())
            {
                requestStream.Write(data, 0, data.Length);
            }
                    
            WebResponse response = req.GetResponse();
            string res;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                res = reader.ReadToEnd();
            }

            return new Tuple<HttpStatusCode, string>(((HttpWebResponse)response).StatusCode, res);
        }
    }
}
