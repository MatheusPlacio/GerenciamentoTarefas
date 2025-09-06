using GerenciamentoTarefas.Application.DTOs;

namespace GerenciamentoTarefas.Application.Interfaces;

public interface IGerenciamentoTarefasService
{
    Task<GerenciamentoTarefasDto?> GetByIdAsync(int id);
    Task<IEnumerable<GerenciamentoTarefasDto>> GetAllAsync();
    Task<IEnumerable<GerenciamentoTarefasDto>> GetByConclusaoStatusAsync(bool concluida);
    Task<GerenciamentoTarefasDto> CreateAsync(CreateGerenciamentoTarefasDto createDto);
    Task<GerenciamentoTarefasDto?> UpdateAsync(int id, UpdateGerenciamentoTarefasDto updateDto);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
