/*
 * SuggestGrid.PCL
 *
 * This file was automatically generated for SuggestGrid by APIMATIC v2.0 ( https://apimatic.io )
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
using SuggestGrid.Utilities;

namespace SuggestGrid.Exceptions
{
    public class LimitExceededErrorResponseException : APIException 
    {
        // These fields hold the values for the public properties.
        private string errorText;
        private string errorDescription;
        private string errorUri;
        private long? used;
        private long? limit;

        /// <summary>
        /// Message of the response.
        /// </summary>
        [JsonProperty("error_text")]
        public string ErrorText 
        { 
            get 
            {
                return this.errorText; 
            } 
            private set 
            {
                this.errorText = value;
            }
        }

        /// <summary>
        /// Description of the response.
        /// </summary>
        [JsonProperty("error_description")]
        public string ErrorDescription 
        { 
            get 
            {
                return this.errorDescription; 
            } 
            private set 
            {
                this.errorDescription = value;
            }
        }

        /// <summary>
        /// The URI of the error for more details.
        /// </summary>
        [JsonProperty("error_uri")]
        public string ErrorUri 
        { 
            get 
            {
                return this.errorUri; 
            } 
            private set 
            {
                this.errorUri = value;
            }
        }

        /// <summary>
        /// The quantity used by the account.
        /// </summary>
        [JsonProperty("used")]
        public long? Used 
        { 
            get 
            {
                return this.used; 
            } 
            private set 
            {
                this.used = value;
            }
        }

        /// <summary>
        /// The limit quantity of the account.
        /// </summary>
        [JsonProperty("limit")]
        public long? Limit 
        { 
            get 
            {
                return this.limit; 
            } 
            private set 
            {
                this.limit = value;
            }
        }

        /// <summary>
        /// Initialization constructor
        /// </summary>
        /// <param name="reason"> The reason for throwing exception </param>
        /// <param name="context"> The HTTP context that encapsulates request and response objects </param>
        public LimitExceededErrorResponseException(string reason, HttpContext context)
            : base(reason, context)
        {
        }
    }
} 