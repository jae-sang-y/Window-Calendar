using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerConnector
{ 
    public class Room
    {
        [JsonProperty(PropertyName = "calendarId")]
        public int calendarId
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
        [JsonProperty(PropertyName = "roomId")]
        public int roomId
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "roomTitle")]
        public string roomTitle
        {
            get;
            set;
        }
    }
}
