
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using APIMATIC.SDK.Common;
using APIMATIC.SDK.Http.Request;
using APIMATIC.SDK.Http.Response;
using APIMATIC.SDK.Http.Client;
using MessageMedia.Webhooks.Exceptions;

namespace MessageMedia.Webhooks.Controllers
{
    public partial class WebhooksController: BaseController, IWebhooksController
    {
        #region Singleton Pattern

        //private static variables for the singleton pattern
        private static object syncObject = new object();
        private static WebhooksController instance = null;

        /// <summary>
        /// Singleton pattern implementation
        /// </summary>
        internal static WebhooksController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new WebhooksController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

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
        public dynamic CreateWebhook(Models.CreateWebhookRequest body)
        {
            Task<dynamic> t = CreateWebhookAsync(body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<dynamic> CreateWebhookAsync(Models.CreateWebhookRequest body)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/webhooks/messages");


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "messagesmedia-webhooks" },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" }
            };

            //append body params
            var _body = APIHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new CreateWebhook400ResponseException(@"Unexpected error in API call. See HTTP response body for details.", _context);

            if (_response.StatusCode == 409)
                throw new CreateWebhook400ResponseException(@"Unexpected error in API call. See HTTP response body for details.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<dynamic>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

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
        public dynamic RetrieveWebhook(int? page = null, int? pageSize = null)
        {
            Task<dynamic> t = RetrieveWebhookAsync(page, pageSize);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<dynamic> RetrieveWebhookAsync(int? page = null, int? pageSize = null)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/webhooks/messages/");

            //process optional query parameters
            APIHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "page", page },
                { "pageSize", pageSize }
            },ArrayDeserializationFormat,ParameterSeparator);


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "messagesmedia-webhooks" },
                { "accept", "application/json" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Get(_queryUrl,_headers, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new RetrieveWebhook400ResponseException(@"Unexpected error in API call. See HTTP response body for details.", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<dynamic>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Delete a webhook that was previously created for the connected account.
        /// A webhook can be cancelled by appending the UUID of the webhook to the endpoint and submitting a DELETE request to the /webhooks/messages endpoint.
        /// *Note: Only pre-created webhooks can be deleted. If an invalid or non existent webhook ID parameter is specified in the request, then a HTTP 404 Not Found response will be returned.*
        /// </summary>
        /// <param name="webhookId">Required parameter: Example: </param>
        /// <return>Returns the void response from the API call</return>
        public void DeleteWebhook(String webhookId)
        {
            Task t = DeleteWebhookAsync(webhookId);
            APIHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Delete a webhook that was previously created for the connected account.
        /// A webhook can be cancelled by appending the UUID of the webhook to the endpoint and submitting a DELETE request to the /webhooks/messages endpoint.
        /// *Note: Only pre-created webhooks can be deleted. If an invalid or non existent webhook ID parameter is specified in the request, then a HTTP 404 Not Found response will be returned.*
        /// </summary>
        /// <param name="webhookId">Required parameter: Example: </param>
        /// <return>Returns the void response from the API call</return>
        public async Task DeleteWebhookAsync(String webhookId)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/webhooks/messages/{webhookId}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "webhookId", webhookId }
            });


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "messagesmedia-webhooks" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Delete(_queryUrl, _headers, null, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 404)
                throw new APIException(@"", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

        }

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
        public dynamic UpdateWebhook(Guid webhookId, Models.UpdateWebhookRequest body)
        {
            Task<dynamic> t = UpdateWebhookAsync(webhookId, body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<dynamic> UpdateWebhookAsync(Guid webhookId, Models.UpdateWebhookRequest body)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/webhooks/messages/{webhookId}");

            //process optional template parameters
            APIHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "webhookId", webhookId }
            });


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "messagesmedia-webhooks" },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" }
            };

            //append body params
            var _body = APIHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PatchBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
                throw new UpdateWebhook400ResponseException(@"Unexpected error in API call. See HTTP response body for details.", _context);

            if (_response.StatusCode == 404)
                throw new APIException(@"", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<dynamic>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

    }
} 