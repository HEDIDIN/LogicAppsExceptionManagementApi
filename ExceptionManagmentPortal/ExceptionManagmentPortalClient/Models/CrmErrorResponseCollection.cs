﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using ExceptionManagmentPortal.Models;
using Newtonsoft.Json.Linq;

namespace ExceptionManagmentPortal.Models
{
    public static partial class CrmErrorResponseCollection
    {
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public static IList<CrmErrorResponse> DeserializeJson(JToken inputObject)
        {
            IList<CrmErrorResponse> deserializedObject = new List<CrmErrorResponse>();
            foreach (JToken iListValue in ((JArray)inputObject))
            {
                CrmErrorResponse crmErrorResponse = new CrmErrorResponse();
                crmErrorResponse.DeserializeJson(iListValue);
                deserializedObject.Add(crmErrorResponse);
            }
            return deserializedObject;
        }
    }
}