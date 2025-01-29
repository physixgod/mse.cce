using CCE.Domain.Usine;
using Microsoft.EntityFrameworkCore;
using CCE.Domain.Usine.Entities;  // Include the namespaces for your domain entities

namespace CCE.Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        // DbSets for your entities
        public DbSet<Usine> Usines { get; set; }
        public DbSet<Atelier> Ateliers { get; set; }
        public DbSet<SecteurAtelier> SecteurAteliers { get; set; }
        public DbSet<Ligne> Lignes { get; set; }
        public DbSet<TypePoste> TypePostes { get; set;}
        public DbSet<ProductionPotentielle> ProductionPotentielles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}