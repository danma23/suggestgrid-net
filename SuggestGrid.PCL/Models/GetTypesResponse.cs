/*
 * SuggestGrid.PCL
 *
 * This file was automatically generated for SuggestGrid by APIMATIC v2.0 ( https://apimatic.io ) on 08/04/2016
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
    public class GetTypesResponse : INotifyPropertyChanged 
    {
        // These fields hold the values for the public properties.
        private List<string> types;
        private int? status;

        /// <summary>
        /// The list of type names
        /// </summary>
        [JsonProperty("types")]
        public List<string> Types 
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
        /// Status code of the response. It is not 2XX.
        /// </summary>
        [JsonProperty("status")]
        public int? Status 
        { 
            get 
            {
                return this.status; 
            } 
            set 
            {
                this.status = value;
                onPropertyChanged("Status");
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