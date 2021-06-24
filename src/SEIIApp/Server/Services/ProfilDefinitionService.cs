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
        }

        /// <summary>
        /// Returns all profil definitions.
        /// </summary>
        public ProfilDefinition[] GetAllProfile()
        {
            return GetQueryableForProfilDefinitions().ToArray();
        }

        /// <summary>
        /// Returns the profil with the given id.
        /// </summary>
        public ProfilDefinition GetProfilWithId(int id)
        {
            return GetQueryableForProfilDefinitions().Where(profil => profil.Id == id).FirstOrDefault();
            //FirstOrDefault liefert das erste gefundene Objekt oder null zurück
        }        
        public ProfilDefinition GetProfilWithEmail(string email)
        {
            return GetQueryableForProfilDefinitions().Where(profil => profil.Email == email).FirstOrDefault();
            //FirstOrDefault liefert das erste gefundene Objekt oder null zurück
        }

        /// <summary>
        /// Adds a profil.
        /// </summary>
        public ProfilDefinition AddProfil(ProfilDefinition profil)
        {
            ApplicationDBContext.ProfilDefinitions.Add(profil);
            ApplicationDBContext.SaveChanges();
            return profil;
        }

        /// <summary>
        /// Updates a profil.
        /// </summary>
        public ProfilDefinition UpdateProfil(ProfilDefinition profil)
        {
            //Wenn wir ein Profil aktualisieren, dann fragen wir das existierende Profil ab und 
            //Mappen die Änderung hinein.

            var existingProfil = GetProfilWithId(profil.Id);

            Mapper.Map(profil, existingProfil); //we can map into the same object type

            ApplicationDBContext.ProfilDefinitions.Update(existingProfil);
            ApplicationDBContext.SaveChanges();
            return existingProfil;
        }

        /// <summary>
        /// Removes a profil and all dependencies.
        /// </summary>
        public void RemoveProfil(ProfilDefinition profil)
        {
            ApplicationDBContext.ProfilDefinitions.Remove(profil);
            ApplicationDBContext.SaveChanges();
        }

    }
}
