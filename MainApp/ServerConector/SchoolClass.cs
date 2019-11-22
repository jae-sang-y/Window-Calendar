using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerConnector
{
    public class SchoolClass
    {
        [JsonProperty(PropertyName = "timeTableIndex")]
        public int timeTableIndex
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "teacher")]
        public string teacher
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "subject")]
        public string subject
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "schoolName")]
        public string schoolName
        {
            get;
            set;
        }
    }
}
