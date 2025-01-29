using CCE.Domain.Usine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCE.Infrastructure.Persistence.Configurations.UsineConfiguration;

public class ProductionPotentielleConfiguration: IEntityTypeConfiguration<ProductionPotentielle>
{
    
    
        public void Configure(EntityTypeBuilder<ProductionPotentielle> builder)
        {
                builder.HasKey(pp =>pp.Code);
                
                builder.HasOne(pp => pp.Ligne)
                        .WithMany(l => l.ProductionPotentielles)  
                        .HasForeignKey(pp => pp.CodeLigne)
                        .OnDelete(DeleteBehavior.Cascade);
        }
    
}