using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Org.Visiontech.Commons.Models;
using Org.Visiontech.Commons.Dto.Api;

namespace Org.Visiontech.Commons
{
    public abstract class DeletableService<D> : ModifiableService<D>, IDeletableService<D> where D : DeletableDTO
    {

        public DeletableService(string path) : base(path) {
        }

        public async Task delete(ICollection<D> resources)
        {
            StringWriter stringWriter = new StringWriter();

            JsonSerializer.Provided.Serialize(new CustomJsonWriter(stringWriter), resources);

            var content = new StringContent(stringWriter.ToString(), Encoding.UTF8, "application/json");

            var response = await HttpClientProvider.Provided.PutAsync(Uri, content);

            if (response.IsSuccessStatusCode)
            {
                return;
            }

            return;
        }
        
    }
}
