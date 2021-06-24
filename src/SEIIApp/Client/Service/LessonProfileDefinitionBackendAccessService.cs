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
    public class LessonProfileDefinitionBackendAccessService
    {
        private HttpClient HttpClient { get; set; }

        public LessonProfileDefinitionBackendAccessService(HttpClient client)
        {
            this.HttpClient = client;
        }

        /// <summary>
        /// Returns the lessonprofil url. 
        /// </summary>
        private string GetLessonProfileDefinitionUrl()
        {
            return "api/lessonprofildefinitions";
        }


        /// <summary>
        /// Returns the lessonprofil url. 
        /// </summary>
        private string GetLPDUrlbyLessonNumber(int id)
        {
            return $"{GetLessonProfileDefinitionUrl()}/AllHelpingHandForLesson/{id}";
        }

        private string GetLessonProfileDefinitionByLPDId(int id)
        {
            return $"{GetLessonProfileDefinitionUrl()}/{id}";
        }

        /// <summary>
        /// Returns all lessonprofil definitions for a specific lessonNumber. 
        /// </summary>
        public async Task<LessonProfilDefinitionDto[]> GetLessonProfileDefinitionsWithLessonNumber(int lessonNumber)
        {
            return await HttpClient.GetFromJsonAsync<LessonProfilDefinitionDto[]>(GetLPDUrlbyLessonNumber(lessonNumber));
        }        

        public async Task<LessonProfilDefinitionDto> GetLessonDefinitionByID(int lessonNumber)
        {
            return await HttpClient.GetFromJsonAsync<LessonProfilDefinitionDto>(GetLessonProfileDefinitionByLPDId(lessonNumber));
        }

        public async Task AddProfileLesson(LessonProfilDefinitionDto lessonProfile)
        {
            await HttpClient.PostAsJsonAsync(GetLessonProfileDefinitionUrl(), lessonProfile);
        }

        public async Task DeleteProfileLesson(int id)
        {
            await HttpClient.DeleteAsync(GetLessonProfileDefinitionByLPDId(id));
        }
    }
}
