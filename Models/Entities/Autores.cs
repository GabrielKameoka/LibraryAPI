using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.Entities;

public class Autores
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;
    
    // Navegação virtual para lazy loading
    public virtual ICollection<Livros> Livros { get; set; } = new List<Livros>();
}