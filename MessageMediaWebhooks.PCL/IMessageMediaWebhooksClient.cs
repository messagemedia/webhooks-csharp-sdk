
using System;
using MessageMedia.Webhooks.Controllers;

namespace MessageMedia.Webhooks
{
    public partial interface IMessageMediaWebhooksClient
    {

        /// <summary>
        /// Singleton access to Client controller
        /// </summary>
        IAPIController Client { get;}

    }
}
