# Getting started

TODO: Add a description

## How to Build

The generated code uses the Newtonsoft Json.NET NuGet Package. If the automatic NuGet package restore
is enabled, these dependencies will be installed automatically. Therefore,
you will need internet access for build.

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
IAPIController client = client.Client;
```

### <a name="create"></a>![Method: ](https://apidocs.io/img/method.png "MessageMedia.Webhooks.Controllers.APIController.Create") Create

> This will create a webhook for the specified `events`
> ### Parameters
> **list of supported parameters in `template` according to the message type :**
> you must escape the json for the template parameter. see example .
> | Data   | parameter name | DR| MO | MO MMS | Comment |
> |:--|--|--|--|--|--|
> | **service type**  | $type| ``OK`` |`OK`| `OK`| |
> | **Message ID**  | $mtId, $messageId| `OK` |`OK`| `OK`| |
> | **Delivery report ID** |$drId, $reportId | `OK` || | |
> | **Reply ID**| $moId, $replyId| |`OK`| `OK`||
> | **Account ID**  | $accountId| `OK` |`OK`| `OK`||
> | **Message Timestamp**  | $submittedTimestamp| `OK` |`OK`| `OK`||
> | **Provider Timestamp**  | $receivedTimestamp| `OK` |`OK`| `OK`||
> | **Message status** | $status| `OK` ||||
> | **Status code**  | $statusCode| `OK` ||||
> | **External metadata** | $metadata.get('key')| `OK` |`OK`| `OK`||
> | **Source address**| $sourceAddress| `OK` |`OK`| `OK`||
> | **Destination address**| $destinationAddress|  |`OK`| `OK`||
> | **Message content**| $mtContent, $messageContent| `OK` |`OK`| `OK`||
> | **Reply Content**| $moContent, $replyContent|  |`OK`| `OK`||
> | **Retry Count**| $retryCount| `OK` |`OK`| `OK`||
> **list of allowed  `events` :**
> you can combine all the events whatever the message type.(at least one Event set otherwise the webhook won't be created)
> + **events for SMS**
>     + `RECEIVED_SMS`
>     + `OPT_OUT_SMS`
> + **events for MMS**
>     + `RECEIVED_MMS`
> + **events for DR**
>     + `ENROUTE_DR`
>     + `EXPIRED_DR`
>     + `REJECTED_DR`
>     + `FAILED_DR`
>     + `DELIVERED_DR`
>     + `SUBMITTED_DR`
> a **Response 400 is returned when** :
>     <ul>
>      <li>the `url` is not valid </li>
>      <li>the `events` is null/empty </li>
>      <li>the `encoding` is null </li>
>      <li>the `method` is null </li>
>      <li>the `headers` has a `ContentType`  attribute </li>
>     </ul>


```csharp
Task<dynamic> Create(string contentType, Webhooks.Models.CreateRequest body)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| contentType |  ``` Required ```  | TODO: Add a parameter description |
| body |  ``` Required ```  | TODO: Add a parameter description |


#### Example Usage

```csharp
string contentType = "Content-Type";
var body = new Webhooks.Models.CreateRequest();

dynamic result = await client.Create(contentType, body);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | TODO: Add an error description |


### <a name="delete_delete_and_update_webhook"></a>![Method: ](https://apidocs.io/img/method.png "MessageMedia.Webhooks.Controllers.APIController.DeleteDeleteAndUpdateWebhook") DeleteDeleteAndUpdateWebhook

> This will delete the webhook wuth the give id.
> a **Response 404 is returned when** :
>     <ul>
>      <li>there is no webhook  with this `webhookId` </li>
>     </ul>


```csharp
Task DeleteDeleteAndUpdateWebhook(Guid webhookId)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| webhookId |  ``` Required ```  | TODO: Add a parameter description |


#### Example Usage

```csharp
Guid webhookId = a7f11bb0-f299-4861-a5ca-9b29d04bc5ad;

await client.DeleteDeleteAndUpdateWebhook(webhookId);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 404 | TODO: Add an error description |


### <a name="retrieve"></a>![Method: ](https://apidocs.io/img/method.png "MessageMedia.Webhooks.Controllers.APIController.Retrieve") Retrieve

> This will retrieve all webhooks for the account we're connected with.
> a **Response 400 is returned when** :
>     <ul>
>      <li>the `page` query parameter is not valid </li>
>      <li>the `pageSize` query parameter is not valid </li>
>     </ul>


```csharp
Task<Webhooks.Models.RetrieveResponse> Retrieve(int? page = null, int? pageSize = null)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| page |  ``` Optional ```  | TODO: Add a parameter description |
| pageSize |  ``` Optional ```  | TODO: Add a parameter description |


#### Example Usage

```csharp
int? page = '1';
int? pageSize = '10';

Webhooks.Models.RetrieveResponse result = await client.Retrieve(page, pageSize);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | TODO: Add an error description |


### <a name="update"></a>![Method: ](https://apidocs.io/img/method.png "MessageMedia.Webhooks.Controllers.APIController.Update") Update

> This will update a webhook and returned the updated Webhook. 
> you can update all the attributes individually or together.
> PS : the new value will override the previous one.
> ### Parameters
> + same parameters rules as create webhook apply
>  a **Response 404 is returned when** :
>     <ul>
>      <li>there is no webhook with this `webhookId` </li>
>     </ul>   
>  a **Response 400 is returned when** :
>     <ul>
>       <li>all attributes are null </li>
>      <li>events array is empty </li>
>      <li>content-Type is set in the headers instead of using the `encoding` attribute  </li>
>     </ul>


```csharp
Task Update(Guid webhookId, string contentType, Webhooks.Models.UpdateRequest body)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| webhookId |  ``` Required ```  | TODO: Add a parameter description |
| contentType |  ``` Required ```  | TODO: Add a parameter description |
| body |  ``` Required ```  | TODO: Add a parameter description |


#### Example Usage

```csharp
Guid webhookId = Guid.NewGuid();
string contentType = "Content-Type";
var body = new Webhooks.Models.UpdateRequest();

await client.Update(webhookId, contentType, body);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 404 | TODO: Add an error description |


[Back to List of Controllers](#list_of_controllers)



