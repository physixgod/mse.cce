using CCE.Domain.Usine;
using Microsoft.EntityFrameworkCore;
using CCE.Domain.Usine.Entities;  // Include the namespaces for your domain entities
using CCE.Infrastructure.Persistence.Configurations.UsineConfiguration;  // Include namespaces for your configurations

namespace CCE.Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        // DbSets for your entities
        public DbSet<Usine> Usines { get; set; }
        public DbSet<Atelier> Ateliers { get; set; }
        public DbSet<SecteurAtelier> SecteurAteliers { get; set; }
        public DbSet<Ligne> Lignes { get; set; }

        // Constructor that receives options and passes them to the base class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // This method is called by the framework to configure the model and relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply configurations from your assembly (e.g., UsineConfiguration, AtelierConfiguration)
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // You can also manually configure your entities here if needed
            // For example, if you want to manually add a configuration, you can do:
            // modelBuilder.Entity<Usine>().HasKey(u => u.Code); 
            
            base.OnModelCreating(modelBuilder);
        }
    }
}