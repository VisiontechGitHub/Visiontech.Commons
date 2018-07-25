﻿using Org.Visiontech.Commons.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace Org.Visiontech.Commons
{
    public abstract class HttpService
    {

        public IProvider<HttpClient> HttpClientProvider { get; }

        public HttpService()
        {
            HttpClientProvider = App.Container.GetService(typeof(IProvider<HttpClient>)) as IProvider<HttpClient>;
        }

    }
}
