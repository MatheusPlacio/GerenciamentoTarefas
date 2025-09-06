using GerenciamentoTarefas.Application.DTOs;

namespace GerenciamentoTarefas.Application.Interfaces;

public interface IAuthService
{
    Task<TokenResponseDto?> LoginAsync(LoginDto loginDto);
    bool ValidateCredentials(string usuario, string senha);
}
