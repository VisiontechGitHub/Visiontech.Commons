using Org.Visiontech.Commons.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Org.Visiontech.Commons.Services
{
    public abstract class HttpService
    {

        public IProvider<HttpClient> HttpClientProvider { get; }

        public HttpService()
        {
            HttpClientProvider = Container.GetService(typeof(IProvider<HttpClient>)) as IProvider<HttpClient>;
        }

    }
}
