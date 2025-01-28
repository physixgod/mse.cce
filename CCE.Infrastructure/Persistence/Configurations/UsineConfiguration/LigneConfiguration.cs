using CCE.Domain.Usine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCE.Infrastructure.Persistence.Configurations.UsineConfiguration;

public class LigneConfiguration : IEntityTypeConfiguration<Ligne>
{
    public void Configure(EntityTypeBuilder<Ligne> builder)
    {
        builder.HasKey(l => l.Code);

        builder.HasOne(l => l.SecteurAtelier)
            .WithMany(s => s.Lignes)
            .HasForeignKey(l => l.SecteurAtelierCode)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete behavior
    }
}