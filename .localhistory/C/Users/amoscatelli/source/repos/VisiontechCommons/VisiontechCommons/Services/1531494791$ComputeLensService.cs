using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Org.Visiontech.Commons.Services;
using Org.Visiontech.Commons.Models;
using Newtonsoft.Json;
using Org.Visiontech.Optoplus.Dto.Service;

namespace Org.Visiontech.Commons.Services
{
    public class ComputeLensService : RestService, IComputeLensService
    {

        public ComputeLensService() : base("compute/lens")
        {
        }

        public async Task<ComputeLensResponseDTO> Compute(ComputeLensRequestDTO request)
        {

            StringWriter stringWriter = new StringWriter();

            JsonSerializer.Provided.Serialize(new CustomJsonWriter(stringWriter), request);

            var content = new StringContent(stringWriter.ToString(), Encoding.UTF8, "application/json");

            var response = await HttpClientProvider.Provided.PostAsync(Uri, content);

            if (response.IsSuccessStatusCode)
            {
                using (var stringReader = new StringReader(await response.Content.ReadAsStringAsync()))
                using (var jsonReader = new CustomJsonReader(stringReader))
                {
                    return JsonSerializer.Provided.Deserialize<ComputeLensResponseDTO>(jsonReader);
                }
            }

            Debug.WriteLine("Error " + response.StatusCode);

            return null;

        }

    }
}
