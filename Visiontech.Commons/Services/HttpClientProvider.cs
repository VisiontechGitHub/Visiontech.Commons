using Microsoft.Extensions.DependencyInjection;
using Org.Visiontech.Commons.Models;
using System.Net.Http;
using VisiontechCommons;

namespace Org.Visiontech.Commons.Services
{

    public class HttpClientProvider : IHttpClientProvider
    {

        public string UUID = System.Guid.NewGuid().ToString();

        public HttpClient Provided { get; }

        protected readonly IProvider<HttpClientHandler> httpClientHandlerProvider = SharedServiceProvider.ServiceProvider.GetService(typeof(IProvider<HttpClientHandler>)) as IProvider<HttpClientHandler>;

        public HttpClientProvider()
        {

            Provided = new HttpClient(httpClientHandlerProvider.Provided);

        }

    }

}
