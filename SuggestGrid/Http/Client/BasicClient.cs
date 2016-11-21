using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SuggestGrid.Http.Request;
using SuggestGrid.Http.Response;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using HttpMethod = SuggestGrid.Http.Request.HttpMethod;

namespace SuggestGrid.Http.Client
{
    public class BasicClient: IHttpClient
    {
        public static IHttpClient SharedClient { get; set; }
        private readonly HttpClient _client = new HttpClient();

        static BasicClient() {
            SharedClient = new BasicClient();
        }

        public void setTimeout(TimeSpan timeout)
        {
            _client.Timeout = timeout;
        }

        #region Execute methods

        public HttpResponse ExecuteAsString(HttpRequest request)
        {
            Task<HttpResponse> t = ExecuteAsStringAsync(request);
            Task.WaitAll(t);
            return t.Result;
        }

        public async Task<HttpResponse> ExecuteAsStringAsync(HttpRequest request)
        {
            //raise the on before request event
            RaiseOnBeforeHttpRequestEvent(request);

            HttpResponseMessage responseMessage  = await HttpResponseMessage(request);

            HttpResponse response = new HttpStringResponse
            {
                Headers = responseMessage.Headers.ToDictionary(l => l.Key, k => k.Value.First()),
                RawBody = await responseMessage.Content.ReadAsStreamAsync(),
                Body = await responseMessage.Content.ReadAsStringAsync(),
                StatusCode = (int)responseMessage.StatusCode
            };

            //raise the on after response event
            RaiseOnAfterHttpResponseEvent(response);
            return response;
        }

        public HttpResponse ExecuteAsBinary(HttpRequest request)
        {
            Task<HttpResponse> t = ExecuteAsBinaryAsync(request);
            Task.WaitAll(t);
            return t.Result;
        }

        public async Task<HttpResponse> ExecuteAsBinaryAsync(HttpRequest request)
        {
            //raise the on before request event
            RaiseOnBeforeHttpRequestEvent(request);

            HttpResponseMessage responseMessage = await HttpResponseMessage(request);

            HttpResponse response = new HttpResponse
            {
                Headers = responseMessage.Headers.ToDictionary(l => l.Key, k => k.Value.First()),
                RawBody = await responseMessage.Content.ReadAsStreamAsync(),
                StatusCode = (int)responseMessage.StatusCode
            };

            //raise the on after response event
            RaiseOnAfterHttpResponseEvent(response);
            return response;
        }

        #endregion


        #region Http request and response events

        public event OnBeforeHttpRequestEventHandler OnBeforeHttpRequestEvent;
        public event OnAfterHttpResponseEventHandler OnAfterHttpResponseEvent;

        private void RaiseOnBeforeHttpRequestEvent(HttpRequest request)
        {
            if ((null != OnBeforeHttpRequestEvent) && (null != request))
                OnBeforeHttpRequestEvent(this, request);
        }

        private void RaiseOnAfterHttpResponseEvent(HttpResponse response)
        {
            if ((null != OnAfterHttpResponseEvent) && (null != response))
                OnAfterHttpResponseEvent(this, response);
        }

        #endregion


        #region Http methods

        public HttpRequest Get(string queryUrl, Dictionary<string, string> headers, string username = null, string password = null)
        {
            return new HttpRequest(HttpMethod.GET, queryUrl, headers, username, password);
        }

        public HttpRequest Get(string queryUrl)
        {
            return new HttpRequest(HttpMethod.GET, queryUrl);
        }

        public HttpRequest Post(string queryUrl)
        {
            return new HttpRequest(HttpMethod.POST, queryUrl);
        }

        public HttpRequest Put(string queryUrl)
        {
            return new HttpRequest(HttpMethod.PUT, queryUrl);
        }

        public HttpRequest Delete(string queryUrl)
        {
            return new HttpRequest(HttpMethod.DELETE, queryUrl);
        }

        public HttpRequest Patch(string queryUrl)
        {
            return new HttpRequest(HttpMethod.PATCH, queryUrl);
        }

        public HttpRequest Post(string queryUrl, Dictionary<string, string> headers, Dictionary<string, object> formParameters, string username = null,
            string password = null)
        {
            return new HttpRequest(HttpMethod.POST, queryUrl, headers, formParameters, username, password);
        }

        public HttpRequest PostBody(string queryUrl, Dictionary<string, string> headers, string body, string username = null, string password = null)
        {
            return new HttpRequest(HttpMethod.POST, queryUrl, headers, body, username, password);
        }

        public HttpRequest Put(string queryUrl, Dictionary<string, string> headers, Dictionary<string, object> formParameters, string username = null,
            string password = null)
        {
            return new HttpRequest(HttpMethod.PUT, queryUrl, headers, formParameters, username, password);
        }

        public HttpRequest PutBody(string queryUrl, Dictionary<string, string> headers, string body, string username = null, string password = null)
        {
            return new HttpRequest(HttpMethod.PUT, queryUrl, headers, body, username, password);
        }

        public HttpRequest Patch(string queryUrl, Dictionary<string, string> headers, Dictionary<string, object> formParameters, string username = null,
            string password = null)
        {
            return new HttpRequest(HttpMethod.PATCH, queryUrl, headers, formParameters, username, password);
        }

        public HttpRequest PatchBody(string queryUrl, Dictionary<string, string> headers, string body, string username = null, string password = null)
        {
            return new HttpRequest(HttpMethod.PATCH, queryUrl, headers, body, username, password);
        }

        public HttpRequest Delete(string queryUrl, Dictionary<string, string> headers, Dictionary<string, object> formParameters, string username = null,
            string password = null)
        {
            return new HttpRequest(HttpMethod.DELETE, queryUrl, headers, formParameters, username, password);
        }

        public HttpRequest DeleteBody(string queryUrl, Dictionary<string, string> headers, string body, string username = null, string password = null)
        {
            return new HttpRequest(HttpMethod.DELETE, queryUrl, headers, body, username, password);
        }

        #endregion

        #region Helper methods

        private async Task<HttpResponseMessage> HttpResponseMessage(HttpRequest request)
        {
            HttpResponseMessage responseMessage;
                if (!string.IsNullOrEmpty(request.Username))
                {
                    var byteArray = Encoding.ASCII.GetBytes(request.Username + ":" + request.Password);
                    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(byteArray));
                }

                if (request.HttpMethod.Equals(HttpMethod.POST))
                {
                    var content = new StringContent(request.Body ?? string.Empty, Encoding.UTF8, "application/json");
                    responseMessage = await _client.PostAsync(request.QueryUrl, content);
                }
                else if (request.HttpMethod.Equals(HttpMethod.GET))
                {
                    responseMessage = await _client.GetAsync(request.QueryUrl);
                }
                else if (request.HttpMethod.Equals(HttpMethod.DELETE))
                {
                    responseMessage = await _client.DeleteAsync(request.QueryUrl);
                }
                else if (request.HttpMethod.Equals(HttpMethod.PUT))
                {
                    var content = new StringContent(request.Body ?? string.Empty, Encoding.UTF8, "application/json");
                    responseMessage = await _client.PutAsync(request.QueryUrl, content);
                }
                else
                {
                    throw new NotSupportedException("Requested HTTP method: " + request.HttpMethod + " is not supported");
                }
            return responseMessage;
        }

        #endregion
    }
}