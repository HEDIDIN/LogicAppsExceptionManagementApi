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
    public class CrMtoSfErrorController : ApiController
    {
        private static DocumentClient _client;

        /// <summary>
        ///     Inserts a new action response document
        /// </summary>
        /// <param name="error">ErrorResponsef</param>
        /// <returns></returns>
        [HttpPost]
        [Metadata("SaveCrMtoSfErrorResponseAsync", "Inserts a new action error response document")]
        [SwaggerOperation("CreateErrorRecord")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<dynamic> SaveCrMtoSfErrorResponseAsync(
            [Metadata("Error", "Error Body")] [FromBody] CrmErrorResponse error)
        {
            _client = new DocumentClient(new Uri(DocumentDbContext.EndPoint), DocumentDbContext.AuthKey);

            var collectionLink = UriFactory.CreateDocumentCollectionUri(DocumentDbContext.DatabaseId, "CRMtoSF");

            dynamic errorMessage = new
            {
                id = error.PrescriberId + "-" + Math.Truncate(Utility.ConvertToTimestamp(DateTime.UtcNow)),
                prescriberId = error.PrescriberId,
                timestamp = DateTime.UtcNow,
                action = error.Action,
                body = error.Message,
                source = error.Source,
                code = error.StatusCode,
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