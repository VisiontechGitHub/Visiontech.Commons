using Org.Visiontech.Commons.Models;
using System.Net.Http;

namespace Org.Visiontech.Commons
{

    public class HttpClientProvider : IHttpClientProvider
    {
        public HttpClient Provided { get; }

        protected readonly IProvider<HttpClientHandler> httpClientHandlerProvider = Container.GetService(typeof(IProvider<HttpClientHandler>)) as IProvider<HttpClientHandler>;
        public HttpClientProvider()
        {

            Provided = new HttpClient(httpClientHandlerProvider.Provided);

        }

    }

}
