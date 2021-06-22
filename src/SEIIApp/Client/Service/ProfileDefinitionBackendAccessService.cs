using SEIIApp.Shared.DomainTdo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SEIIApp.Client.Service
{
    public class ProfileDefinitionBackendAccessService
    {
        private HttpClient HttpClient { get; set; }

        public ProfileDefinitionBackendAccessService(HttpClient client)
        {
            this.HttpClient = client;
        }

        public string GetProfileDefinitionUrl()
        {
            return "api/profildefinitions";
        }
        private string GetProfileDefinitionWithEmail(string email)
        {
            return $"{GetProfileDefinitionUrl()}/{email}";
        }

        public async Task AddProfile(ProfilDefinitionDto profile)
        {
                await HttpClient.PostAsJsonAsync(GetProfileDefinitionUrl(), profile);
        }

        public async Task<ProfilDefinitionDto> GetProfileByEmail(string email)
        {
           return await HttpClient.GetFromJsonAsync<ProfilDefinitionDto>(GetProfileDefinitionWithEmail(email));
        }
    }
}