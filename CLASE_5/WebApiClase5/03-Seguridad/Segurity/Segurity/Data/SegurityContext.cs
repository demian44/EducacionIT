using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Segurity.Models
{
    public class SegurityContext : DbContext
    {
        public SegurityContext (DbContextOptions<SegurityContext> options)
            : base(options)
        {
        }

        public DbSet<Persona> Persona { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Persona>().HasData(
                new Persona { ID = 1, Apellido = "Perez", Nombre = "Juan" },
                new Persona { ID = 2, Apellido = "Meyer", Nombre = "Camila" },
                new Persona { ID = 3, Apellido = "Fernandez", Nombre = "Maria" },
                new Persona { ID = 4, Apellido = "Rodriguez", Nombre = "Jorge" });
        }
    }
}
