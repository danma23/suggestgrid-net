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
    public class GetRecommendedUsersBody : BaseModel
    {
        // These fields hold the values for the public properties.
        private string type;
        private string types;
        private string itemId;
        private List<string> itemIds;
        private int? mfrom;
        private int? size;
        private string similarUserId;
        private List<string> similarUserIds;
        private List<string> fields;
        private Dictionary<string, dynamic> filter;
        private List<string> except;

        /// <summary>
        /// The type of the query.
        /// </summary>
        [JsonProperty("type")]
        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
                onPropertyChanged("Type");
            }
        }

        /// <summary>
        /// The types of the query. Exactly one of type or types parameters must be provided.
        /// </summary>
        [JsonProperty("types")]
        public string Types
        {
            get
            {
                return this.types;
            }
            set
            {
                this.types = value;
                onPropertyChanged("Types");
            }
        }

        /// <summary>
        /// The item id of the query.
        /// </summary>
        [JsonProperty("item_id")]
        public string ItemId
        {
            get
            {
                return this.itemId;
            }
            set
            {
                this.itemId = value;
                onPropertyChanged("ItemId");
            }
        }

        /// <summary>
        /// The item ids of the query. Exactly one of item id or item ids parameters must be provided.
        /// </summary>
        [JsonProperty("item_ids")]
        public List<string> ItemIds
        {
            get
            {
                return this.itemIds;
            }
            set
            {
                this.itemIds = value;
                onPropertyChanged("ItemIds");
            }
        }

        /// <summary>
        /// The number of most recommended items to be skipped from the response. Defaults to 0.
        /// </summary>
        [JsonProperty("from")]
        public int? From
        {
            get
            {
                return this.mfrom;
            }
            set
            {
                this.mfrom = value;
                onPropertyChanged("From");
            }
        }

        /// <summary>
        /// The number of users asked to return in the response. Defaults to 10. Must be between 1 and 10.000 inclusive.
        /// </summary>
        [JsonProperty("size")]
        public int? Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
                onPropertyChanged("Size");
            }
        }

        /// <summary>
        /// Similar user that the response should be similar to.
        /// </summary>
        [JsonProperty("similar_user_id")]
        public string SimilarUserId
        {
            get
            {
                return this.similarUserId;
            }
            set
            {
                this.similarUserId = value;
                onPropertyChanged("SimilarUserId");
            }
        }

        /// <summary>
        /// Similar users that the response should be similar to.
        /// At most one of similar user and similar users parameters can be provided.
        /// </summary>
        [JsonProperty("similar_user_ids")]
        public List<string> SimilarUserIds
        {
            get
            {
                return this.similarUserIds;
            }
            set
            {
                this.similarUserIds = value;
                onPropertyChanged("SimilarUserIds");
            }
        }

        /// <summary>
        /// The metadata fields to be included in returned user objects.
        /// </summary>
        [JsonProperty("fields")]
        public List<string> Fields
        {
            get
            {
                return this.fields;
            }
            set
            {
                this.fields = value;
                onPropertyChanged("Fields");
            }
        }

        /// <summary>
        /// Contraints on the returned users or items.
        /// Filter structure is defined in [the filter parameter documentation](http://www.suggestgrid.com/docs/advanced-features#filters-parameter).
        /// </summary>
        [JsonProperty("filter")]
        public Dictionary<string, dynamic> Filter
        {
            get
            {
                return this.filter;
            }
            set
            {
                this.filter = value;
                onPropertyChanged("Filter");
            }
        }

        /// <summary>
        /// These user ids that will not be included in the response.
        /// </summary>
        [JsonProperty("except")]
        public List<string> Except
        {
            get
            {
                return this.except;
            }
            set
            {
                this.except = value;
                onPropertyChanged("Except");
            }
        }
    }
}
