using Org.Visiontech.Commons.Models;
using System.Net.Http;

namespace Org.Visiontech.Commons.Services
{
    public abstract class HttpService
    {

        public IProvider<HttpClient> HttpClientProvider { get; }

        public HttpService(IProvider<HttpClient> HttpClientProvider)
        {
            this.HttpClientProvider = HttpClientProvider;
        }

    }
}
