using CCE.Domain.Usine;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCE.Infrastructure.Persistence.Configurations.UsineConfiguration;

public class UsineConfiguration:IEntityTypeConfiguration<Usine>
{
    public void Configure(EntityTypeBuilder<Usine> builder)
    {
        builder.HasKey(k => k.Code);
        builder.HasMany(u => u.Ateliers)
            .WithOne(a => a.Usine)
            .HasForeignKey(a => a.UsineCode)
            .OnDelete(DeleteBehavior.Cascade);
    }
}