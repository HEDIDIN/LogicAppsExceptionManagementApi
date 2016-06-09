using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using LogicAppsExceptionManagementApi.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Swashbuckle.Swagger.Annotations;
using TRex.Metadata;


namespace LogicAppsExceptionManagementApi.Controllers
{
    public class SFtoCrmErrorController : ApiController
    {
        private static DocumentClient _client;

        /// <summary>
        ///     Inserts a new action response document
        /// </summary>
        /// <param name="error">SfErrorResponse</param>
        /// <returns></returns>
        [Route("api/Prescriber")]
        [HttpPost]
        [Metadata("PrescibertErrorResponseAsync", "Inserts a new action error response document")]
        [SwaggerOperation("CreatePrescriberError")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<dynamic> PrescibertErrorResponseAsync(
            [Metadata("Error", "Error Body")] [FromBody] SfErrorResponse error)
        {
            _client = new DocumentClient(new Uri(DocumentDbContext.EndPoint), DocumentDbContext.AuthKey);

            var collectionLink = UriFactory.CreateDocumentCollectionUri(DocumentDbContext.DatabaseId, "SFtoCRM");

            dynamic errorMessage = new
            {
                id = error.SalesforceId + "-" + Math.Truncate(Utility.ConvertToTimestamp(DateTime.UtcNow)),
                salesforceId = error.SalesforceId,
                crmId = error.CrmId,
                timstamp = DateTime.UtcNow,
                action = error.Action,
                body = error.Message,
                source = error.Source,
                code = error.Status,
                errors = error.Errors,
                isError = error.IsError,
                severity = error.Severity,
                notes = error.Notes,
                resolved = error.Resolved

            };

            ResourceResponse<Document> response =
                await _client.CreateDocumentAsync(collectionLink, errorMessage, disableAutomaticIdGeneration: true);
            var createdDocument = response.Resource;
            return createdDocument;
        }


        /// <summary>
        ///     Inserts a new action response document
        /// </summary>
        /// <param name="error">SfErrorResponse</param>
        /// <returns></returns>
        [Route("api/Atl")]
        [HttpPost]
        [Metadata("AtlErrorResponseAsync", "Inserts a new action error response document")]
        [SwaggerOperation("CreateAtlError")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<dynamic> AtlErrorResponseAsync(
            [Metadata("Error", "Error Body")] [FromBody] SfErrorResponse error)
        {
            _client = new DocumentClient(new Uri(DocumentDbContext.EndPoint), DocumentDbContext.AuthKey);

            var collectionLink = UriFactory.CreateDocumentCollectionUri(DocumentDbContext.DatabaseId, "SFtoCRM");

            dynamic errorMessage = new
            {
                id = error.SalesforceId + "-" + Math.Truncate(Utility.ConvertToTimestamp(DateTime.UtcNow)),
                salesforceId = error.SalesforceId,
                crmId = error.CrmId,
                timstamp = DateTime.UtcNow,
                action = error.Action,
                body = error.Message,
                source = error.Source,
                code = error.Status,
                errors = error.Errors,
                isError = error.IsError,
                severity = error.Severity,
                notes = error.Notes,
                resolved = error.Resolved

            };

            ResourceResponse<Document> response =
                await _client.CreateDocumentAsync(collectionLink, errorMessage, disableAutomaticIdGeneration: true);
            var createdDocument = response.Resource;
            return createdDocument;
        }


        /// <summary>
        ///     Inserts a new action response document
        /// </summary>
        /// <param name="error">SfErrorResponse</param>
        /// <returns></returns>
        [Route("api/Address")]
        [HttpPost]
        [Metadata("AddressErrorResponseAsync", "Inserts a new action error response document")]
        [SwaggerOperation("CreateAddressError")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<dynamic> AddressErrorResponseAsync(
            [Metadata("Error", "Error Body")] [FromBody] SfErrorResponse error)
        {
            _client = new DocumentClient(new Uri(DocumentDbContext.EndPoint), DocumentDbContext.AuthKey);

            var collectionLink = UriFactory.CreateDocumentCollectionUri(DocumentDbContext.DatabaseId, "SFtoCRM");

            dynamic errorMessage = new
            {
                id = error.SalesforceId + "-" + Math.Truncate(Utility.ConvertToTimestamp(DateTime.UtcNow)),
                salesforceId = error.SalesforceId,
                crmId = error.CrmId,
                timstamp = DateTime.UtcNow,
                action = error.Action,
                body = error.Message,
                source = error.Source,
                code = error.Status,
                errors = error.Errors,
                isError = error.IsError,
                severity = error.Severity,
                notes = error.Notes,
                resolved = error.Resolved

            };

            ResourceResponse<Document> response =
                await _client.CreateDocumentAsync(collectionLink, errorMessage, disableAutomaticIdGeneration: true);
            var createdDocument = response.Resource;
            return createdDocument;
        }



    }
}
