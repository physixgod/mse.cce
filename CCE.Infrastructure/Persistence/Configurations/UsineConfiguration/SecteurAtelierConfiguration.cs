using CCE.Domain.Usine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCE.Infrastructure.Persistence.Configurations.UsineConfiguration;

public class SecteurAtelierConfiguration : IEntityTypeConfiguration<SecteurAtelier>
{
    public void Configure(EntityTypeBuilder<SecteurAtelier> builder)
    {
        builder.HasKey(s => s.Code);
        builder.HasOne(s => s.Atelier)
            .WithMany(a => a.SecteurAteliers)
            .HasForeignKey(s => s.AtelierCode)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(s => s.Lignes)
            .WithOne(l => l.SecteurAtelier)
            .HasForeignKey(l => l.SecteurAtelierCode)
            .OnDelete(DeleteBehavior.Cascade);
    }
}