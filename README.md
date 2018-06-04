# MessageMedia Webhooks C# SDK
[![Travis Build Status](https://api.travis-ci.org/messagemedia/webhooks-csharp-sdk.svg?branch=master)](https://travis-ci.org/messagemedia/webhooks-csharp-sdk)
[![NuGet version](https://badge.fury.io/nu/MessageMedia.SDK.Webhooks.svg)](https://badge.fury.io/nu/MessageMedia.SDK.Webhooks)

The MessageMedia Webhooks allows you to subscribe to one or several events and when one of those events is triggered, an HTTP request is sent to the URL of your choice along with the message or payload. In simpler terms, it allows applications to "speak" to one another and get notified automatically when something new happens.

## ⭐️ Installing via Nuget
Install via NuGet by:

PM> ```Install-Package MessageMedia.SDK.Webhooks```

Alternatively, right-click on your solution and click "Manage NuGet Packages...", then click browse and search for MessageMedia.

Visual Studio Mac:
Project -> Add NuGet Packages -> Search for 'MessageMedia'

## 🎬 Get Started
It's easy to get started. Simply enter the API Key and secret you obtained from the [MessageMedia Developers Portal](https://developers.messagemedia.com) into the code snippet below.

### 🚀 Create a webhook
```csharp
using System;
using MessageMedia.Webhooks;
using MessageMedia.Webhooks.Controllers;
using MessageMedia.Webhooks.Models;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuration parameters and credentials
            String basicAuthUserName = "API_KEY"; // The username to use with basic authentication
            String basicAuthPassword = "API_SECRET"; // The password to use with basic authentication

            MessageMediaWebhooksClient client = new MessageMediaWebhooksClient(basicAuthUserName, basicAuthPassword);

            IWebhooksController webhooks = client.Webhooks;

            string bodyValue = "{" +
                "\"url\": \"https://webhook.com\"," +
                "\"method\": \"POST\"," +
                "\"encoding\": \"JSON\"," +
                "\"events\": [\"RECEIVED_SMS\"]," +
                "\"template\": \"{\\\"id\\\":\\\"$mtId\\\", \\\"status\\\":\\\"$statusCode\\\"}\"" +
            "}";

            var body = Newtonsoft.Json.JsonConvert.DeserializeObject<CreateWebhookRequest>(bodyValue);

            dynamic result = webhooks.CreateWebhook(body);

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}

```

### 📥 Retrieve all webhooks
```csharp
using System;
using MessageMedia.Webhooks;
using MessageMedia.Webhooks.Controllers;
using MessageMedia.Webhooks.Models;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuration parameters and credentials
            String basicAuthUserName = "API_KEY"; // The username to use with basic authentication
            String basicAuthPassword = "API_SECRET"; // The password to use with basic authentication

            MessageMediaWebhooksClient client = new MessageMediaWebhooksClient(basicAuthUserName, basicAuthPassword);

            IWebhooksController webhooks = client.Webhooks;

            int? page = 0;
            int? pageSize = 0;

            dynamic result = webhooks.RetrieveWebhook(page, pageSize);

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}


```

### 🔄 Update a webhook
You can get a webhook ID by looking at the `id` of each webhook created from the response of the above example.
```csharp
using System;
using MessageMedia.Webhooks;
using MessageMedia.Webhooks.Controllers;
using MessageMedia.Webhooks.Models;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuration parameters and credentials
            String basicAuthUserName = "API_KEY"; // The username to use with basic authentication
            String basicAuthPassword = "API_SECRET"; // The password to use with basic authentication

            MessageMediaWebhooksClient client = new MessageMediaWebhooksClient(basicAuthUserName, basicAuthPassword);

            IWebhooksController webhooks = client.Webhooks;

            Guid webhookId = "WEBHOOK_ID";

            string bodyValue = "{" +
                "\"url\": \"https://myurl.com\"," +
                "\"method\": \"POST\"," +
                "\"encoding\": \"FORM_ENCODED\"," +
                "\"events\": [\"ENROUTE_DR\"]," +
                "\"template\": \"{\\\"id\\\":\\\"$mtId\\\", \\\"status\\\":\\\"$statusCode\\\"}\"" +
                "}";

            var body = Newtonsoft.Json.JsonConvert.DeserializeObject<Webhooks.Models.UpdateWebhookRequest>(bodyValue);

            dynamic result = await webhooks.UpdateWebhook(webhookId, body);

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}


```

### ❌ Delete a webhook
You can get a webhook ID by looking at the `id` of each webhook created from the response of the retrieve webhooks example.
```csharp
using System;
using MessageMedia.Webhooks;
using MessageMedia.Webhooks.Controllers;
using MessageMedia.Webhooks.Models;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuration parameters and credentials
            String basicAuthUserName = "API_KEY"; // The username to use with basic authentication
            String basicAuthPassword = "API_SECRET"; // The password to use with basic authentication

            MessageMediaWebhooksClient client = new MessageMediaWebhooksClient(basicAuthUserName, basicAuthPassword);

            IWebhooksController webhooks = client.Webhooks;

            Guid webhookId = "WEBHOOK_ID";

            webhooks.DeleteWebhook(webhookId);
        }
    }
}


```

## 📕 Documentation
Check out the [full API documentation](DOCUMENTATION.md) for more detailed information.

## 😕 Need help?
Please contact developer support at developers@messagemedia.com or check out the developer portal at [developers.messagemedia.com](https://developers.messagemedia.com/)

## 📃 License
Apache License. See the [LICENSE](LICENSE) file.
