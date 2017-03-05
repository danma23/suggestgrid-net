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
    public class MessageResponse : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string message;

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
    }
} 