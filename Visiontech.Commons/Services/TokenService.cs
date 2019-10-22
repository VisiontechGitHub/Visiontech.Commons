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
            HttpClientProvider.Provided.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
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

            IList<KeyValuePair<string, string>> jwtParameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("service", service)
            };
            HttpResponseMessage jwtHttpResponseMessage = await HttpClientProvider.Provided.PostAsync(tgtHttpResponseMessage.Headers.Location.OriginalString, new FormUrlEncodedContent(jwtParameters));

            return await jwtHttpResponseMessage.Content.ReadAsStringAsync();

        }
    }
}
