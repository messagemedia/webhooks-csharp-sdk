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
    public class RetrieveResponse : BaseModel 
    {
        // These fields hold the values for the public properties.
        private int page;
        private int pageSize;
        private object pageData;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("page")]
        public int Page 
        { 
            get 
            {
                return this.page; 
            } 
            set 
            {
                this.page = value;
                onPropertyChanged("Page");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("pageSize")]
        public int PageSize 
        { 
            get 
            {
                return this.pageSize; 
            } 
            set 
            {
                this.pageSize = value;
                onPropertyChanged("PageSize");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("pageData")]
        public object PageData 
        { 
            get 
            {
                return this.pageData; 
            } 
            set 
            {
                this.pageData = value;
                onPropertyChanged("PageData");
            }
        }
    }
} 