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

        public DbSet<Profil> Profile { get; set; }


    }
}



