using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.Entities.DTOs.Autores;

public class AutorCreateDto
{
    [Required]
    public required string Nome { get; set; }
}