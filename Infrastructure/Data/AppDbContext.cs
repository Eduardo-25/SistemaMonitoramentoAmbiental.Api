using Microsoft.EntityFrameworkCore;

namespace SistemaMonitoramentoAmbiental.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<AlertaRegistro> Alertas => Set<AlertaRegistro>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlertaRegistro>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Mensagem).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Nivel).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Regiao).HasMaxLength(100);
            });
        }
    }
}