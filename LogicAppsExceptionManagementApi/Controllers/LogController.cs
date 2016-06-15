using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using LogicAppsExceptionManagementApi.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Swashbuckle.Swagger.Annotations;
using TRex.Metadata;
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


            var collectionLink = UriFactory.CreateDocumentCollectionUri(DocumentDbContext.DatabaseId,"Logs");

            dynamic logMessage = new
            {
                id = crmRequest.PatientId + "_" + Math.Truncate(Utility.ConvertToTimestamp(DateTime.UtcNow)),
                patientId = crmRequest.PatientId,
                timestamp = crmRequest.HeaderDateTime,
                source =  crmRequest.Source,
                operation = crmRequest.Operation,
                Provider = crmRequest.ProviderId,
                ttl = 2592000,
                notDeleted = true
            };

            ResourceResponse<Document> response =
                await _client.CreateDocumentAsync(collectionLink, logMessage, disableAutomaticIdGeneration: true);


            var createdDocument = response.Resource;


            return createdDocument;
        }

        /// <summary>
        ///     convert JSON string to List
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private IList<SourceList> GetList(string source)
        {
            // Call the deserializer
            var validList = List.DeserializeToList<SourceList>(source);

            return validList;
        }

    }


}