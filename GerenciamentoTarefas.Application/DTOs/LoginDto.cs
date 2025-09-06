using System.ComponentModel.DataAnnotations;

namespace GerenciamentoTarefas.Application.DTOs;

public class LoginDto
{
    [Required(ErrorMessage = "O usuário é obrigatório")]
    public string Usuario { get; set; } = string.Empty;

    [Required(ErrorMessage = "A senha é obrigatória")]
    public string Senha { get; set; } = string.Empty;
}
