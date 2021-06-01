using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SEIIApp.Shared;

namespace SEIIApp.Server.Data
{

    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
      : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Hier werden Einstellungen/Optionen zur Datenbank und zu den Tabellen erfasst
            //die sich nicht durch Annotationen abbilden lassen (z.B. multiple primäre Schlüssel).
        }

        public DbSet<Domain.ProfilDefinition> ProfilDefinitions { get; set; }

        public DbSet<Domain.LessonDefinition> LessonDefinitions { get; set; }
        public DbSet<Domain.MessageDefinition> MessageDefinitions { get; set; }


    }


}



