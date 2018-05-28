
using System;
using MessageMedia.Webhooks.Controllers;

namespace MessageMedia.Webhooks
{
    public partial interface IMessageMediaWebhooksClient
    {

        /// <summary>
        /// Singleton access to Webhooks controller
        /// </summary>
        IWebhooksController Webhooks { get;}

    }
}