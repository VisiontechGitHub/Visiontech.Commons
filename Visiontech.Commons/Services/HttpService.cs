using Org.Visiontech.Commons.Models;
using System.Net.Http;
using VisiontechCommons;

namespace Org.Visiontech.Commons.Services
{
    public abstract class HttpService
    {

        public IProvider<HttpClient> HttpClientProvider { get; }

        public HttpService()
        {
            HttpClientProvider = Container.ServiceProvider.GetService(typeof(IProvider<HttpClient>)) as IProvider<HttpClient>;
        }

    }
}
