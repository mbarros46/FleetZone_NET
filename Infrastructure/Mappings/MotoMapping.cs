using c_.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace c_.Infrastructure.Mappings
{
    public class MotoMapping: IEntityTypeConfiguration<Moto>
    {
        public void Configure(EntityTypeBuilder<Moto> builder)
        {
            builder
                .ToTable("Motos");

            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Modelo)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(m => m.Placa)
                .IsRequired()
                .HasMaxLength(50);
            
            
            builder
                .Property(m => m.Status)
                .IsRequired()
                .HasMaxLength(20);
        }
    
    }
}
