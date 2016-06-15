using System.Collections.Generic;
using Newtonsoft.Json;

namespace LogManagement.Models
{
    public class SourceList
    {
        [JsonProperty("requestList")]
        public IList<string> RequestList { get; set; }
    }
}