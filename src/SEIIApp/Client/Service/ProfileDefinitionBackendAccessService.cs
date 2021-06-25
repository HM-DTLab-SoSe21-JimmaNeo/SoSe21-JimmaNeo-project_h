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

        private string GetProfileDefinitionWithId(int id)
        {
            return $"{GetProfileDefinitionUrl()}/ProfilId/{id}";
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

        public async Task<ProfilDefinitionDto> GetProfileById(int id)
        {
            return await HttpClient.GetFromJsonAsync<ProfilDefinitionDto>(GetProfileDefinitionWithId(id));
        }
    }
}