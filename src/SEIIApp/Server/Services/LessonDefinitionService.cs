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
    public class LessonDefinitionService
    {
        private ApplicationDBContext ApplicationDBContext { get; set; }
        private IMapper Mapper { get; set; }
        public LessonDefinitionService(ApplicationDBContext db, IMapper mapper)
        {
            this.ApplicationDBContext = db;
            this.Mapper = mapper;
        }

        private IQueryable<LessonDefinition> GetQueryableForLessonDefinitions()

        {
            return ApplicationDBContext
                .LessonDefinitions;

            //   .Include(profil => profil.id)
            //      .ThenInclude(question => question.Answers);

            /* Diese Includes sagen der Datenbank, dass wir mit Joins arbeiten.
             * Wir holen daher aus den Datenbanken, in denen auch die Fragen zu einem Quiz und
             * die Antworten zu den Fragen gespeichert werden, die verbundenen Entitäten
             * aus der Datenbank.
             */
        }

        /// <summary>
        /// Returns all lesson definitions.
        /// </summary>
        public LessonDefinition[] GetAllLessons()
        {
            return GetQueryableForLessonDefinitions().ToArray();
        }

        /// <summary>
        /// Returns the lesson with the given id.
        /// </summary>
        public LessonDefinition GetLessonWithid(int id)
        {
            return GetQueryableForLessonDefinitions().Where(lesson => lesson.id == id).FirstOrDefault();
            //FirstOrDefault liefert das erste gefundene Objekt oder null zurück
        }

        /// <summary>
        /// Adds a lesson.
        /// </summary>

        public LessonDefinition AddLesson(LessonDefinition lesson)
        { 
            try { 
                ApplicationDBContext.LessonDefinitions.Add(lesson);
                ApplicationDBContext.SaveChanges();
                return lesson;
            }catch (Exception e)
            {
                string errorMessage = e.InnerException.ToString();
               
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Updates a lesson.
        /// </summary>
        public LessonDefinition UpdateLesson(LessonDefinition lesson)
        {
            //Wenn wir ein Lesson aktualisieren, dann fragen wir das existierende Lesson ab und 
            //Mappen die Änderung hinein.

            var existingLesson = GetLessonWithid(lesson.id);

            Mapper.Map(lesson, existingLesson); //we can map into the same object type

            ApplicationDBContext.LessonDefinitions.Update(existingLesson);
            ApplicationDBContext.SaveChanges();
            return existingLesson;
        }

        /// <summary>
        /// Removes a lesson and all dependencies.
        /// </summary>
        public void RemoveLesson(LessonDefinition lesson)
        {
            ApplicationDBContext.LessonDefinitions.Remove(lesson);
            ApplicationDBContext.SaveChanges();
        }

    }
}
