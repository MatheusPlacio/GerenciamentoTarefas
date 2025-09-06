namespace GerenciamentoTarefas.Application.DTOs;

public class GerenciamentoTarefasDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public DateTime DataCriacao { get; set; }
    public bool Concluida { get; set; }
}
