using Microsoft.EntityFrameworkCore;

namespace Clase2_API.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Amigo> Amigos { get; set; }
    }
}
