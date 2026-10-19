using AutAutorizadoresMS.Models;
using Microsoft.EntityFrameworkCore;

namespace AutAutorizadoresMS.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Autorizador> Autorizadores => Set<Autorizador>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Opcional: configuraciones adicionales por entidad
        modelBuilder.Entity<Autorizador>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Nombre).IsRequired().HasMaxLength(100);
            entity.Property(a => a.Email).IsRequired().HasMaxLength(100);
        });
    }
}