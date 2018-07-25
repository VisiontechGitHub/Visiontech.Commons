using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Org.Visiontech.Optoplus.Dto.Entity;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using VisiontechCommons;

namespace Org.Visiontech.Commons.Services
{

    public class CredentialService : DeletableService<CredentialDTO>, ICredentialService {

        public Uri MyUri { get; }

        public CredentialService() : base("credential")
        {
            MyUri = new Uri(string.Join("/", Uri, "my"));
        }

        async Task<CredentialDTO> ICredentialService.My()
        {
            var response = await HttpClientProvider.Provided.GetAsync(MyUri);

            if (response.IsSuccessStatusCode) {

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CredentialDTO>(content);

            }

            Debug.WriteLine("Error " + response.StatusCode);

            return null;
        }

    }

}