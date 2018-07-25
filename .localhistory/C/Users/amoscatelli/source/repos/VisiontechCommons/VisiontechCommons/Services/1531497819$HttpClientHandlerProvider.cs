using Org.Visiontech.Commons.Models;
using System.Net.Http;
using VisiontechCommons;

namespace Org.Visiontech.Commons.Services
{
    public class HttpClientHandlerProvider : IProvider<HttpClientHandler>
    {
        public HttpClientHandler Provided { get; }

        static HttpClientHandlerProvider()
        {
            Container.services.AddSingleton<IProvider<HttpClient>, HttpClientProvider>();
        }

        public HttpClientHandlerProvider()
        {

            Provided = new HttpClientHandler()
            {
                UseCookies = true
            };

        }
    }
}
