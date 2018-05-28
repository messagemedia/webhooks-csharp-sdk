/*
 * MessageMediaMessages.PCL
 *
 * This file was automatically generated for MessageMedia by APIMATIC v2.0 ( https://apimatic.io )
 */
using System;
using MessageMedia.Messages.Controllers;
using APIMATIC.SDK.Http.Client;
using APIMATIC.SDK.Common;

namespace MessageMedia.Messages
{
    public partial class MessageMediaMessagesClient: IMessageMediaMessagesClient
    {

        /// <summary>
        /// Singleton access to Messages controller
        /// </summary>
        public IMessagesController Messages
        {
            get
            {
                return MessagesController.Instance;
            }
        }

        /// <summary>
        /// Singleton access to Replies controller
        /// </summary>
        public IRepliesController Replies
        {
            get
            {
                return RepliesController.Instance;
            }
        }

        /// <summary>
        /// Singleton access to DeliveryReports controller
        /// </summary>
        public IDeliveryReportsController DeliveryReports
        {
            get
            {
                return DeliveryReportsController.Instance;
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
        public MessageMediaMessagesClient() { }

        /// <summary>
        /// Client initialization constructor
        /// </summary>
        public MessageMediaMessagesClient(string basicAuthUserName, string basicAuthPassword)
        {
            Configuration.BasicAuthUserName = basicAuthUserName;
            Configuration.BasicAuthPassword = basicAuthPassword;
        }
        #endregion
    }
}