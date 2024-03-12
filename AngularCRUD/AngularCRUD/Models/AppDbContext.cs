using Microsoft.EntityFrameworkCore;

namespace AngularCRUD.Models
{
    public class AppDbContext:DbContext
    {
        public DbSet<ProductEntity> ProductEntities { get; set; }

        public AppDbContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=testDB;Trusted_Connection=True;TrustServerCertificate=True;");
             
        }
    }
}
