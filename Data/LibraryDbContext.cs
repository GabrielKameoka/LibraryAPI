using System.Reflection;
using LibraryAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {
    }

    public DbSet<Autores> Autores { get; set; }
    public DbSet<Livros> Livros { get; set; }
    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Emprestimos> Emprestimos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Aplicar todas as configurações automaticamente
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Configurações específicas
        modelBuilder.Entity<Emprestimos>(entity =>
        {
            entity.HasOne(e => e.Livro)
                .WithMany(l => l.Emprestimos)
                .HasForeignKey(e => e.LivroId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Usuario)
                .WithMany(u => u.Emprestimos)
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Índices para melhor performance
            entity.HasIndex(e => e.LivroId);
            entity.HasIndex(e => e.UsuarioId);
            entity.HasIndex(e => e.DataDevolucaoRealizada);
        });

        modelBuilder.Entity<Livros>(entity =>
        {
            entity.HasOne(l => l.Autor)
                .WithMany(a => a.Livros)
                .HasForeignKey(l => l.AutorId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(l => l.AutorId);
            entity.HasIndex(l => l.Titulo);
        });

        modelBuilder.Entity<Usuarios>(entity => { entity.HasIndex(u => u.Email).IsUnique(); });
    }

    // Configurar convenções de data
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is BaseEntity &&
                        (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((BaseEntity)entityEntry.Entity).DataModificacao = DateTime.UtcNow;

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntity)entityEntry.Entity).DataCriacao = DateTime.UtcNow;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}

// Classe base para entidades
public abstract class BaseEntity
{
    public DateTime DataCriacao { get; set; }
    public DateTime DataModificacao { get; set; }
}