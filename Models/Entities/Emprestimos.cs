namespace LibraryAPI.Models.Entities;

public class Emprestimo
{
    public int Id { get; set; }

    public int IdLivro { get; set; }
    public int IdUsuario { get; set; }

    public DateOnly DataEmprestimo { get; set; } // Data em que o livro foi emprestado
    public DateOnly DataDevolucaoPrevista { get; set; }
    public DateOnly? DataDevolucaoRealizada { get; set; } // Data real da devolução (pode ser nula se ainda não foi devolvido)

    public bool EstaDevolvido => DataDevolucaoRealizada.HasValue; // Propriedade de leitura para verificar o status
}