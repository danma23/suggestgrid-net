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
    public class GetTypeResponse : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string rating;

        /// <summary>
        /// Rating type of the type that is either implicit or explicit.
        /// </summary>
        [JsonProperty("rating")]
        public string Rating 
        { 
            get 
            {
                return this.rating; 
            } 
            set 
            {
                this.rating = value;
                onPropertyChanged("Rating");
            }
        }
    }
} 