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
    public class ItemsResponse : BaseModel
    {
        // These fields hold the values for the public properties.
        private long? count;
        private long? totalCount;
        private List<Models.Metadata<string,object>> items;

        /// <summary>
        /// The number of items in the response.
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
        /// The total number of items available.
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
        [JsonProperty("items")]
        public List<Models.Metadata<string,object>> Items
        {
            get
            {
                return this.items;
            }
            set
            {
                this.items = value;
                onPropertyChanged("Items");
            }
        }
    }
}
