using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace LogicAppsExceptionManagementApi.Models
{
    public class CrmRequest
    {
        [JsonProperty("patientId")]
        [JsonRequired]
        public string PatientId { get; set; }


        [JsonProperty("operation")]
        [JsonRequired]
        public string Operation { get; set; }


        [JsonProperty("source")]
        [JsonRequired]
        public string Source { get; set; }

        [JsonProperty("providerId")]
        [DefaultValue("")]
        public string ProviderId { get; set; }

        [JsonProperty("date")]
        public DateTime HeaderDateTime { get; set; }


    }
}