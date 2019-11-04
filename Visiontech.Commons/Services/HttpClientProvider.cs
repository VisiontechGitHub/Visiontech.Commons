using Org.Visiontech.Commons.Models;
using System.Net.Http;

namespace Org.Visiontech.Commons.Services
{

    public class HttpClientProvider : IHttpClientProvider
    {

        public string UUID = System.Guid.NewGuid().ToString();

        public HttpClient Provided { get; }

        public HttpClientProvider(IProvider<HttpClientHandler> HttpClientHandler)
        {

            Provided = new HttpClient(HttpClientHandler.Provided);

        }

    }

}
