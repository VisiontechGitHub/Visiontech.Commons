using Org.Visiontech.Commons.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using VisiontechCommons;

namespace Org.Visiontech.Commons
{
    public abstract class RestService : HttpService
    {

        public static readonly string Domain = "https://services.dev.optoplus.cloud:8443/optoplus-services-web";
        public Uri Uri { get; }
        public IProvider<JsonSerializer> JsonSerializer { get; }

        public RestService(string path)
        {
            Uri = new Uri(string.Join("/", Domain, "rest", path));

            JsonSerializer = Container.ServiceProvider.GetService(typeof(IProvider<JsonSerializer>)) as IProvider<JsonSerializer>;
        }

    }
}
