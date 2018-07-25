using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Org.Visiontech.Commons.Dto.Api;
using Org.Visiontech.Commons.Models;
using Org.Visiontech.Commons.Models;

namespace Org.Visiontech.Commons
{
    public abstract class IdentifiableService<D> : RestService, IIdentifiableService<D> where D : IdentifiableDTO
    {

        public Uri FindUri { get; }

        public IdentifiableService(string path) : base(path) {

            FindUri = new Uri(string.Join("/", Uri, "find"));

        }

        public async Task<FindResultDTO> Find(ICollection<FindCriteriaDTO<D>> criterias, long quantity, long offset)
        {
            
            ICollection<KeyValuePair<string, string>> collection = new Collection<KeyValuePair<string, string>>();
            if (!ReferenceEquals(quantity, null))
            {
                collection.Add(new KeyValuePair<string, string>("quantity", quantity.ToString()));
            }
            if (!ReferenceEquals(offset, null))
            {
                collection.Add(new KeyValuePair<string, string>("offset", offset.ToString()));
            }

            var formUrlEncodedContent = new FormUrlEncodedContent(collection);

            var uriBuilder = new UriBuilder(FindUri);

            uriBuilder.Query = formUrlEncodedContent.ReadAsStringAsync().Result;

            StringWriter stringWriter = new StringWriter();

            JsonSerializer.Provided.Serialize(new CustomJsonWriter(stringWriter), criterias);

            var content = new StringContent(stringWriter.ToString(), Encoding.UTF8, "application/json");

            var response = await HttpClientProvider.Provided.PostAsync(uriBuilder.Uri, content);

            if (response.IsSuccessStatusCode)
            {

                using (var stringReader = new StringReader(await response.Content.ReadAsStringAsync()))
                using (var jsonReader = new CustomJsonReader(stringReader))
                {
                    return JsonSerializer.Provided.Deserialize<FindResultDTO>(jsonReader);
                }
            }
            else {
                Debug.WriteLine("HTTP ERROR : " + response.StatusCode);
            }

            return new FindResultDTO();

        }

    }
}
