using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerConnector
{
    public class Notify
    {
        [JsonProperty(PropertyName = "endDate")]
        public string endDate
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "noticeContent")]
        public string noticeContent
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "noticeId")]
        public int noticeId
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "noticeTitle")]
        public string noticeTitle
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "startDate")]
        public string startDate
        {
            get;
            set;
        }

        public string subText
        {
            get;
            set;
        }
    }
}
