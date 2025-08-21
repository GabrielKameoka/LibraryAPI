using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.Entities;

public class Usuarios
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;
    
    [Required]
    [EmailAddress]
    [MaxLength(150)]
    public string Email { get; set; } = string.Empty;
    
    // Histórico de empréstimos
    public virtual ICollection<Emprestimos> Emprestimos { get; set; } = new List<Emprestimos>();
}