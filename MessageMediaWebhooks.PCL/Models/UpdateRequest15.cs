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
    public class UpdateRequest15 : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string url;
        private string template;

        /// <summary>
        /// target for the webhook. http and https are authorized
        /// </summary>
        [JsonProperty("url")]
        public string Url 
        { 
            get 
            {
                return this.url; 
            } 
            set 
            {
                this.url = value;
                onPropertyChanged("Url");
            }
        }

        /// <summary>
        /// expected template. see doc for possibilitie
        /// </summary>
        [JsonProperty("template")]
        public string Template 
        { 
            get 
            {
                return this.template; 
            } 
            set 
            {
                this.template = value;
                onPropertyChanged("Template");
            }
        }
    }
} 