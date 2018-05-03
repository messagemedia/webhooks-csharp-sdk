/*
 * MessageMediaWebhooks.Tests
 *
 * This file was automatically generated for MessageMedia by APIMATIC v2.0 ( https://apimatic.io )
 */
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
using MessageMedia.Webhooks.Controllers;

namespace MessageMedia.Webhooks
{
    [TestFixture]
    public class APIControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests)
        /// </summary>
        private static IAPIController controller;

        /// <summary>
        /// Setup test class
        /// </summary>
        [SetUp]
        public static void SetUpClass()
        {
            controller = GetClient().Client;
        }

        /// <summary>
        /// This will delete the webhook wuth the give id.
        ///a **Response 404 is returned when** :
        ///    <ul>
        ///     <li>there is no webhook  with this `webhookId` </li>
        ///    </ul> 
        /// </summary>
        [Test]
        public async Task TestDeleteDeleteAndUpdateWebhook1() 
        {
            // Parameters for the API call
            Guid webhookId = Guid.Parse("a7f11bb0-f299-4861-a5ca-9b29d04bc5ad");

            // Perform API call

            try
            {
                await controller.DeleteDeleteAndUpdateWebhookAsync(webhookId);
            }
            catch(APIException) {};

            // Test response code
            Assert.AreEqual(204, httpCallBackHandler.Response.StatusCode,
                    "Status should be 204");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", null);

            Assert.IsTrue(TestHelper.AreHeadersProperSubsetOf (
                    headers, httpCallBackHandler.Response.Headers),
                    "Headers should match");

        }

        /// <summary>
        /// This will retrieve all webhooks for the account we're connected with.
        ///a **Response 400 is returned when** :
        ///    <ul>
        ///     <li>the `page` query parameter is not valid </li>
        ///     <li>the `pageSize` query parameter is not valid </li>
        ///    </ul> 
        /// </summary>
        [Test]
        public async Task TestRetrieve1() 
        {
            // Parameters for the API call
            int? page = '1';
            int? pageSize = '10';

            // Perform API call
            Webhooks.Models.RetrieveResponse result = null;

            try
            {
                result = await controller.RetrieveAsync(page, pageSize);
            }
            catch(APIException) {};

            // Test response code
            Assert.AreEqual(200, httpCallBackHandler.Response.StatusCode,
                    "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", null);

            Assert.IsTrue(TestHelper.AreHeadersProperSubsetOf (
                    headers, httpCallBackHandler.Response.Headers),
                    "Headers should match");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");

            Assert.IsTrue(TestHelper.IsJsonObjectProperSubsetOf(
                    "    {    \"page\": 0,    \"pageSize\": 100,    \"pageData\": [{    \"id\": \"6e2c61df-d30a-4555-82a5-0e79822d8f53\",    \"url\": \"http://myurl.com\",    \"method\": \"POST\",    \"encoding\": \"FORM_ENCODED\",    \"headers\": {    \"Account\": \"FunGuys\"    },    \"template\": \"id=$mtId&status=$statusCode\",    \"events\": [    \"ENROUTE_DR\",    \"DELIVERED_DR\"    ]    }, {    \"id\": \"6e2c61df-d30a-4555-82a5-0e79822d8f53\",    \"url\": \"http://myurl.com\",    \"method\": \"POST\",    \"encoding\": \"XML\",    \"headers\": {    \"Account\": \"FunGuys\"    },    \"template\": \"<content><id> $mtId < /id> <status > $statusCode < /status> </content>\",    \"events\": [    \"ENROUTE_DR\",    \"DELIVERED_DR\"    ]    }]    }", 
                    TestHelper.ConvertStreamToString(httpCallBackHandler.Response.RawBody), 
                    true, true, false),
                    "Response body should have matching keys");
        }

    }
}