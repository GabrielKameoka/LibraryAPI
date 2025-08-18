namespace LibraryAPI.Models.Entities;

public class Livros
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateOnly Lancamento { get; set; }
    public Autores Autor { get; set; }
}