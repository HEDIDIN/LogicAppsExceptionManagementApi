using System.Collections;
using System.ComponentModel;
using Newtonsoft.Json;

namespace LogicAppsExceptionManagementApi.Models
{
    public class SfErrorResponse
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

        [JsonProperty("resolved")]
        [DefaultValue(0)]
        public Status Resolved { get; set; }

        [JsonProperty("isError")]
        [JsonRequired]
        [DefaultValue(true)]
        public bool IsError { get; set; }

        [JsonProperty("salesforceId")]
        [JsonRequired]
        public string SalesforceId { get; set; }

        [JsonProperty("crmId")]
        [DefaultValue("")]
        public string CrmId { get; set; }

        [JsonProperty("severity")]
        [JsonRequired]
        public Severity Severity { get; set; }

        [JsonProperty("notes")]
        [DefaultValue("")]
        public string Notes { get; set; }

    }
}
