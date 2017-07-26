using Newtonsoft.Json;
using System;

namespace MSATodo.Models
{
    public class TodoTable
    {
        [JsonProperty(PropertyName = "ID")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "note")]
        public string note { get; set; }

        [JsonProperty(PropertyName = "priority")]
        public string priority { get; set; }

        [JsonProperty(PropertyName = "completed")]
        public bool completed { get; set; }

        [JsonProperty(PropertyName = "date")]
        public string date { get; set; }

        [JsonProperty(PropertyName = "time")]
        public string time { get; set; }
    }
}
