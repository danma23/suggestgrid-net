/*
 * SuggestGrid.PCL
 *
 * This file was automatically generated for SuggestGrid by APIMATIC v2.0 ( https://apimatic.io ) on 09/27/2016
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
    public class ErrorResponseException : APIException 
    {
        // These fields hold the values for the public properties.
        private string message;
        private int? status;

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
        /// Status code of the response. It is not 2XX.
        /// </summary>
        [JsonProperty("status")]
        public int? Status 
        { 
            get 
            {
                return this.status; 
            } 
            private set 
            {
                this.status = value;
            }
        }

        /// <summary>
        /// Initialization constructor
        /// </summary>
        /// <param name="reason"> The reason for throwing exception </param>
        /// <param name="context"> The HTTP context that encapsulates request and response objects </param>
        public ErrorResponseException(string reason, HttpContext context)
            : base(reason, context)
        {
        }
    }
} 