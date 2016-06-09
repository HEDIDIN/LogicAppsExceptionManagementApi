using System.Collections;
using System.ComponentModel;
using Newtonsoft.Json;


namespace LogicAppsExceptionManagementApi.Models
{
    public class SalesforceRequest
    {

        [JsonProperty("Status")]
        [JsonRequired]
        public int Status { get; set; }

        [JsonProperty("message")]
        [JsonRequired]
        public string Message { get; set; }

        [JsonProperty("source")]
        [JsonRequired]
        public string Source { get; set; }

        [JsonProperty("action")]
        [JsonRequired]
        public string Action { get; set; }

        [JsonProperty("errors")]
        public IList Errors { get; set; }

        [JsonProperty("isError")]
        [JsonRequired]
        [DefaultValue(true)]
        public bool IsError { get; set; }

        [JsonProperty("prescriberId")]
        [DefaultValue("")]
        public string PrescriberId { get; set; }

        [JsonProperty("salesforceId")]
        [JsonRequired]
        public string SalesfroeceId { get; set; }

    }
}
