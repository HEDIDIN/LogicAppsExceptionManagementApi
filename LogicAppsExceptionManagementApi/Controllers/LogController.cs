using System;
using System.Collections;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using LogicAppsExceptionManagementApi.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using Swashbuckle.Swagger.Annotations;
using TRex.Metadata;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace LogicAppsExceptionManagementApi.Controllers
{
    public class LogController : ApiController
    {
        private static DocumentClient _client;

        /// <summary>
        ///     Inserts a new response document for logging
        ///     Time to Live 2592000 = 30 days
        /// </summary>
        /// <param name="crmRequest"></param>
        /// <returns></returns>
        [Metadata("Save CRM to SF Request Message")]
        [SwaggerOperation("InsertLogEntry")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<dynamic> SaveCrMtoSfLogAsync(
            [Metadata("crmRequest")] [FromBody] CrmRequest crmRequest)
        {
            _client = new DocumentClient(new Uri(DocumentDbContext.EndPoint), DocumentDbContext.AuthKey);


            var collectionLink = UriFactory.CreateDocumentCollectionUri("Logs", "CRM");

            dynamic logMessage = new
            {
                id = crmRequest.PrescriberId + "_" + Math.Truncate(Utility.ConvertToTimestamp(DateTime.UtcNow)),
                presciberId = crmRequest.PrescriberId,
                timestamp = crmRequest.HeaderDateTime,
                source = crmRequest.Source,
                operation = crmRequest.Operation,
                salesforceId = crmRequest.SalesForceId,
                ttl = 2592000,
                expired = false
            };

            ResourceResponse<Document> response =
                await _client.CreateDocumentAsync(collectionLink, logMessage, disableAutomaticIdGeneration: true);


            var createdDocument = response.Resource;


            return createdDocument;
        }

     

    }


}