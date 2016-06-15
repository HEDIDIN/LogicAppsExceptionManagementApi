using System.Collections.Generic;
using Newtonsoft.Json;

namespace LogicAppsExceptionManagementApi.Models
{
    public class SourceList
    {
        [JsonProperty("requestList")]
        public IList<string> RequestList { get; set; }
    }
}