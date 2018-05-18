# Getting started

TODO: Add a description

## How to Build

The generated code uses the Newtonsoft Json.NET NuGet Package. If the automatic NuGet package restore
is enabled, these dependencies will be installed automatically. Therefore,
you will need internet access for build.

"This library requires Visual Studio 2017 for compilation."
1. Open the solution (MessageMediaWebhooks.sln) file.
2. Invoke the build process using `Ctrl+Shift+B` shortcut key or using the `Build` menu as shown below.

![Building SDK using Visual Studio](https://apidocs.io/illustration/cs?step=buildSDK&workspaceFolder=MessageMediaWebhooks-CSharp&workspaceName=MessageMediaWebhooks&projectName=MessageMediaWebhooks.Tests)

## How to Use

The build process generates a portable class library, which can be used like a normal class library. The generated library is compatible with Windows Forms, Windows RT, Windows Phone 8,
Silverlight 5, Xamarin iOS, Xamarin Android and Mono. More information on how to use can be found at the [MSDN Portable Class Libraries documentation](http://msdn.microsoft.com/en-us/library/vstudio/gg597391%28v=vs.100%29.aspx).

The following section explains how to use the MessageMediaWebhooks library in a new console project.

### 1. Starting a new project

For starting a new project, right click on the current solution from the *solution explorer* and choose  ``` Add -> New Project ```.

![Add a new project in the existing solution using Visual Studio](https://apidocs.io/illustration/cs?step=addProject&workspaceFolder=MessageMediaWebhooks-CSharp&workspaceName=MessageMediaWebhooks&projectName=MessageMediaWebhooks.Tests)

Next, choose "Console Application", provide a ``` TestConsoleProject ``` as the project name and click ``` OK ```.

![Create a new console project using Visual Studio](https://apidocs.io/illustration/cs?step=createProject&workspaceFolder=MessageMediaWebhooks-CSharp&workspaceName=MessageMediaWebhooks&projectName=MessageMediaWebhooks.Tests)

### 2. Set as startup project

The new console project is the entry point for the eventual execution. This requires us to set the ``` TestConsoleProject ``` as the start-up project. To do this, right-click on the  ``` TestConsoleProject ``` and choose  ``` Set as StartUp Project ``` form the context menu.

![Set the new cosole project as the start up project](https://apidocs.io/illustration/cs?step=setStartup&workspaceFolder=MessageMediaWebhooks-CSharp&workspaceName=MessageMediaWebhooks&projectName=MessageMediaWebhooks.Tests)

### 3. Add reference of the library project

In order to use the MessageMediaWebhooks library in the new project, first we must add a projet reference to the ``` TestConsoleProject ```. First, right click on the ``` References ``` node in the *solution explorer* and click ``` Add Reference... ```.

![Open references of the TestConsoleProject](https://apidocs.io/illustration/cs?step=addReference&workspaceFolder=MessageMediaWebhooks-CSharp&workspaceName=MessageMediaWebhooks&projectName=MessageMediaWebhooks.Tests)

Next, a window will be displayed where we must set the ``` checkbox ``` on ``` MessageMediaWebhooks.Tests ``` and click ``` OK ```. By doing this, we have added a reference of the ```MessageMediaWebhooks.Tests``` project into the new ``` TestConsoleProject ```.

![Add a reference to the TestConsoleProject](https://apidocs.io/illustration/cs?step=createReference&workspaceFolder=MessageMediaWebhooks-CSharp&workspaceName=MessageMediaWebhooks&projectName=MessageMediaWebhooks.Tests)

### 4. Write sample code

Once the ``` TestConsoleProject ``` is created, a file named ``` Program.cs ``` will be visible in the *solution explorer* with an empty ``` Main ``` method. This is the entry point for the execution of the entire solution.
Here, you can add code to initialize the client library and acquire the instance of a *Controller* class. Sample code to initialize the client library and using controller methods is given in the subsequent sections.

![Add a reference to the TestConsoleProject](https://apidocs.io/illustration/cs?step=addCode&workspaceFolder=MessageMediaWebhooks-CSharp&workspaceName=MessageMediaWebhooks&projectName=MessageMediaWebhooks.Tests)

## How to Test

The generated SDK also contain one or more Tests, which are contained in the Tests project.
In order to invoke these test cases, you will need *NUnit 3.0 Test Adapter Extension for Visual Studio*.
Once the SDK is complied, the test cases should appear in the Test Explorer window.
Here, you can click *Run All* to execute these test cases.

## Initialization

### Authentication
In order to setup authentication and initialization of the API client, you need the following information.

| Parameter | Description |
|-----------|-------------|
| basicAuthUserName | The username to use with basic authentication |
| basicAuthPassword | The password to use with basic authentication |



API client can be initialized as following.

```csharp
// Configuration parameters and credentials
string basicAuthUserName = "basicAuthUserName"; // The username to use with basic authentication
string basicAuthPassword = "basicAuthPassword"; // The password to use with basic authentication

MessageMediaWebhooksClient client = new MessageMediaWebhooksClient(basicAuthUserName, basicAuthPassword);
```



# Class Reference

## <a name="list_of_controllers"></a>List of Controllers

* [APIController](#api_controller)

## <a name="api_controller"></a>![Class: ](https://apidocs.io/img/class.png "MessageMedia.Webhooks.Controllers.APIController") APIController

### Get singleton instance

The singleton instance of the ``` APIController ``` class can be accessed from the API Client.

```csharp
APIController client = client.Client;
```

### <a name="create_webhook"></a>![Method: ](https://apidocs.io/img/method.png "MessageMedia.Webhooks.Controllers.APIController.CreateWebhook") CreateWebhook

> Create a webhook for one or more of the specified events.
> A webhook would typically have the following structure:
> ```
> {
>   "url": "http://webhook.com",
>   "method": "POST",
>   "encoding": "JSON",
>   "headers": {
>     "Account": "DeveloperPortal7000"
>   },
>   "events": [
>     "RECEIVED_SMS"
>   ],
>   "template": "{\"id\":\"$mtId\",\"status\":\"$statusCode\"}"
> }
> ```
> A valid webhook must consist of the following properties:
> - ```url``` The configured URL which will trigger the webhook when a selected event occurs.
> - ```method``` The methods to map CRUD (create, retrieve, update, delete) operations to HTTP requests.
> - ```encoding``` The format in which the payload will be returned. You can choose from ```JSON```, ```FORM_ENCODED``` or ```XML```. This will automatically add the Content-Type header for you so you don't have to add it again in the `headers` property.
> - ```headers``` HTTP header fields which provide required information about the request or response, or about the object sent in the message body. This should not include the `Content-Type` header.
> - ```events``` Event or events that will trigger the webhook. Atleast one event should be present.
> - ```template``` The structure of the payload that will be returned.
> #### Types of Events
> You can select all of the events (listed below) or combine them in whatever way you like but atleast one event must be used. Otherwise, the webhook won't be created.
> A webhook will be triggered when any one or more of the events occur:
> + **SMS**
>     + `RECEIVED_SMS` Receive an SMS
>     + `OPT_OUT_SMS` Opt-out occured
> + **MMS**
>     + `RECEIVED_MMS` Receive an MMS
> + **DR (Delivery Reports)**
>     + `ENROUTE_DR` Message is enroute
>     + `EXPIRED_DR` Message has expired
>     + `REJECTED_DR` Message is rejected
>     + `FAILED_DR` Message has failed 
>     + `DELIVERED_DR` Message is delivered
>     + `SUBMITTED_DR` Message is submitted
> #### Template Parameters
> You can choose what to include in the data that will be sent as the payload via the Webhook.
> Keep in my mind, you must escape the JSON in the template value (see example above).
> The table illustrates a list of all the parameters that can be included in the template and which event types it can be applied to.
> | Data  | Parameter Name | Example | Event Type |
> |:--|--|--|--|--|
> | **Service Type**  | $type| `SMS` | `DR` `MO` `MO MMS` |
> | **Message ID**  | $mtId, $messageId| `877c19ef-fa2e-4cec-827a-e1df9b5509f7` | `DR` `MO` `MO MMS`|
> | **Delivery Report ID** |$drId, $reportId| `01e1fa0a-6e27-4945-9cdb-18644b4de043` | `DR` |
> | **Reply ID**| $moId, $replyId| `a175e797-2b54-468b-9850-41a3eab32f74` | `MO` `MO MMS` |
> | **Account ID**  | $accountId| `DeveloperPortal7000` | `DR` `MO` `MO MMS` |
> | **Message Timestamp**  | $submittedTimestamp| `2016-12-07T08:43:00.850Z` | `DR` `MO` `MO MMS` |
> | **Provider Timestamp**  | $receivedTimestamp| `2016-12-07T08:44:00.850Z` | `DR` `MO` `MO MMS` |
> | **Message Status** | $status| `enroute` | `DR` |
> | **Status Code**  | $statusCode| `200` | `DR` |
> | **External Metadata** | $metadata.get('key')| `name` | `DR` `MO` `MO MMS` |
> | **Source Address**| $sourceAddress| `+61491570156` | `DR` `MO` `MO MMS` |
> | **Destination Address**| $destinationAddress| `+61491593156` | `MO` `MO MMS` |
> | **Message Content**| $mtContent, $messageContent| `Hi Derp` | `DR` `MO` `MO MMS` |
> | **Reply Content**| $moContent, $replyContent| `Hello Derpina` | `MO` `MO MMS` |
> | **Retry Count**| $retryCount| `1` | `DR` `MO` `MO MMS` |
> *Note: A 400 response will be returned if the `url` is invalid, the `events`, `encoding` or `method` is null or the `headers` has a Content-Type  attribute.*


```csharp
Task<dynamic> CreateWebhook(Webhooks.Models.CreateWebhookRequest body)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| body |  ``` Required ```  | TODO: Add a parameter description |


#### Example Usage

```csharp
var body = new Webhooks.Models.CreateWebhookRequest();

dynamic result = await client.CreateWebhook(body);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | Unexpected error in API call. See HTTP response body for details. |
| 409 | Unexpected error in API call. See HTTP response body for details. |


### <a name="retrieve_webhook"></a>![Method: ](https://apidocs.io/img/method.png "MessageMedia.Webhooks.Controllers.APIController.RetrieveWebhook") RetrieveWebhook

> Retrieve all the webhooks created for the connected account.
> A successful request to the retrieve webhook endpoint will return a response body as follows:
> ```
> {
>     "page": 0,
>     "pageSize": 100,
>     "pageData": [
>         {
>             "url": "https://webhook.com",
>             "method": "POST",
>             "id": "8805c9d8-bef7-41c7-906a-69ede93aa024",
>             "encoding": "JSON",
>             "events": [
>                 "RECEIVED_SMS"
>             ],
>             "headers": {},
>             "template": "{\"id\":\"$mtId\", \"status\":\"$statusCode\"}"
>         }
>     ]
> }
> ```
> *Note: Response 400 is returned when the `page` query parameter is not valid or the `pageSize` query parameter is not valid.*


```csharp
Task<dynamic> RetrieveWebhook(string page = null, string pageSize = null)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| page |  ``` Optional ```  | TODO: Add a parameter description |
| pageSize |  ``` Optional ```  | TODO: Add a parameter description |


#### Example Usage

```csharp
string page = "page";
string pageSize = "pageSize";

dynamic result = await client.RetrieveWebhook(page, pageSize);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | Unexpected error in API call. See HTTP response body for details. |


### <a name="delete_webhook"></a>![Method: ](https://apidocs.io/img/method.png "MessageMedia.Webhooks.Controllers.APIController.DeleteWebhook") DeleteWebhook

> Delete a webhook that was previously created for the connected account.
> A webhook can be cancelled by appending the UUID of the webhook to the endpoint and submitting a DELETE request to the /webhooks/messages endpoint.
> *Note: Only pre-created webhooks can be deleted. If an invalid or non existent webhook ID parameter is specified in the request, then a HTTP 404 Not Found response will be returned.*


```csharp
Task DeleteWebhook(Guid webhookId)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| webhookId |  ``` Required ```  | TODO: Add a parameter description |


#### Example Usage

```csharp
Guid webhookId = a7f11bb0-f299-4861-a5ca-9b29d04bc5ad;

await client.DeleteWebhook(webhookId);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 404 | TODO: Add an error description |


### <a name="update_webhook"></a>![Method: ](https://apidocs.io/img/method.png "MessageMedia.Webhooks.Controllers.APIController.UpdateWebhook") UpdateWebhook

> Update a webhook. You can update all the attributes individually or together by submitting a PATCH request to the /webhooks/messages endpoint (the same endpoint used above to delete a webhook)
> A successful request to the retrieve webhook endpoint will return a response body as follows:
> ```
> {
>     "url": "https://webhook.com",
>     "method": "POST",
>     "id": "04442623-0961-464e-9cbc-ec50804e0413",
>     "encoding": "JSON",
>     "events": [
>         "RECEIVED_SMS"
>     ],
>     "headers": {},
>     "template": "{\"id\":\"$mtId\", \"status\":\"$statusCode\"}"
> }
> ```
> *Note: Only pre-created webhooks can be deleted. If an invalid or non existent webhook ID parameter is specified in the request, then a HTTP 404 Not Found response will be returned.*


```csharp
Task<dynamic> UpdateWebhook(Guid webhookId, Webhooks.Models.UpdateWebhookRequest body)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| webhookId |  ``` Required ```  | TODO: Add a parameter description |
| body |  ``` Required ```  | TODO: Add a parameter description |


#### Example Usage

```csharp
Guid webhookId = a7f11bb0-f299-4861-a5ca-9b29d04bc5ad;
string bodyValue = "    {        \"url\": \"https://myurl.com\",        \"method\": \"POST\",        \"encoding\": \"FORM_ENCODED\",        \"events\": [            \"ENROUTE_DR\"        ],        \"template\": \"{\\\"id\\\":\\\"$mtId\\\", \\\"status\\\":\\\"$statusCode\\\"}\"    }";
var body = Newtonsoft.Json.JsonConvert.DeserializeObject<Webhooks.Models.UpdateWebhookRequest>(bodyValue);

dynamic result = await client.UpdateWebhook(webhookId, body);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | Unexpected error in API call. See HTTP response body for details. |
| 404 | TODO: Add an error description |


[Back to List of Controllers](#list_of_controllers)



