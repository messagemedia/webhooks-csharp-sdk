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
using MessageMedia.Webhooks.Exceptions;

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

        /// <summary>
        /// Delete a webhook that was previously created for the connected account.
        ///A webhook can be cancelled by appending the UUID of the webhook to the endpoint and submitting a DELETE request to the /webhooks/messages endpoint.
        ///*Note: Only pre-created webhooks can be deleted. If an invalid or non existent webhook ID parameter is specified in the request, then a HTTP 404 Not Found response will be returned.* 
        /// </summary>
        [Test]
        public async Task TestDeleteWebhook1() 
        {
            // Parameters for the API call
            Guid webhookId = Guid.Parse("a7f11bb0-f299-4861-a5ca-9b29d04bc5ad");

            // Perform API call

            try
            {
                await controller.DeleteWebhookAsync(webhookId);
            }
            catch(APIException) {};

            // Test response code
            Assert.AreEqual(204, httpCallBackHandler.Response.StatusCode,
                    "Status should be 204");

            Assert.AreEqual(
                    headers.Count, httpCallBackHandler.Response.Headers().Count,
                    "Headers count should match exactly");
        }

        /// <summary>
        /// Update a webhook. You can update individual attributes or all of them by submitting a PATCH request to the /webhooks/messages endpoint (the same endpoint used above to delete a webhook)
        ///A successful request to the retrieve webhook endpoint will return a response body as follows:
        ///```
        ///{
        ///    "url": "https://webhook.com",
        ///    "method": "POST",
        ///    "id": "04442623-0961-464e-9cbc-ec50804e0413",
        ///    "encoding": "JSON",
        ///    "events": [
        ///        "RECEIVED_SMS"
        ///    ],
        ///    "headers": {},
        ///    "template": "{\"id\":\"$mtId\", \"status\":\"$statusCode\"}"
        ///}
        ///```
        ///*Note: Only pre-created webhooks can be deleted. If an invalid or non existent webhook ID parameter is specified in the request, then a HTTP 404 Not Found response will be returned.* 
        /// </summary>
        [Test]
        public async Task TestUpdateWebhook1() 
        {
            // Parameters for the API call
            Guid webhookId = Guid.Parse("a7f11bb0-f299-4861-a5ca-9b29d04bc5ad");
            Webhooks.Models.UpdateWebhookRequest body = APIHelper.JsonDeserialize<Webhooks.Models.UpdateWebhookRequest>("    {        \"url\": \"https://myurl.com\",        \"method\": \"POST\",        \"encoding\": \"FORM_ENCODED\",        \"events\": [            \"ENROUTE_DR\"        ],        \"template\": \"{\\\"id\\\":\\\"$mtId\\\", \\\"status\\\":\\\"$statusCode\\\"}\"    }");

            // Perform API call
            dynamic result = null;

            try
            {
                result = await controller.UpdateWebhookAsync(webhookId, body);
            }
            catch(APIException) {};

            // Test response code
            Assert.AreEqual(200, httpCallBackHandler.Response.StatusCode,
                    "Status should be 200");

            Assert.AreEqual(
                    headers.Count, httpCallBackHandler.Response.Headers().Count,
                    "Headers count should match exactly");
        }

    }
}