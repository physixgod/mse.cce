using CCE.Domain.Usine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCE.Infrastructure.Persistence.Configurations.UsineConfiguration;

public class TypePosteConfiguration:IEntityTypeConfiguration<TypePoste>
{
    public void Configure(EntityTypeBuilder<TypePoste> builder)
    {
        builder.HasKey(p => p.Code);
    }

}