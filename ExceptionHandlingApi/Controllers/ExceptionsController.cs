using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using ExceptionHandlingApi.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Swashbuckle.Swagger.Annotations;
using TRex.Metadata;


namespace ExceptionHandlingApi.Controllers
{
    public class ExceptionsController : ApiController
    {
        private static DocumentClient _client;

        private static readonly FeedOptions DefaultOptions = new FeedOptions { MaxItemCount = 10};

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prescriberId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetErrorRecord")]
        [Metadata("GetErrorRecordAsync", "Get an error document by prescriberId")]
        [SwaggerOperation("GetErrorRecord")]
        [SwaggerResponse(HttpStatusCode.OK,"Success", typeof(IList<CrmErrorResponse>))]
        [SwaggerResponse(HttpStatusCode.NotFound, "No Documents were found")]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public IList<CrmErrorResponse> GetErrorRecord(string prescriberId)
        {
            _client = new DocumentClient(new Uri(DocumentDbContext.EndPoint), DocumentDbContext.AuthKey);

            var errors = _client.CreateDocumentQuery<CrmErrorResponse>(UriFactory.CreateDocumentCollectionUri(DocumentDbContext.DatabaseId, "CRMtoSF"), new SqlQuerySpec()
            {
                QueryText = "SELECT * FROM CRMError e WHERE (e.prescriberId = '" + prescriberId + "' )",
                Parameters = new SqlParameterCollection()
                    {
                        new SqlParameter("@prescriberId", prescriberId)
                    }
            }, DefaultOptions);


            var response = errors.ToList();

            return response;
        }
           
           
    
           
        


        [Route("api/GetAllErrorRecords")]
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(Task<IList<Document>>))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "The syntax of the SQL Statement is incoreect")]
        [SwaggerResponse(HttpStatusCode.NotFound, "No Documents were found")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Internal Server Operation Error")]
        [SwaggerOperation("QueryforErrorRecords")]
        public IList<Document> GetAllErrorRecords(string collectionId)
        {
            _client = new DocumentClient(new Uri(DocumentDbContext.EndPoint), DocumentDbContext.AuthKey);

            var collectionLink = UriFactory.CreateDocumentCollectionUri(DocumentDbContext.DatabaseId, collectionId);

            var response =
                from e in _client.CreateDocumentQuery<Document>(collectionLink, DefaultOptions)
                select e;

            return response.ToList();
        }





    }
}
