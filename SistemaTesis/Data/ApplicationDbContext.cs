using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaTesis.Models;

namespace SistemaTesis.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);          
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Provincia> Provincia { get; set; }

        public DbSet<Canton> Canton { get; set; }

        public DbSet<Distrito> Distrito { get; set; }

        public DbSet<Asentamiento> Asentamiento { get; set; }

        public DbSet<TipoDocumento> TipoDocumento { get; set; }
    }
}
