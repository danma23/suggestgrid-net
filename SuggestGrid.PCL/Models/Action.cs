/*
 * SuggestGrid.PCL
 *
 * This file was automatically generated for SuggestGrid by APIMATIC v2.0 ( https://apimatic.io ) on 05/30/2016
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
    public class ActionModel : INotifyPropertyChanged
    {
        // These fields hold the values for the public properties.
        private string itemId;
        private double? rating;
        private string userId;

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
        [JsonProperty("rating")]
        public double? Rating
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

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId
        {
            get
            {
                return this.userId;
            }
            set
            {
                this.userId = value;
                onPropertyChanged("UserId");
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
