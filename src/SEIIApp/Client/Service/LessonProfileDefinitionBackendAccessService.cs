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

        /// <summary>
        /// Returns all lessonprofil definitions for a specific lessonNumber. 
        /// </summary>
        public async Task<LessonProfilDefinitionDto[]> GetLessonProfileDefinitionWithLessonNumber(int lessonNumber)
        {
            return await HttpClient.GetFromJsonAsync<LessonProfilDefinitionDto[]>(GetLPDUrlbyLessonNumber(lessonNumber));
        }
    }
}
