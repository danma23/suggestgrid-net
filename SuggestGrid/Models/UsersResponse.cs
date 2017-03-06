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
    public class UsersResponse : BaseModel 
    {
        // These fields hold the values for the public properties.
        private long? count;
        private long? totalCount;
        private List<Models.Metadata> users;

        /// <summary>
        /// The number of users in the response.
        /// </summary>
        [JsonProperty("count")]
        public long? Count 
        { 
            get 
            {
                return this.count; 
            } 
            set 
            {
                this.count = value;
                onPropertyChanged("Count");
            }
        }

        /// <summary>
        /// The total number of users available.
        /// </summary>
        [JsonProperty("total_count")]
        public long? TotalCount 
        { 
            get 
            {
                return this.totalCount; 
            } 
            set 
            {
                this.totalCount = value;
                onPropertyChanged("TotalCount");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("users")]
        public List<Models.Metadata> Users 
        { 
            get 
            {
                return this.users; 
            } 
            set 
            {
                this.users = value;
                onPropertyChanged("Users");
            }
        }
    }
} 