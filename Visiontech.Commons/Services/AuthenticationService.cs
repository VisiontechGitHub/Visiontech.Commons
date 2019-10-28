using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Org.Visiontech.Commons.Services
{
    public class AuthenticationService : HttpService, IAuthenticationService
    {

        private readonly Uri uri;
        private readonly string service;

        public AuthenticationService(Uri uri, string service)
        {
            this.uri = uri;
            this.service = service;
        }

        public Task<string> GetServiceTicket(string ticketGrantingTicket)
        {
            IList<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("service", service)
            };

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(uri, ticketGrantingTicket))
            {
                Content = new FormUrlEncodedContent(parameters)
            };
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            Task<HttpResponseMessage> response = HttpClientProvider.Provided.SendAsync(request);

            return response.ContinueWith(result => result.Result.IsSuccessStatusCode ? result.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult() : default);
        }

        public Task<string> GetTicketGrantingTicket(string username, string password)
        {
            IList<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("service", service)
            };

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new FormUrlEncodedContent(parameters)
            };
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            Task<HttpResponseMessage> response = HttpClientProvider.Provided.SendAsync(request);

            return response.ContinueWith(result => result.Result.IsSuccessStatusCode ? result.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult() : default);
        }



        public Task<bool> VerifyTicketGrantingTicket(string ticketGrantingTicket)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(uri, ticketGrantingTicket));

            Task<HttpResponseMessage> response = HttpClientProvider.Provided.SendAsync(request);

            return response.ContinueWith(result => result.Result.IsSuccessStatusCode);
        }
    }
}
