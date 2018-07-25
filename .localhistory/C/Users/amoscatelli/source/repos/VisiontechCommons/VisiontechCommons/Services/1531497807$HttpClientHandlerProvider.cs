using Org.Visiontech.Commons.Models;
using System.Net.Http;

namespace Org.Visiontech.Commons.Services
{
    public class HttpClientHandlerProvider : IProvider<HttpClientHandler>
    {
        public HttpClientHandler Provided { get; }

        public HttpClientHandlerProvider()
        {

            Provided = new HttpClientHandler()
            {
                UseCookies = true
            };

        }
    }
}
