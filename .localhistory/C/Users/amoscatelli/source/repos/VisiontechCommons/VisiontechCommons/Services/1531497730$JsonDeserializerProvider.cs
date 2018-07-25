using Org.Visiontech.Commons.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Org.Visiontech.Commons.Json.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using VisiontechCommons;

namespace Org.Visiontech.Commons
{

    public class JsonDeserializerProvider : IJsonDeserializerProvider
    {

        public JsonSerializer Provided { get; }


        static JsonDeserializerProvider()
        {
            Container.services.AddSingleton<IProvider<JsonSerializer>, JsonDeserializerProvider>();
        }

        public JsonDeserializerProvider()
        {

            var subtypes = typeof(JsonbPolimorphic).Assembly.GetTypes().Where(type => typeof(JsonbPolimorphic).IsAssignableFrom(type)).ToArray();

            IDictionary<Type, string> mappping = new Dictionary<Type, string>();

            foreach (Type type in subtypes) {
                if (type.IsGenericType) {
                    mappping.Add(type, type.Name.Split('`')[0]);
                } else
                {
                    mappping.Add(type, type.Name);
                }
            }

            ISerializationBinder polymorphicSerializationBinder = new CustomSerializationBinder(mappping);

            Provided = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                TypeNameHandling = TypeNameHandling.Objects,
                SerializationBinder = polymorphicSerializationBinder,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

    }

}
