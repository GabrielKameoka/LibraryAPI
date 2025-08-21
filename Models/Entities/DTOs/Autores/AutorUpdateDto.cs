using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.Entities.DTOs.Autores;

public class AutorUpdateDto
{
    public int Id { get; set; }
    
    [Required] 
    public required string Nome { get; set; }
}