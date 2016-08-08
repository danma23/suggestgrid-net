/*
 * SuggestGrid.PCL
 *
 * This file was automatically generated for SuggestGrid by APIMATIC v2.0 ( https://apimatic.io ) on 08/08/2016
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

namespace SuggestGrid.Models
{
    public class GetRecommendedUsersBody : INotifyPropertyChanged 
    {
        // These fields hold the values for the public properties.
        private string type;
        private string types;
        private string itemId;
        private List<string> itemIds;
        private int? size;
        private string similarUserId;
        private List<string> fields;
        private object filter;
        private List<string> except;

        /// <summary>
        /// TODO: Write general description for this method
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
        /// TODO: Write general description for this method
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
        /// TODO: Write general description for this method
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
        /// TODO: Write general description for this method
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
        /// TODO: Write general description for this method
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
        /// TODO: Write general description for this method
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
        /// TODO: Write general description for this method
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
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("filter")]
        public object Filter 
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
        /// These ids will not be included in the response.
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

        /// <summary>
        /// Property changed event for observer pattern
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises event when a property is changed
        /// </summary>
        /// <param name="propertyName">Name of the changed property</param>
        protected void onPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
} 