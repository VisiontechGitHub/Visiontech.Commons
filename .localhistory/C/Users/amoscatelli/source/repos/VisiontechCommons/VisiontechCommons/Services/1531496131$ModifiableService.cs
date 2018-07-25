using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Org.Visiontech.Commons.Models;
using Newtonsoft.Json;
using Org.Visiontech.Commons.Dto.Api;

namespace Org.Visiontech.Commons
{
    public abstract class ModifiableService<D> : CreatedService<D>, IModifiableService<D> where D : ModifiableDTO
    {

        public ModifiableService(string path) : base(path) {
        }

        public async Task<ICollection<D>> put(ICollection<D> resources)
        {
            StringWriter stringWriter = new StringWriter();

            JsonSerializer.Provided.Serialize(new CustomJsonWriter(stringWriter), resources);

            var content = new StringContent(stringWriter.ToString(), Encoding.UTF8, "application/json");

            var response = await HttpClientProvider.Provided.PutAsync(Uri, content);

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
