/*
 * MessageMediaWebhooks.Tests
 *
 * This file was automatically generated for MessageMedia by APIMATIC v2.0 ( https://apimatic.io )
 */
using MessageMedia.Webhooks.Http.Client;
using MessageMedia.Webhooks.Http.Request;
using MessageMedia.Webhooks.Http.Response;

namespace MessageMedia.Webhooks.Helpers
{
    public class HttpCallBackEventsHandler
    {
        public HttpRequest Request { get; private set; }

        public HttpResponse Response { get; private set; }

        public void OnBeforeHttpRequestEventHandler(IHttpClient source, HttpRequest request)
        {
            this.Request = request;
        }

        public void OnAfterHttpResponseEventHandler(IHttpClient source, HttpResponse response)
        {
            this.Response = response;
        }
    }
}
