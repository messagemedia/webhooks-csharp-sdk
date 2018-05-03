/*
 * MessageMediaWebhooks.PCL
 *
 * This file was automatically generated for MessageMedia by APIMATIC v2.0 ( https://apimatic.io )
 */
using System;
using MessageMedia.Webhooks.Controllers;
using APIMATIC.SDK.Http.Client;
using APIMATIC.SDK.Common;

namespace MessageMedia.Webhooks
{
    public partial class MessageMediaWebhooksClient: IMessageMediaWebhooksClient
    {

        /// <summary>
        /// Singleton access to Client controller
        /// </summary>
        public IAPIController Client
        {
            get
            {
                return APIController.Instance;
            }
        }
        /// <summary>
        /// The shared http client to use for all API calls
        /// </summary>
        public IHttpClient SharedHttpClient
        {
            get
            {
                return BaseController.ClientInstance;
            }
            set
            {
                BaseController.ClientInstance = value;
            }        
        }
        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public MessageMediaWebhooksClient() { }

        /// <summary>
        /// Client initialization constructor
        /// </summary>
        public MessageMediaWebhooksClient(string basicAuthUserName, string basicAuthPassword)
        {
            Configuration.BasicAuthUserName = basicAuthUserName;
            Configuration.BasicAuthPassword = basicAuthPassword;
        }
        #endregion
    }
}