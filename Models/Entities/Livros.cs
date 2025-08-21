using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.Entities;

public class Livros
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Titulo { get; set; } = string.Empty;
    
    public DateOnly DataLancamento { get; set; }
    
    // Chave estrangeira explícita
    public int AutorId { get; set; }
    
    // Navegação virtual
    public virtual Autores Autor { get; set; } = null!;
    
    // Relacionamento com empréstimos
    public virtual ICollection<Emprestimos> Emprestimos { get; set; } = new List<Emprestimos>();
}