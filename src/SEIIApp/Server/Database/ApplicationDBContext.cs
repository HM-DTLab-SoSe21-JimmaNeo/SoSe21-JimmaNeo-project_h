using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.Domain;
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
            builder.Entity<LessonDefinition>()
            .HasIndex(u => u.lessonNumber)
            .IsUnique();

            builder.Entity<LessonProfilDefinition>()
           .HasIndex(u => new { u.Id, u.lessonNumber })
           .IsUnique();

            builder.Entity<LessonProfilDefinition>()
            .HasOne(p => p.LessonDefinition)
            .WithMany(b => b.LessonProfilDefinition)
            .HasForeignKey(p => p.lessonNumber);

            builder.Entity<LessonProfilDefinition>()
            .HasOne(p => p.ProfilDefinition)
            .WithMany(b => b.LessonProfilDefinition)
            .HasForeignKey(p => p.Id);
            

            //Hier werden Einstellungen/Optionen zur Datenbank und zu den Tabellen erfasst
            //die sich nicht durch Annotationen abbilden lassen (z.B. multiple primäre Schlüssel).
        }

        public DbSet<Domain.ProfilDefinition> ProfilDefinitions { get; set; }
        public DbSet<Domain.LessonDefinition> LessonDefinitions { get; set; }
        public DbSet<Domain.MessageDefinition> MessageDefinitions { get; set; }
        public DbSet<Domain.LessonProfilDefinition> LessonProfilDefinitions { get; set; }


    }


}



