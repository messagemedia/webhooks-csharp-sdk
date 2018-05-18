/*
 * MessageMediaWebhooks.Standard
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
using MessageMedia.Webhooks.Http.Client;

using MessageMedia.Webhooks.Models;
using MessageMedia.Webhooks;
using MessageMedia.Webhooks.Utilities;


namespace MessageMedia.Webhooks.Exceptions
{
    public class UpdateWebhook400ResponseException : APIException 
    {
        // These fields hold the values for the public properties.
        private string message;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("message")]
        public string Message 
        { 
            get 
            {
                return this.message; 
            } 
            private set 
            {
                this.message = value;
            }
        }

        /// <summary>
        /// Initialization constructor
        /// </summary>
        /// <param name="reason"> The reason for throwing exception </param>
        /// <param name="context"> The HTTP context that encapsulates request and response objects </param>
        public UpdateWebhook400ResponseException(string reason, HttpContext context)
            : base(reason, context)
        {
        }
    }
} 