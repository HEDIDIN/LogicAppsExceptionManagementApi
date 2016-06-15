using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace LogManagement.Models
{
    public class CrmRequest
    {
        [JsonProperty("patientId")]
        public string PatientId { get; set; }


        [JsonProperty("operation")]
        public string Operation { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("providerId")]
        public string ProviderId { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("ttl")]
        public int TimeToLive { get; set; }

        [JsonProperty("notDeleted")]
        [DefaultValue(true)]
        public bool NotDeleted { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}