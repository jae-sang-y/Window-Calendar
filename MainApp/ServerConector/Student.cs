using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ServerConnector
{
    public class Student
    {
        [JsonProperty(PropertyName ="admin")]
        public bool admin
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "classOf")]
        public int classOf
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "iconIndex")]
        public int iconIndex
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "id")]
        public string id
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "pw")]
        public string password
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "myCalendarId")]
        public int myCalendarId
        {
            get;
            set;
        }

    }
}
