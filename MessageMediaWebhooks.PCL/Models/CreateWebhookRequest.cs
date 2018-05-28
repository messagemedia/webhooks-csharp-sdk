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
    public class CreateWebhookRequest : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string url;
        private string method;
        private string encoding;
        private List<string> events;
        private string template;
        private object headers;

        /// <summary>
        /// TODO: Write general description for this method
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
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("method")]
        public string Method 
        { 
            get 
            {
                return this.method; 
            } 
            set 
            {
                this.method = value;
                onPropertyChanged("Method");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("encoding")]
        public string Encoding 
        { 
            get 
            {
                return this.encoding; 
            } 
            set 
            {
                this.encoding = value;
                onPropertyChanged("Encoding");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("events")]
        public List<string> Events 
        { 
            get 
            {
                return this.events; 
            } 
            set 
            {
                this.events = value;
                onPropertyChanged("Events");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
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

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("headers")]
        public object Headers 
        { 
            get 
            {
                return this.headers; 
            } 
            set 
            {
                this.headers = value;
                onPropertyChanged("Headers");
            }
        }
    }
} 