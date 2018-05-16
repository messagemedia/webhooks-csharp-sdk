using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MessageMedia.Webhooks;
using MessageMedia.Webhooks.Helpers;

using MessageMedia.Webhooks.Models;

namespace MessageMedia.Webhooks
{
    [TestFixture]
    public class ControllerTestBase
    {
        //Test setup
        public const int REQUEST_TIMEOUT = 60;
        protected const double ASSERT_PRECISION = 0.1;
        public TimeSpan globalTimeout = TimeSpan.FromSeconds(REQUEST_TIMEOUT);

        protected HttpCallBackEventsHandler httpCallBackHandler = new HttpCallBackEventsHandler();

        [SetUp]
        public void SetUp()
        {
            //hooking events for catching http requests and responses
            GetClient().SharedHttpClient.OnBeforeHttpRequestEvent += httpCallBackHandler.OnBeforeHttpRequestEventHandler;
            GetClient().SharedHttpClient.OnAfterHttpResponseEvent += httpCallBackHandler.OnAfterHttpResponseEventHandler;
        }

        // Singleton instance of client for all test classes
        private static MessageMediaWebhooksClient client;
        private static object clientSync = new object();

        /// <summary>
        /// Get client instance
        /// </summary>
        /// <returns></returns>
        public static MessageMediaWebhooksClient GetClient()
        {
            lock (clientSync)
            {
                if (client == null)
                {
                    Configuration.BasicAuthUserName = Environment.GetEnvironmentVariable("MessageMediaApiTestsKey");
				            Configuration.BasicAuthPassword = Environment.GetEnvironmentVariable("MessageMediaApiTestsSecret");
                    client = new MessageMediaWebhooksClient();
                }
                return client;
            }
        }
    }
}
