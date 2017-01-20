/*
 * SuggestGrid.PCL
 *
 * This file was automatically generated for SuggestGrid by APIMATIC v2.0 ( https://apimatic.io ) on 01/20/2017
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
    public class ActionsResponse : INotifyPropertyChanged 
    {
        // These fields hold the values for the public properties.
        private long? count;
        private long? totalCount;
        private List<Action> actions;

        /// <summary>
        /// The number of actions in the response.
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
        /// The total number of actions.
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
        [JsonProperty("actions")]
        public List<Action> Actions 
        { 
            get 
            {
                return this.actions; 
            } 
            set 
            {
                this.actions = value;
                onPropertyChanged("Actions");
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