using LibraryAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data;

public class LibraryDbContext  : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options){}

    public DbSet<Autores> Autores { get; set; }
    public DbSet<Livros> Livros { get; set; }
    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Emprestimo> Emprestimos { get; set; }
}