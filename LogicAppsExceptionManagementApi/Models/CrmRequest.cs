using System;
using System.Collections;
using System.ComponentModel;
using Newtonsoft.Json;

namespace LogicAppsExceptionManagementApi.Models
{
    public class CrmRequest
    {
        [JsonProperty("prescriberId")]
        [JsonRequired]
        public Guid PrescriberId { get; set; }


        [JsonProperty("operation")]
        [JsonRequired]
        public string Operation { get; set; }


        [JsonProperty("source")]
        [JsonRequired]
        public string Source { get; set; }

        [JsonProperty("salesforceId")]
        [DefaultValue("")]
        public string SalesForceId { get; set; }

        [JsonProperty("date")]
        public DateTime HeaderDateTime { get; set; }


    }
}