
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using APIMATIC.SDK.Common; 
using APIMATIC.SDK.Http.Client;
using APIMATIC.SDK.Http.Response;
using MessageMedia.Webhooks.Helpers;
using NUnit.Framework;
using MessageMedia.Webhooks;
using MessageMedia.Webhooks.Exceptions;
using MessageMedia.Webhooks.Controllers;

namespace MessageMedia.Webhooks
{
    [TestFixture]
    public class WebhooksControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests)
        /// </summary>
        private static IWebhooksController controller;

        /// <summary>
        /// Setup test class
        /// </summary>
        [SetUp]
        public static void SetUpClass()
        {
            controller = GetClient().Webhooks;
        }


        [Test]
        public async Task TestRetrieveWebhooks()
        {
            // Parameters for the API call
            int? page = 0;
            int? pageSize = 0;

            // Perform API call

            try
            {
                await controller.RetrieveWebhookAsync(page, pageSize);
            }
            catch (APIException) { };

            // Test response code
            Assert.AreEqual(200, httpCallBackHandler.Response.StatusCode,
                    "Status should be 200");

        }


    }
}