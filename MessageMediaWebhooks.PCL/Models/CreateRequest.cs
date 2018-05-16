
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
    public class CreateRequest : BaseModel
    {
        // These fields hold the values for the public properties.
        private string url;
        private string method;
        private string encoding;
        private List<string> events;
        private string template;
        private Models.Headers headers;

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
        /// authorized webhook methods  :  GET, POST, PUT, DELETE, PATCH
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
        /// JSON, FORM_ENCODED, XML
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
        /// list of events we want to suscribe to. see docs
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
        /// expected template. see doc for possibilities
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
        /// customized headers.no content Type header because we set it in the encoding attribute. an example below
        /// </summary>
        [JsonProperty("headers")]
        public Models.Headers Headers
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
