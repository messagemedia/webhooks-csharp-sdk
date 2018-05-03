/*
 * MessageMediaWebhooks.PCL
 *
 * This file was automatically generated for MessageMedia by APIMATIC v2.0 ( https://apimatic.io )
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
using APIMATIC.SDK.Common;


namespace MessageMedia.Webhooks.Models
{
    public class Headers : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string account;

        /// <summary>
        /// Example of
        /// </summary>
        [JsonProperty("Account")]
        public string Account 
        { 
            get 
            {
                return this.account; 
            } 
            set 
            {
                this.account = value;
                onPropertyChanged("Account");
            }
        }
    }
} 