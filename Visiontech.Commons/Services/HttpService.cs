using Microsoft.Extensions.DependencyInjection;
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
            HttpClientProvider = SharedServiceProvider.ServiceProvider.GetRequiredService<IProvider<HttpClient>>();
        }

    }
}
