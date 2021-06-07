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

            //   .Include(profil => profil.id)
            //      .ThenInclude(question => question.Answers);

            /* Diese Includes sagen der Datenbank, dass wir mit Joins arbeiten.
             * Wir holen daher aus den Datenbanken, in denen auch die Fragen zu einem Quiz und
             * die Antworten zu den Fragen gespeichert werden, die verbundenen Entitäten
             * aus der Datenbank.
             */
        }

        /// <summary>
        /// Returns all quiz definitions. Includes also questions and their answers.
        /// </summary>
        public LessonProfilDefinition[] GetAllLessonsProfil()
        {
            return GetQueryableForLessonProfilDefinitions().ToArray();
        }

        /// <summary>
        /// Returns the quiz with the given id. Includes also questions and their answers.
        /// </summary>
        public LessonProfilDefinition GetLessonProfilWithid(int lessonProfilId)
        {
            return GetQueryableForLessonProfilDefinitions().Where(lessonProfil => lessonProfil.lessonProfilId == lessonProfilId).FirstOrDefault();
            //FirstOrDefault liefert das erste gefundene Objekt oder null zurück
        }

        /// <summary>
        /// Adds a quiz.
        /// </summary>

        public LessonProfilDefinition AddLessonProfil(LessonProfilDefinition lessonProfil)
        { 
            try { 
                ApplicationDBContext.LessonProfilDefinitions.Add(lessonProfil);
                ApplicationDBContext.SaveChanges();
                return lessonProfil;
            }catch (Exception e)
            {
                string errorMessage = e.InnerException.ToString();
               
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Updates a quiz.
        /// </summary>
        public LessonProfilDefinition UpdateLessonProfil(LessonProfilDefinition lessonProfil)
        {
            //Wenn wir ein Lesson aktualisieren, dann fragen wir das existierende Lesson ab und 
            //Mappen die Änderung hinein.

            var existingLessonProfil = GetLessonProfilWithid(lessonProfil.lessonProfilId);

            Mapper.Map(lessonProfil, existingLessonProfil); //we can map into the same object type

            ApplicationDBContext.LessonProfilDefinitions.Update(existingLessonProfil);
            ApplicationDBContext.SaveChanges();
            return existingLessonProfil;
        }

        /// <summary>
        /// Removes a lesson and all dependencies.
        /// </summary>
        public void RemoveLessonProfil(LessonProfilDefinition lessonProfil)
        {
            ApplicationDBContext.LessonProfilDefinitions.Remove(lessonProfil);
            ApplicationDBContext.SaveChanges();
        }

    }
}
