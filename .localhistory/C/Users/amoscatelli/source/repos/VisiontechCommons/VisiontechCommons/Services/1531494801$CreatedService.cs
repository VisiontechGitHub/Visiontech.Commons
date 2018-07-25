using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Org.Visiontech.Commons.Models;
using Org.Visiontech.Commons.Dto.Api;

namespace Org.Visiontech.Commons.Services
{
    public abstract class CreatedService<D> : IdentifiableService<D>, ICreatedService<D> where D : CreatedDTO
    {

        public CreatedService(string path) : base(path) {
        }

        public async Task<ICollection<D>> post(ICollection<D> resources)
        {

            StringWriter stringWriter = new StringWriter();

            JsonSerializer.Provided.Serialize(new CustomJsonWriter(stringWriter), resources);

            var content = new StringContent(stringWriter.ToString(), Encoding.UTF8, "application/json");

            var response = await HttpClientProvider.Provided.PostAsync(Uri, content);

            if (response.IsSuccessStatusCode)
            {
                using (var stringReader = new StringReader(await response.Content.ReadAsStringAsync()))
                using (var jsonReader = new CustomJsonReader(stringReader))
                {
                    return JsonSerializer.Provided.Deserialize<ICollection<D>>(jsonReader);
                }
            }

            return new Collection<D>();

        }
    }
}
