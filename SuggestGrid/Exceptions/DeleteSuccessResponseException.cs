/*
 * SuggestGrid.PCL
 *
 * This file was automatically generated for SuggestGrid by APIMATIC v2.0 ( https://apimatic.io ) on 11/24/2016
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SuggestGrid.Http.Client;

using SuggestGrid.Models;
using SuggestGrid;

namespace SuggestGrid.Exceptions
{
    public class DeleteSuccessResponseException : APIException 
    {
        // These fields hold the values for the public properties.
        private string message;
        private int? found;
        private int? deleted;
        private int? failed;

        /// <summary>
        /// Message of the response.
        /// </summary>
        [JsonProperty("message")]
        public string Message 
        { 
            get 
            {
                return this.message; 
            } 
            private set 
            {
                this.message = value;
            }
        }

        /// <summary>
        /// The number of records found for the delete query.
        /// </summary>
        [JsonProperty("found")]
        public int? Found 
        { 
            get 
            {
                return this.found; 
            } 
            private set 
            {
                this.found = value;
            }
        }

        /// <summary>
        /// The number of records deleted for the delete query.
        /// </summary>
        [JsonProperty("deleted")]
        public int? Deleted 
        { 
            get 
            {
                return this.deleted; 
            } 
            private set 
            {
                this.deleted = value;
            }
        }

        /// <summary>
        /// The number of records found but not deleted for the delete query.
        /// </summary>
        [JsonProperty("failed")]
        public int? Failed 
        { 
            get 
            {
                return this.failed; 
            } 
            private set 
            {
                this.failed = value;
            }
        }

        /// <summary>
        /// Initialization constructor
        /// </summary>
        /// <param name="reason"> The reason for throwing exception </param>
        /// <param name="context"> The HTTP context that encapsulates request and response objects </param>
        public DeleteSuccessResponseException(string reason, HttpContext context)
            : base(reason, context)
        {
        }
    }
} 