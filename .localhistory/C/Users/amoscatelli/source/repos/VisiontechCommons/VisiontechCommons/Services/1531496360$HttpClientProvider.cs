using Org.Visiontech.Commons.Models;
using Org.Visiontech.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Xamarin.Forms;

namespace Org.Visiontech.Commons
{

    public class HttpClientProvider : IHttpClientProvider
    {
        public HttpClient Provided { get; }

        protected readonly IProvider<HttpClientHandler> httpClientHandlerProvider = App.Container.GetService(typeof(IProvider<HttpClientHandler>)) as IProvider<HttpClientHandler>;
        public HttpClientProvider()
        {

            Provided = new HttpClient(httpClientHandlerProvider.Provided);

        }

    }

}
