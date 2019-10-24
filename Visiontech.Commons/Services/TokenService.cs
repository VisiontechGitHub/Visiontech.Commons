using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Org.Visiontech.Commons.Services
{
    public class TokenService : HttpService, ITokenService
    {

        private readonly string url;
        private readonly string service;

        public TokenService(string url, string service)
        {
            this.url = url;
            this.service = service;
        }

        public async Task<string> GetToken(string username, string password)
        {

            IList<KeyValuePair<string, string>> tgtParameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("service", service)
            };
            HttpResponseMessage tgtHttpResponseMessage = await HttpClientProvider.Provided.PostAsync(url, new FormUrlEncodedContent(tgtParameters));

            if (!tgtHttpResponseMessage.IsSuccessStatusCode || tgtHttpResponseMessage.Headers is null || tgtHttpResponseMessage.Headers.Location is null || string.IsNullOrWhiteSpace(tgtHttpResponseMessage.Headers.Location.OriginalString)) {
                return default;
            }

            IList<KeyValuePair<string, string>> jwtParameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("service", service)
            };

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, tgtHttpResponseMessage.Headers.Location.OriginalString)
            {
                Content = new FormUrlEncodedContent(jwtParameters)
            };
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            HttpResponseMessage jwtHttpResponseMessage = await HttpClientProvider.Provided.SendAsync(request);

            if (!jwtHttpResponseMessage.IsSuccessStatusCode)
            {
                return default;
            }

            return await jwtHttpResponseMessage.Content.ReadAsStringAsync();

        }
    }
}
