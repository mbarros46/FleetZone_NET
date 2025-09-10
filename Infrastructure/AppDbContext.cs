using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) {}

    public DbSet<Patio> Patios => Set<Patio>();
    public DbSet<Motocicleta> Motocicletas => Set<Motocicleta>();
    public DbSet<Movimentacao> Movimentacoes => Set<Movimentacao>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Patio>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Nome).IsRequired().HasMaxLength(120);
            e.Property(x => x.Endereco).IsRequired().HasMaxLength(200);
        });

        b.Entity<Motocicleta>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Placa).IsRequired().HasMaxLength(10);
            e.Property(x => x.Modelo).IsRequired().HasMaxLength(80);
            e.HasOne(x => x.Patio).WithMany(p => p.Motocicletas).HasForeignKey(x => x.PatioId);
        });

        b.Entity<Movimentacao>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Tipo).IsRequired().HasMaxLength(30);
            e.HasOne(x => x.Motocicleta).WithMany(m => m.Movimentacoes).HasForeignKey(x => x.MotocicletaId);
            e.HasOne(x => x.Patio).WithMany().HasForeignKey(x => x.PatioId);
        });
    }
}
