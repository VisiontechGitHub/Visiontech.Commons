using Org.Visiontech.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Org.Visiontech.Commons.Services
{
    public class TokenService : HttpService, ITokenService
    {
        public async Task<string> GetToken(string username, string password)
        {

            IList<KeyValuePair<string, string>> tgtParameters = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("username", username),
                        new KeyValuePair<string, string>("password", password)
                    };
            HttpResponseMessage tgtHttpResponseMessage = await HttpClientProvider.Provided.PostAsync("https://cas.dev.optoplus.cloud:8543/cas/v1/tickets", new FormUrlEncodedContent(tgtParameters));

            IList<KeyValuePair<string, string>> jwtParameters = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("service", "services.dev.optoplus.cloud/optoplus-services-web")
                    };
            HttpResponseMessage jwtHttpResponseMessage = await HttpClientProvider.Provided.PostAsync(tgtHttpResponseMessage.Headers.Location.OriginalString, new FormUrlEncodedContent(jwtParameters));

            return await jwtHttpResponseMessage.Content.ReadAsStringAsync();

        }
    }
}
