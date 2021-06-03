using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.Data;
using SEIIApp.Server.Domain;


namespace SEIIApp.Server.Services
{
    public class ProfilDefinitionService
    {
        private ApplicationDBContext ApplicationDBContext { get; set; }
        private IMapper Mapper { get; set; }
        public ProfilDefinitionService(ApplicationDBContext db, IMapper mapper)
        {
            this.ApplicationDBContext = db;
            this.Mapper = mapper;
        }

        private IQueryable<ProfilDefinition> GetQueryableForProfilDefinitions()

        {
            return ApplicationDBContext
                .ProfilDefinitions;

            //   .Include(quiz => quiz.Questions)
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
        public ProfilDefinition[] GetAllProfile()
        {
            return GetQueryableForProfilDefinitions().ToArray();
        }

        /// <summary>
        /// Returns the quiz with the given id. Includes also questions and their answers.
        /// </summary>
        public ProfilDefinition GetProfilWithId(int id)
        {
            return GetQueryableForProfilDefinitions().Where(profil => profil.Id == id).FirstOrDefault();
            //FirstOrDefault liefert das erste gefundene Objekt oder null zurück
        }

        /// <summary>
        /// Adds a quiz.
        /// </summary>
        public ProfilDefinition AddProfil(ProfilDefinition profil)
        {
            ApplicationDBContext.ProfilDefinitions.Add(profil);
            ApplicationDBContext.SaveChanges();
            return profil;
        }

        /// <summary>
        /// Updates a quiz.
        /// </summary>
        public ProfilDefinition UpdateProfil(ProfilDefinition profil)
        {
            //Wenn wir ein Quiz aktualisieren, dann fragen wir das existierende Quiz ab und 
            //Mappen die Änderung hinein.

            var existingProfil = GetProfilWithId(profil.Id);

            Mapper.Map(profil, existingProfil); //we can map into the same object type

            ApplicationDBContext.ProfilDefinitions.Update(existingProfil);
            ApplicationDBContext.SaveChanges();
            return existingProfil;
        }

        /// <summary>
        /// Removes a quiz and all dependencies.
        /// </summary>
        public void RemoveProfil(ProfilDefinition profil)
        {
            ApplicationDBContext.ProfilDefinitions.Remove(profil);
            ApplicationDBContext.SaveChanges();
        }

    }
}
