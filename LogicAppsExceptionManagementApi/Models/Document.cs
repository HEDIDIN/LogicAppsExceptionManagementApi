﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;

namespace LogicAppsExceptionManagementApi.Models
{
    public class Document
    {
        /// <summary>
        ///     Initializes a new instance of the Document class.
        /// </summary>
        public Document()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the Document class with required
        ///     arguments.
        /// </summary>
        public Document(string id)
            : this()
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            Id = id;
        }

        /// <summary>
        ///     Optional. This is a system generated property that specifies the
        ///     addressable path for the attachments resource.
        /// </summary>
        public string Attachments { get; set; }

        /// <summary>
        ///     Optional. This is a system generated property that specifies the
        ///     resource etag required for optimistic concurrency control.
        /// </summary>
        public string Etag { get; set; }

        /// <summary>
        ///     Optional. This is a system generated property. The resource Id
        ///     (_rid) is a unique identifier that is also hierarchical per the
        ///     resource stack on the resource model. It is used internally for
        ///     placement and navigation of the document resource.
        /// </summary>
        public string Rid { get; set; }

        /// <summary>
        ///     Optional. This is a system generated property. It is the unique
        ///     addressable URI for the resource.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        ///     Optional. This is a system generated property. It specifies the
        ///     last updated timestamp of the resource. The value is a timestamp.
        /// </summary>
        public int? Ts { get; set; }

        /// <summary>
        ///     Required. This is a user settable property. It is the unique name
        ///     that identifies the document, i.e. no two documents will share the
        ///     same id within a database. The id must not exceed 255 characters.
        /// </summary>
        public string Id { get; set; }
    }
}