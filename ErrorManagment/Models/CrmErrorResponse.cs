﻿using System;
using System.Collections;
using System.ComponentModel;
using Newtonsoft.Json;

namespace ErrorManagment.Models
{
    public class CrmErrorResponse
    {
        [JsonProperty("id")]
        [JsonRequired]
        public string Id { get; set; }

        [JsonProperty("code")]
        [JsonRequired]
        public int Code { get; set; }

      
        [JsonProperty("body")]
        [JsonRequired]
        public string Body { get; set; }

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

        [JsonProperty("notes")]
        [DefaultValue("")]
        public string Notes { get; set; }

        [JsonProperty("isError")]
        [JsonRequired]
        [DefaultValue(true)]
        public bool IsError { get; set; }

        [JsonProperty("prescriberId")]
        [JsonRequired]
        public string PrescriberId { get; set; }

        [JsonProperty("severity")]
        [JsonRequired]
        public Severity  Severity{ get; set; }


        [JsonProperty("timestamp")]
        [JsonRequired]
        public DateTime TimeStamp { get; set; }
    }
}