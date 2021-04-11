using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TakeHomeTest.UI.Web.Shared;

namespace TakeHomeTest.UI.Web.Controllers.API
{
    public class ProcessBase
    {
        private static readonly HttpClient _httpClient;

        protected HttpClient HTTPClient = _httpClient;

        public string Url { get; set; }

        static  ProcessBase()
        {
            _httpClient = new HttpClient(new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
           
        }

        /// <summary>
        /// Initialize a new instance of ControllerBase.
        /// </summary>
        //private  string _apiUrl;

        public ProcessBase()
        {
            Url = "https://localhost:5500/clock/";
        }
        protected HttpRequestMessage InitializeRequest(HttpMethod httpMethod, string serviceUrl)
        {
            //return new HttpRequestMessage(httpMethod, "{Url}{serviceUrl}");
            return new HttpRequestMessage(httpMethod, Url + serviceUrl);
            
        }

        protected HttpRequestMessage InitializeRequest<T>(HttpMethod httpMethod, string serviceUrl, T content)
        {
            //var httpRequestMessage = new HttpRequestMessage(httpMethod, "{Url}{serviceUrl}");
            var httpRequestMessage = new HttpRequestMessage(httpMethod, Url + serviceUrl);

            httpRequestMessage.Content = new ObjectContent<T>(content, new JsonMediaTypeFormatter(), (MediaTypeHeaderValue)null);

            return httpRequestMessage;
        }

        /// <summary>
        /// To verify the service call status.
        /// </summary>
        /// <param name="httpResponseMessage">Response message from calling service.</param>
        protected void VerifyStatusCode(HttpResponseMessage httpResponseMessage)
        {
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = httpResponseMessage.StatusCode,
                    ReasonPhrase = httpResponseMessage.ReasonPhrase
                };

                throw new HttpResponseException(httpError);
            }
        }

        /// <summary>
        /// To verify the service call status and get the result from the service.
        /// </summary>
        /// <typeparam name="T">Data type / object returned by service</typeparam>
        /// <param name="httpResponseMessage">Response message from calling service.</param>
        /// <returns>Result from the service</returns>
        protected T VerifyStatusCodeAsync<T>(HttpResponseMessage httpResponseMessage)
        {
            VerifyStatusCode(httpResponseMessage);

            return httpResponseMessage.Content.ReadAsAsync<T>().Result;
        }

    }
}
