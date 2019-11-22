using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerConnector
{
    public class Schedule
    {
        [JsonProperty(PropertyName = "end_date")]
        public string end_date
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "schedule_content")]
        public string schedule_content
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "schedule_id")]
        public int schedule_id
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "calendar_id")]
        public int calendar_id
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "schedule_title")]
        public string schedule_title
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "start_date")]
        public string start_date
        {
            get;
            set;
        }

        public string subText
        {
            get;
            set;
        }

        public DateTime date;

    }
}
