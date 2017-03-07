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
using SuggestGrid;
using SuggestGrid.Utilities;

namespace SuggestGrid.Models
{
    public class DeleteSuccessResponse : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string message;
        private long? found;
        private long? deleted;
        private long? failed;

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
            set 
            {
                this.message = value;
                onPropertyChanged("Message");
            }
        }

        /// <summary>
        /// The number of records found for the delete query.
        /// </summary>
        [JsonProperty("found")]
        public long? Found 
        { 
            get 
            {
                return this.found; 
            } 
            set 
            {
                this.found = value;
                onPropertyChanged("Found");
            }
        }

        /// <summary>
        /// The number of records deleted for the delete query.
        /// </summary>
        [JsonProperty("deleted")]
        public long? Deleted 
        { 
            get 
            {
                return this.deleted; 
            } 
            set 
            {
                this.deleted = value;
                onPropertyChanged("Deleted");
            }
        }

        /// <summary>
        /// The number of records found but not deleted for the delete query.
        /// </summary>
        [JsonProperty("failed")]
        public long? Failed 
        { 
            get 
            {
                return this.failed; 
            } 
            set 
            {
                this.failed = value;
                onPropertyChanged("Failed");
            }
        }
    }
} 