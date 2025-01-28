using CCE.Domain.Usine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCE.Infrastructure.Persistence.Configurations.UsineConfiguration
{
    public class AtelierConfiguration : IEntityTypeConfiguration<Atelier>
    {
        public void Configure(EntityTypeBuilder<Atelier> builder)
        {
            builder.HasKey(a => a.Code);
            builder.HasOne(a => a.Usine)
                .WithMany(u => u.Ateliers)
                .HasForeignKey(a => a.UsineCode)
                .OnDelete(DeleteBehavior.Cascade); 
            builder.HasMany(a => a.SecteurAteliers)
                .WithOne(s => s.Atelier)
                .HasForeignKey(s => s.AtelierCode)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}