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
    public class SchemaErrorResponseException : APIException 
    {
        // These fields hold the values for the public properties.
        private string message;
        private object mvalue;
        private object error;

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
        /// The cause of the error.
        /// </summary>
        [JsonProperty("value")]
        public object Value 
        { 
            get 
            {
                return this.mvalue; 
            } 
            private set 
            {
                this.mvalue = value;
            }
        }

        /// <summary>
        /// Programatic description of the error.
        /// </summary>
        [JsonProperty("error")]
        public object Error 
        { 
            get 
            {
                return this.error; 
            } 
            private set 
            {
                this.error = value;
            }
        }

        /// <summary>
        /// Initialization constructor
        /// </summary>
        /// <param name="reason"> The reason for throwing exception </param>
        /// <param name="context"> The HTTP context that encapsulates request and response objects </param>
        public SchemaErrorResponseException(string reason, HttpContext context)
            : base(reason, context)
        {
        }
    }
} 