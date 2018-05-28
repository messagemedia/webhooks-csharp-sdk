
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMATIC.SDK.Common;
using APIMATIC.SDK.Http.Request;
using APIMATIC.SDK.Http.Response;
using APIMATIC.SDK.Http.Client;

namespace MessageMedia.Webhooks.Controllers
{
    public partial interface IWebhooksController
    {
        /// <summary>
        /// Create a webhook for one or more of the specified events.
        /// A webhook would typically have the following structure:
        /// ```
        /// {
        ///   "url": "http://webhook.com",
        ///   "method": "POST",
        ///   "encoding": "JSON",
        ///   "headers": {
        ///     "Account": "DeveloperPortal7000"
        ///   },
        ///   "events": [
        ///     "RECEIVED_SMS"
        ///   ],
        ///   "template": "{\"id\":\"$mtId\",\"status\":\"$statusCode\"}"
        /// }
        /// ```
        /// A valid webhook must consist of the following properties:
        /// - ```url``` The configured URL which will trigger the webhook when a selected event occurs.
        /// - ```method``` The methods to map CRUD (create, retrieve, update, delete) operations to HTTP requests.
        /// - ```encoding``` The format in which the payload will be returned. You can choose from ```JSON```, ```FORM_ENCODED``` or ```XML```. This will automatically add the Content-Type header for you so you don't have to add it again in the `headers` property.
        /// - ```headers``` HTTP header fields which provide required information about the request or response, or about the object sent in the message body. This should not include the `Content-Type` header.
        /// - ```events``` Event or events that will trigger the webhook. Atleast one event should be present.
        /// - ```template``` The structure of the payload that will be returned.
        /// #### Types of Events
        /// You can select all of the events (listed below) or combine them in whatever way you like but atleast one event must be used. Otherwise, the webhook won't be created.
        /// A webhook will be triggered when any one or more of the events occur:
        /// + **SMS**
        ///     + `RECEIVED_SMS` Receive an SMS
        ///     + `OPT_OUT_SMS` Opt-out occured
        /// + **MMS**
        ///     + `RECEIVED_MMS` Receive an MMS
        /// + **DR (Delivery Reports)**
        ///     + `ENROUTE_DR` Message is enroute
        ///     + `EXPIRED_DR` Message has expired
        ///     + `REJECTED_DR` Message is rejected
        ///     + `FAILED_DR` Message has failed 
        ///     + `DELIVERED_DR` Message is delivered
        ///     + `SUBMITTED_DR` Message is submitted
        /// #### Template Parameters
        /// You can choose what to include in the data that will be sent as the payload via the Webhook.
        /// Keep in my mind, you must escape the JSON in the template value (see example above).
        /// The table illustrates a list of all the parameters that can be included in the template and which event types it can be applied to.
        /// | Data  | Parameter Name | Example | Event Type |
        /// |:--|--|--|--|--|
        /// | **Service Type**  | $type| `SMS` | `DR` `MO` `MO MMS` |
        /// | **Message ID**  | $mtId, $messageId| `877c19ef-fa2e-4cec-827a-e1df9b5509f7` | `DR` `MO` `MO MMS`|
        /// | **Delivery Report ID** |$drId, $reportId| `01e1fa0a-6e27-4945-9cdb-18644b4de043` | `DR` |
        /// | **Reply ID**| $moId, $replyId| `a175e797-2b54-468b-9850-41a3eab32f74` | `MO` `MO MMS` |
        /// | **Account ID**  | $accountId| `DeveloperPortal7000` | `DR` `MO` `MO MMS` |
        /// | **Message Timestamp**  | $submittedTimestamp| `2016-12-07T08:43:00.850Z` | `DR` `MO` `MO MMS` |
        /// | **Provider Timestamp**  | $receivedTimestamp| `2016-12-07T08:44:00.850Z` | `DR` `MO` `MO MMS` |
        /// | **Message Status** | $status| `enroute` | `DR` |
        /// | **Status Code**  | $statusCode| `200` | `DR` |
        /// | **External Metadata** | $metadata.get('key')| `name` | `DR` `MO` `MO MMS` |
        /// | **Source Address**| $sourceAddress| `+61491570156` | `DR` `MO` `MO MMS` |
        /// | **Destination Address**| $destinationAddress| `+61491593156` | `MO` `MO MMS` |
        /// | **Message Content**| $mtContent, $messageContent| `Hi Derp` | `DR` `MO` `MO MMS` |
        /// | **Reply Content**| $moContent, $replyContent| `Hello Derpina` | `MO` `MO MMS` |
        /// | **Retry Count**| $retryCount| `1` | `DR` `MO` `MO MMS` |
        /// *Note: A 400 response will be returned if the `url` is invalid, the `events`, `encoding` or `method` is null or the `headers` has a Content-Type  attribute.*
        /// </summary>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the dynamic response from the API call</return>
        dynamic CreateWebhook(Models.CreateWebhookRequest body);

        /// <summary>
        /// Create a webhook for one or more of the specified events.
        /// A webhook would typically have the following structure:
        /// ```
        /// {
        ///   "url": "http://webhook.com",
        ///   "method": "POST",
        ///   "encoding": "JSON",
        ///   "headers": {
        ///     "Account": "DeveloperPortal7000"
        ///   },
        ///   "events": [
        ///     "RECEIVED_SMS"
        ///   ],
        ///   "template": "{\"id\":\"$mtId\",\"status\":\"$statusCode\"}"
        /// }
        /// ```
        /// A valid webhook must consist of the following properties:
        /// - ```url``` The configured URL which will trigger the webhook when a selected event occurs.
        /// - ```method``` The methods to map CRUD (create, retrieve, update, delete) operations to HTTP requests.
        /// - ```encoding``` The format in which the payload will be returned. You can choose from ```JSON```, ```FORM_ENCODED``` or ```XML```. This will automatically add the Content-Type header for you so you don't have to add it again in the `headers` property.
        /// - ```headers``` HTTP header fields which provide required information about the request or response, or about the object sent in the message body. This should not include the `Content-Type` header.
        /// - ```events``` Event or events that will trigger the webhook. Atleast one event should be present.
        /// - ```template``` The structure of the payload that will be returned.
        /// #### Types of Events
        /// You can select all of the events (listed below) or combine them in whatever way you like but atleast one event must be used. Otherwise, the webhook won't be created.
        /// A webhook will be triggered when any one or more of the events occur:
        /// + **SMS**
        ///     + `RECEIVED_SMS` Receive an SMS
        ///     + `OPT_OUT_SMS` Opt-out occured
        /// + **MMS**
        ///     + `RECEIVED_MMS` Receive an MMS
        /// + **DR (Delivery Reports)**
        ///     + `ENROUTE_DR` Message is enroute
        ///     + `EXPIRED_DR` Message has expired
        ///     + `REJECTED_DR` Message is rejected
        ///     + `FAILED_DR` Message has failed 
        ///     + `DELIVERED_DR` Message is delivered
        ///     + `SUBMITTED_DR` Message is submitted
        /// #### Template Parameters
        /// You can choose what to include in the data that will be sent as the payload via the Webhook.
        /// Keep in my mind, you must escape the JSON in the template value (see example above).
        /// The table illustrates a list of all the parameters that can be included in the template and which event types it can be applied to.
        /// | Data  | Parameter Name | Example | Event Type |
        /// |:--|--|--|--|--|
        /// | **Service Type**  | $type| `SMS` | `DR` `MO` `MO MMS` |
        /// | **Message ID**  | $mtId, $messageId| `877c19ef-fa2e-4cec-827a-e1df9b5509f7` | `DR` `MO` `MO MMS`|
        /// | **Delivery Report ID** |$drId, $reportId| `01e1fa0a-6e27-4945-9cdb-18644b4de043` | `DR` |
        /// | **Reply ID**| $moId, $replyId| `a175e797-2b54-468b-9850-41a3eab32f74` | `MO` `MO MMS` |
        /// | **Account ID**  | $accountId| `DeveloperPortal7000` | `DR` `MO` `MO MMS` |
        /// | **Message Timestamp**  | $submittedTimestamp| `2016-12-07T08:43:00.850Z` | `DR` `MO` `MO MMS` |
        /// | **Provider Timestamp**  | $receivedTimestamp| `2016-12-07T08:44:00.850Z` | `DR` `MO` `MO MMS` |
        /// | **Message Status** | $status| `enroute` | `DR` |
        /// | **Status Code**  | $statusCode| `200` | `DR` |
        /// | **External Metadata** | $metadata.get('key')| `name` | `DR` `MO` `MO MMS` |
        /// | **Source Address**| $sourceAddress| `+61491570156` | `DR` `MO` `MO MMS` |
        /// | **Destination Address**| $destinationAddress| `+61491593156` | `MO` `MO MMS` |
        /// | **Message Content**| $mtContent, $messageContent| `Hi Derp` | `DR` `MO` `MO MMS` |
        /// | **Reply Content**| $moContent, $replyContent| `Hello Derpina` | `MO` `MO MMS` |
        /// | **Retry Count**| $retryCount| `1` | `DR` `MO` `MO MMS` |
        /// *Note: A 400 response will be returned if the `url` is invalid, the `events`, `encoding` or `method` is null or the `headers` has a Content-Type  attribute.*
        /// </summary>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the dynamic response from the API call</return>
        Task<dynamic> CreateWebhookAsync(Models.CreateWebhookRequest body);

        /// <summary>
        /// Retrieve all the webhooks created for the connected account.
        /// A successful request to the retrieve webhook endpoint will return a response body as follows:
        /// ```
        /// {
        ///     "page": 0,
        ///     "pageSize": 100,
        ///     "pageData": [
        ///         {
        ///             "url": "https://webhook.com",
        ///             "method": "POST",
        ///             "id": "8805c9d8-bef7-41c7-906a-69ede93aa024",
        ///             "encoding": "JSON",
        ///             "events": [
        ///                 "RECEIVED_SMS"
        ///             ],
        ///             "headers": {},
        ///             "template": "{\"id\":\"$mtId\", \"status\":\"$statusCode\"}"
        ///         }
        ///     ]
        /// }
        /// ```
        /// *Note: Response 400 is returned when the `page` query parameter is not valid or the `pageSize` query parameter is not valid.*
        /// </summary>
        /// <param name="page">Optional parameter: Example: </param>
        /// <param name="pageSize">Optional parameter: Example: </param>
        /// <return>Returns the dynamic response from the API call</return>
        dynamic RetrieveWebhook(int? page = null, int? pageSize = null);

        /// <summary>
        /// Retrieve all the webhooks created for the connected account.
        /// A successful request to the retrieve webhook endpoint will return a response body as follows:
        /// ```
        /// {
        ///     "page": 0,
        ///     "pageSize": 100,
        ///     "pageData": [
        ///         {
        ///             "url": "https://webhook.com",
        ///             "method": "POST",
        ///             "id": "8805c9d8-bef7-41c7-906a-69ede93aa024",
        ///             "encoding": "JSON",
        ///             "events": [
        ///                 "RECEIVED_SMS"
        ///             ],
        ///             "headers": {},
        ///             "template": "{\"id\":\"$mtId\", \"status\":\"$statusCode\"}"
        ///         }
        ///     ]
        /// }
        /// ```
        /// *Note: Response 400 is returned when the `page` query parameter is not valid or the `pageSize` query parameter is not valid.*
        /// </summary>
        /// <param name="page">Optional parameter: Example: </param>
        /// <param name="pageSize">Optional parameter: Example: </param>
        /// <return>Returns the dynamic response from the API call</return>
        Task<dynamic> RetrieveWebhookAsync(int? page = null, int? pageSize = null);

        /// <summary>
        /// Delete a webhook that was previously created for the connected account.
        /// A webhook can be cancelled by appending the UUID of the webhook to the endpoint and submitting a DELETE request to the /webhooks/messages endpoint.
        /// *Note: Only pre-created webhooks can be deleted. If an invalid or non existent webhook ID parameter is specified in the request, then a HTTP 404 Not Found response will be returned.*
        /// </summary>
        /// <param name="webhookId">Required parameter: Example: </param>
        /// <return>Returns the void response from the API call</return>
        void DeleteWebhook(String webhookId);

        /// <summary>
        /// Delete a webhook that was previously created for the connected account.
        /// A webhook can be cancelled by appending the UUID of the webhook to the endpoint and submitting a DELETE request to the /webhooks/messages endpoint.
        /// *Note: Only pre-created webhooks can be deleted. If an invalid or non existent webhook ID parameter is specified in the request, then a HTTP 404 Not Found response will be returned.*
        /// </summary>
        /// <param name="webhookId">Required parameter: Example: </param>
        /// <return>Returns the void response from the API call</return>
        Task DeleteWebhookAsync(String webhookId);

        /// <summary>
        /// Update a webhook. You can update individual attributes or all of them by submitting a PATCH request to the /webhooks/messages endpoint (the same endpoint used above to delete a webhook)
        /// A successful request to the retrieve webhook endpoint will return a response body as follows:
        /// ```
        /// {
        ///     "url": "https://webhook.com",
        ///     "method": "POST",
        ///     "id": "04442623-0961-464e-9cbc-ec50804e0413",
        ///     "encoding": "JSON",
        ///     "events": [
        ///         "RECEIVED_SMS"
        ///     ],
        ///     "headers": {},
        ///     "template": "{\"id\":\"$mtId\", \"status\":\"$statusCode\"}"
        /// }
        /// ```
        /// *Note: Only pre-created webhooks can be deleted. If an invalid or non existent webhook ID parameter is specified in the request, then a HTTP 404 Not Found response will be returned.*
        /// </summary>
        /// <param name="webhookId">Required parameter: Example: </param>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the dynamic response from the API call</return>
        dynamic UpdateWebhook(Guid webhookId, Models.UpdateWebhookRequest body);

        /// <summary>
        /// Update a webhook. You can update individual attributes or all of them by submitting a PATCH request to the /webhooks/messages endpoint (the same endpoint used above to delete a webhook)
        /// A successful request to the retrieve webhook endpoint will return a response body as follows:
        /// ```
        /// {
        ///     "url": "https://webhook.com",
        ///     "method": "POST",
        ///     "id": "04442623-0961-464e-9cbc-ec50804e0413",
        ///     "encoding": "JSON",
        ///     "events": [
        ///         "RECEIVED_SMS"
        ///     ],
        ///     "headers": {},
        ///     "template": "{\"id\":\"$mtId\", \"status\":\"$statusCode\"}"
        /// }
        /// ```
        /// *Note: Only pre-created webhooks can be deleted. If an invalid or non existent webhook ID parameter is specified in the request, then a HTTP 404 Not Found response will be returned.*
        /// </summary>
        /// <param name="webhookId">Required parameter: Example: </param>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the dynamic response from the API call</return>
        Task<dynamic> UpdateWebhookAsync(Guid webhookId, Models.UpdateWebhookRequest body);

    }
} 