using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace LogManagement.Models
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

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("ttl")]
        public int TimeToLive { get; set; }

        [JsonProperty("expired")]
        public bool Expired { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

    }
}