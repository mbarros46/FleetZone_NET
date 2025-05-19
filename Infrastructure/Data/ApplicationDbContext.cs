using Microsoft.EntityFrameworkCore;
using MottuCrudAPI.Domain.Entities;

namespace MottuCrudAPI.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Moto> Motos { get; set; }
        public DbSet<Patio> Patios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Moto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Placa).IsRequired().HasMaxLength(7);
                entity.Property(e => e.Modelo).IsRequired();
                entity.HasOne(e => e.Patio)
                      .WithMany(p => p.Motos)
                      .HasForeignKey(e => e.PatioId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Patio>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Endereco).IsRequired();
            });
        }
    }
} 