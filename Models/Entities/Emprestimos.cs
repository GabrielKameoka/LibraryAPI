namespace LibraryAPI.Models.Entities;

public class Emprestimos
{
    public int Id { get; set; }
    
    // Chaves estrangeiras
    public int LivroId { get; set; }
    public int UsuarioId { get; set; }
    
    public DateTime DataEmprestimo { get; set; } = DateTime.UtcNow;
    public DateTime DataDevolucaoPrevista { get; set; }
    public DateTime? DataDevolucaoRealizada { get; set; }
    
    // Propriedade calculada
    public bool EstaAtrasado => 
        !EstaDevolvido && DateTime.UtcNow > DataDevolucaoPrevista;
    
    public bool EstaDevolvido => DataDevolucaoRealizada.HasValue;
    
    // Multa por atraso (exemplo)
    public decimal CalcularMulta()
    {
        if (!EstaAtrasado) return 0;
        
        var diasAtraso = (DateTime.UtcNow - DataDevolucaoPrevista).Days;
        return diasAtraso * 2.50m; // R$ 2,50 por dia de atraso
    }
    
    // Navegações
    public virtual Livros Livro { get; set; } = null!;
    public virtual Usuarios Usuario { get; set; } = null!;
}