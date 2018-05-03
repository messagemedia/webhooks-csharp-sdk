/*
 * MessageMediaWebhooks.PCL
 *
 * This file was automatically generated for MessageMedia by APIMATIC v2.0 ( https://apimatic.io )
 */
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
    public partial interface IAPIController
    {
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
        dynamic Create(string contentType, Models.CreateRequest body);

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
        Task<dynamic> CreateAsync(string contentType, Models.CreateRequest body);

        /// <summary>
        /// This will delete the webhook wuth the give id.
        /// a **Response 404 is returned when** :
        ///     <ul>
        ///      <li>there is no webhook  with this `webhookId` </li>
        ///     </ul>
        /// </summary>
        /// <param name="webhookId">Required parameter: Example: </param>
        /// <return>Returns the void response from the API call</return>
        void DeleteDeleteAndUpdateWebhook(Guid webhookId);

        /// <summary>
        /// This will delete the webhook wuth the give id.
        /// a **Response 404 is returned when** :
        ///     <ul>
        ///      <li>there is no webhook  with this `webhookId` </li>
        ///     </ul>
        /// </summary>
        /// <param name="webhookId">Required parameter: Example: </param>
        /// <return>Returns the void response from the API call</return>
        Task DeleteDeleteAndUpdateWebhookAsync(Guid webhookId);

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
        Models.RetrieveResponse Retrieve(int? page = null, int? pageSize = null);

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
        Task<Models.RetrieveResponse> RetrieveAsync(int? page = null, int? pageSize = null);

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
        void Update(Guid webhookId, string contentType, Models.UpdateRequest body);

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
        Task UpdateAsync(Guid webhookId, string contentType, Models.UpdateRequest body);

    }
} 