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

        private string GetLessonDefinitionUrl()
        {
            return "api/lessondefinitions";
        }
        private string GetLessonDefinitionWithId(int id)
        {
            return $"{GetLessonDefinitionUrl()}/{id}";
        }
        public async Task<LessonDefinitionDto[]> GetLessonOverview()
        {
            return await HttpClient.GetFromJsonAsync<LessonDefinitionDto[]>(GetLessonDefinitionUrl());
        }

        public async Task<LessonDefinitionDto> GetLessonById(int id)
        {
            return await HttpClient.GetFromJsonAsync<LessonDefinitionDto>(GetLessonDefinitionWithId(id));
        }


    }
}
