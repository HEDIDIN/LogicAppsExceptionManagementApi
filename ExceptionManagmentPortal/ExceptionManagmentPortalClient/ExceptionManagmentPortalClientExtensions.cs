﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExceptionManagmentPortal;
using ExceptionManagmentPortal.Models;
using Microsoft.Rest;

namespace ExceptionManagmentPortal
{
    public static partial class ExceptionManagmentPortalClientExtensions
    {
        /// <param name='operations'>
        /// Reference to the
        /// ExceptionManagmentPortal.IExceptionManagmentPortalClient.
        /// </param>
        /// <param name='prescriberId'>
        /// Required.
        /// </param>
        public static IList<CrmErrorResponse> GetErrorRecord(this IExceptionManagmentPortalClient operations, string prescriberId)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IExceptionManagmentPortalClient)s).GetErrorRecordAsync(prescriberId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the
        /// ExceptionManagmentPortal.IExceptionManagmentPortalClient.
        /// </param>
        /// <param name='prescriberId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<IList<CrmErrorResponse>> GetErrorRecordAsync(this IExceptionManagmentPortalClient operations, string prescriberId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<System.Collections.Generic.IList<ExceptionManagmentPortal.Models.CrmErrorResponse>> result = await operations.GetErrorRecordWithOperationResponseAsync(prescriberId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the
        /// ExceptionManagmentPortal.IExceptionManagmentPortalClient.
        /// </param>
        /// <param name='collectionId'>
        /// Required.
        /// </param>
        public static TaskIListDocument QueryforErrorRecords(this IExceptionManagmentPortalClient operations, string collectionId)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IExceptionManagmentPortalClient)s).QueryforErrorRecordsAsync(collectionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the
        /// ExceptionManagmentPortal.IExceptionManagmentPortalClient.
        /// </param>
        /// <param name='collectionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<TaskIListDocument> QueryforErrorRecordsAsync(this IExceptionManagmentPortalClient operations, string collectionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<ExceptionManagmentPortal.Models.TaskIListDocument> result = await operations.QueryforErrorRecordsWithOperationResponseAsync(collectionId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}