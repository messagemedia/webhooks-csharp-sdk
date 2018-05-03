/*
 * MessageMediaWebhooks.PCL
 *
 * This file was automatically generated for MessageMedia by APIMATIC v2.0 ( https://apimatic.io )
 */
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

namespace MessageMedia.Webhooks.Controllers
{
    public partial class APIController: BaseController, IAPIController
    {
        #region Singleton Pattern

        //private static variables for the singleton pattern
        private static object syncObject = new object();
        private static APIController instance = null;

        /// <summary>
        /// Singleton pattern implementation
        /// </summary>
        internal static APIController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new APIController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        /// <summary>
        /// This will create a webhook for the specified `events`
        /// ### Parameters
        /// **list of supported parameters in `template` according to the message type :**
        /// you must escape the json for the template parameter. see example .
        /// | Data   | parameter name | DR| MO | MO MMS | Comment |
        /// |:--|--|--|--|--|--|
        /// | **service type**  | $type| ``OK`` |`OK`| `OK`| |
        /// | **Message ID**  | $mtId, $messageId| `OK` |`OK`| `OK`| |
        /// | **Delivery report ID** |$drId, $reportId | `OK` || | |
        /// | **Reply ID**| $moId, $replyId| |`OK`| `OK`||
        /// | **Account ID**  | $accountId| `OK` |`OK`| `OK`||
        /// | **Message Timestamp**  | $submittedTimestamp| `OK` |`OK`| `OK`||
        /// | **Provider Timestamp**  | $receivedTimestamp| `OK` |`OK`| `OK`||
        /// | **Message status** | $status| `OK` ||||
        /// | **Status code**  | $statusCode| `OK` ||||
        /// | **External metadata** | $metadata.get('key')| `OK` |`OK`| `OK`||
        /// | **Source address**| $sourceAddress| `OK` |`OK`| `OK`||
        /// | **Destination address**| $destinationAddress|  |`OK`| `OK`||
        /// | **Message content**| $mtContent, $messageContent| `OK` |`OK`| `OK`||
        /// | **Reply Content**| $moContent, $replyContent|  |`OK`| `OK`||
        /// | **Retry Count**| $retryCount| `OK` |`OK`| `OK`||
        /// **list of allowed  `events` :**
        /// you can combine all the events whatever the message type.(at least one Event set otherwise the webhook won't be created)
        /// + **events for SMS**
        ///     + `RECEIVED_SMS`
        ///     + `OPT_OUT_SMS`
        /// + **events for MMS**
        ///     + `RECEIVED_MMS`
        /// + **events for DR**
        ///     + `ENROUTE_DR`
        ///     + `EXPIRED_DR`
        ///     + `REJECTED_DR`
        ///     + `FAILED_DR`
        ///     + `DELIVERED_DR`
        ///     + `SUBMITTED_DR`
        /// a **Response 400 is returned when** :
        ///     <ul>
        ///      <li>the `url` is not valid </li>
        ///      <li>the `events` is null/empty </li>
        ///      <li>the `encoding` is null </li>
        ///      <li>the `method` is null </li>
        ///      <li>the `headers` has a `ContentType`  attribute </li>
        ///     </ul>
        /// </summary>
        /// <param name="contentType">Required parameter: Example: </param>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the dynamic response from the API call</return>
        public dynamic Create(string contentType, Models.CreateRequest body)
        {
            Task<dynamic> t = CreateAsync(contentType, body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// This will create a webhook for the specified `events`
        /// ### Parameters
        /// **list of supported parameters in `template` according to the message type :**
        /// you must escape the json for the template parameter. see example .
        /// | Data   | parameter name | DR| MO | MO MMS | Comment |
        /// |:--|--|--|--|--|--|
        /// | **service type**  | $type| ``OK`` |`OK`| `OK`| |
        /// | **Message ID**  | $mtId, $messageId| `OK` |`OK`| `OK`| |
        /// | **Delivery report ID** |$drId, $reportId | `OK` || | |
        /// | **Reply ID**| $moId, $replyId| |`OK`| `OK`||
        /// | **Account ID**  | $accountId| `OK` |`OK`| `OK`||
        /// | **Message Timestamp**  | $submittedTimestamp| `OK` |`OK`| `OK`||
        /// | **Provider Timestamp**  | $receivedTimestamp| `OK` |`OK`| `OK`||
        /// | **Message status** | $status| `OK` ||||
        /// | **Status code**  | $statusCode| `OK` ||||
        /// | **External metadata** | $metadata.get('key')| `OK` |`OK`| `OK`||
        /// | **Source address**| $sourceAddress| `OK` |`OK`| `OK`||
        /// | **Destination address**| $destinationAddress|  |`OK`| `OK`||
        /// | **Message content**| $mtContent, $messageContent| `OK` |`OK`| `OK`||
        /// | **Reply Content**| $moContent, $replyContent|  |`OK`| `OK`||
        /// | **Retry Count**| $retryCount| `OK` |`OK`| `OK`||
        /// **list of allowed  `events` :**
        /// you can combine all the events whatever the message type.(at least one Event set otherwise the webhook won't be created)
        /// + **events for SMS**
        ///     + `RECEIVED_SMS`
        ///     + `OPT_OUT_SMS`
        /// + **events for MMS**
        ///     + `RECEIVED_MMS`
        /// + **events for DR**
        ///     + `ENROUTE_DR`
        ///     + `EXPIRED_DR`
        ///     + `REJECTED_DR`
        ///     + `FAILED_DR`
        ///     + `DELIVERED_DR`
        ///     + `SUBMITTED_DR`
        /// a **Response 400 is returned when** :
        ///     <ul>
        ///      <li>the `url` is not valid </li>
        ///      <li>the `events` is null/empty </li>
        ///      <li>the `encoding` is null </li>
        ///      <li>the `method` is null </li>
        ///      <li>the `headers` has a `ContentType`  attribute </li>
        ///     </ul>
        /// </summary>
        /// <param name="contentType">Required parameter: Example: </param>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the dynamic response from the API call</return>
        public async Task<dynamic> CreateAsync(string contentType, Models.CreateRequest body)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/webooks/messages");


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "messagesmedia-webhooks" },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Content-Type", contentType }
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

        /// <summary>
        /// This will delete the webhook wuth the give id.
        /// a **Response 404 is returned when** :
        ///     <ul>
        ///      <li>there is no webhook  with this `webhookId` </li>
        ///     </ul>
        /// </summary>
        /// <param name="webhookId">Required parameter: Example: </param>
        /// <return>Returns the void response from the API call</return>
        public void DeleteDeleteAndUpdateWebhook(Guid webhookId)
        {
            Task t = DeleteDeleteAndUpdateWebhookAsync(webhookId);
            APIHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// This will delete the webhook wuth the give id.
        /// a **Response 404 is returned when** :
        ///     <ul>
        ///      <li>there is no webhook  with this `webhookId` </li>
        ///     </ul>
        /// </summary>
        /// <param name="webhookId">Required parameter: Example: </param>
        /// <return>Returns the void response from the API call</return>
        public async Task DeleteDeleteAndUpdateWebhookAsync(Guid webhookId)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/webooks/messages/{webhookId}");

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
        /// This will retrieve all webhooks for the account we're connected with.
        /// a **Response 400 is returned when** :
        ///     <ul>
        ///      <li>the `page` query parameter is not valid </li>
        ///      <li>the `pageSize` query parameter is not valid </li>
        ///     </ul>
        /// </summary>
        /// <param name="page">Optional parameter: Example: </param>
        /// <param name="pageSize">Optional parameter: Example: </param>
        /// <return>Returns the Models.RetrieveResponse response from the API call</return>
        public Models.RetrieveResponse Retrieve(int? page = null, int? pageSize = null)
        {
            Task<Models.RetrieveResponse> t = RetrieveAsync(page, pageSize);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// This will retrieve all webhooks for the account we're connected with.
        /// a **Response 400 is returned when** :
        ///     <ul>
        ///      <li>the `page` query parameter is not valid </li>
        ///      <li>the `pageSize` query parameter is not valid </li>
        ///     </ul>
        /// </summary>
        /// <param name="page">Optional parameter: Example: </param>
        /// <param name="pageSize">Optional parameter: Example: </param>
        /// <return>Returns the Models.RetrieveResponse response from the API call</return>
        public async Task<Models.RetrieveResponse> RetrieveAsync(int? page = null, int? pageSize = null)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/webooks/messages/");

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
                throw new APIException(@"", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.RetrieveResponse>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// This will update a webhook and returned the updated Webhook. 
        /// you can update all the attributes individually or together.
        /// PS : the new value will override the previous one.
        /// ### Parameters
        /// + same parameters rules as create webhook apply
        ///  a **Response 404 is returned when** :
        ///     <ul>
        ///      <li>there is no webhook with this `webhookId` </li>
        ///     </ul>   
        ///  a **Response 400 is returned when** :
        ///     <ul>
        ///       <li>all attributes are null </li>
        ///      <li>events array is empty </li>
        ///      <li>content-Type is set in the headers instead of using the `encoding` attribute  </li>
        ///     </ul>
        /// </summary>
        /// <param name="webhookId">Required parameter: Example: </param>
        /// <param name="contentType">Required parameter: Example: </param>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the void response from the API call</return>
        public void Update(Guid webhookId, string contentType, Models.UpdateRequest body)
        {
            Task t = UpdateAsync(webhookId, contentType, body);
            APIHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// This will update a webhook and returned the updated Webhook. 
        /// you can update all the attributes individually or together.
        /// PS : the new value will override the previous one.
        /// ### Parameters
        /// + same parameters rules as create webhook apply
        ///  a **Response 404 is returned when** :
        ///     <ul>
        ///      <li>there is no webhook with this `webhookId` </li>
        ///     </ul>   
        ///  a **Response 400 is returned when** :
        ///     <ul>
        ///       <li>all attributes are null </li>
        ///      <li>events array is empty </li>
        ///      <li>content-Type is set in the headers instead of using the `encoding` attribute  </li>
        ///     </ul>
        /// </summary>
        /// <param name="webhookId">Required parameter: Example: </param>
        /// <param name="contentType">Required parameter: Example: </param>
        /// <param name="body">Required parameter: Example: </param>
        /// <return>Returns the void response from the API call</return>
        public async Task UpdateAsync(Guid webhookId, string contentType, Models.UpdateRequest body)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v1/webooks/messages/{webhookId}");

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
                { "content-type", "application/json; charset=utf-8" },
                { "Content-Type", contentType }
            };

            //append body params
            var _body = APIHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PatchBody(_queryUrl, _headers, _body, Configuration.BasicAuthUserName, Configuration.BasicAuthPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 404)
                throw new APIException(@"", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

        }

    }
} 