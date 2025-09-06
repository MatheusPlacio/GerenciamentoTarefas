using System.ComponentModel.DataAnnotations;

namespace GerenciamentoTarefas.Application.DTOs;

public class CreateGerenciamentoTarefasDto
{
    [Required(ErrorMessage = "O título é obrigatório")]
    [StringLength(200, ErrorMessage = "O título deve ter no máximo 200 caracteres")]
    public string Titulo { get; set; } = string.Empty;

    [StringLength(1000, ErrorMessage = "A descrição deve ter no máximo 1000 caracteres")]
    public string? Descricao { get; set; }
}
