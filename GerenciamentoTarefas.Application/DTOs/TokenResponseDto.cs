namespace GerenciamentoTarefas.Application.DTOs;

public class TokenResponseDto
{
    public string Token { get; set; } = string.Empty;
    public DateTime Expiration { get; set; }
    public string Usuario { get; set; } = string.Empty;
}
