using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.Data;
using SEIIApp.Server.Domain;


namespace SEIIApp.Server.Services
{
    public class LessonProfilDefinitionService
    {
        private ApplicationDBContext ApplicationDBContext { get; set; }
        private IMapper Mapper { get; set; }
        public LessonProfilDefinitionService(ApplicationDBContext db, IMapper mapper)
        {
            this.ApplicationDBContext = db;
            this.Mapper = mapper;
        }

        private IQueryable<LessonProfilDefinition> GetQueryableForLessonProfilDefinitions()

        {
            return ApplicationDBContext
                .LessonProfilDefinitions;
        }

        /// <summary>
        /// Returns all lessonprofil definitions. 
        /// </summary>
        public LessonProfilDefinition[] GetAllLessonsProfil()
        {
            return GetQueryableForLessonProfilDefinitions().ToArray();
        }


        /// <summary>
        /// Returns all lessonprofil definitions for a specific lessonNumber. 
        /// </summary>
        public LessonProfilDefinition[] GetAllLessonsProfilForLessonNumber(int lessonNumber)
        {
            return GetQueryableForLessonProfilDefinitions().Where(lessonProfil => lessonProfil.lessonNumber == lessonNumber).ToArray();
        }

        /// <summary>
        /// Returns the lessonprofil with the given id.
        /// </summary>
        public LessonProfilDefinition GetLessonProfilWithid(int lessonProfilId)
        {
            return GetQueryableForLessonProfilDefinitions().Where(lessonProfil => lessonProfil.lessonProfilId == lessonProfilId).FirstOrDefault();
            //FirstOrDefault liefert das erste gefundene Objekt oder null zurück
        }

        /// <summary>
        /// Adds a lessonprofil.
        /// </summary>

        public LessonProfilDefinition AddLessonProfil(LessonProfilDefinition lessonProfil)
        { 
          //  try { 
                ApplicationDBContext.LessonProfilDefinitions.Add(lessonProfil);
                ApplicationDBContext.SaveChanges();
                return lessonProfil;
          //  }catch (Exception e)
            //{
            //    string errorMessage = e.InnerException.ToString();
               
            //    throw e.InnerException;
            //}
        }

        /// <summary>
        /// Updates a lessonprofil.
        /// </summary>
        public LessonProfilDefinition UpdateLessonProfil(LessonProfilDefinition lessonProfil)
        {
            //Wenn wir ein LessonPofil aktualisieren, dann fragen wir das existierende LessonProfil ab und 
            //Mappen die Änderung hinein.

            var existingLessonProfil = GetLessonProfilWithid(lessonProfil.lessonProfilId);

            Mapper.Map(lessonProfil, existingLessonProfil); //we can map into the same object type

            ApplicationDBContext.LessonProfilDefinitions.Update(existingLessonProfil);
            ApplicationDBContext.SaveChanges();
            return existingLessonProfil;
        }

        /// <summary>
        /// Removes a lessonprofil and all dependencies.
        /// </summary>
        public void RemoveLessonProfil(LessonProfilDefinition lessonProfil)
        {
            ApplicationDBContext.LessonProfilDefinitions.Remove(lessonProfil);
            ApplicationDBContext.SaveChanges();
        }

    }
}
