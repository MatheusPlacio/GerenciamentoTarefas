namespace GerenciamentoTarefas.Domain.Entities;

public class GerenciamentoTarefa
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public DateTime DataCriacao { get; set; }
    public bool Concluida { get; set; }

    public GerenciamentoTarefa()
    {
        DataCriacao = DateTime.UtcNow;
        Concluida = false;
    }

    public GerenciamentoTarefa(string titulo, string? descricao = null)
    {
        Titulo = titulo;
        Descricao = descricao;
        DataCriacao = DateTime.UtcNow;
        Concluida = false;
    }

    public void MarcarComoConcluida()
    {
        Concluida = true;
    }

    public void MarcarComoPendente()
    {
        Concluida = false;
    }

    public void AtualizarTitulo(string novoTitulo)
    {
        if (string.IsNullOrWhiteSpace(novoTitulo))
            throw new ArgumentException("Título não pode ser vazio", nameof(novoTitulo));

        Titulo = novoTitulo;
    }

    public void AtualizarDescricao(string? novaDescricao)
    {
        Descricao = novaDescricao;
    }
}