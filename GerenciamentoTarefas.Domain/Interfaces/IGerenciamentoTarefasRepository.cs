using GerenciamentoTarefas.Domain.Entities;

namespace GerenciamentoTarefas.Domain.Interfaces;

public interface ITarefaRepository
{
    Task<Entities.GerenciamentoTarefa?> GetByIdAsync(int id);
    Task<IEnumerable<Entities.GerenciamentoTarefa>> GetAllAsync();
    Task<IEnumerable<Entities.GerenciamentoTarefa>> GetByConclusaoStatusAsync(bool concluida);
    Task<Entities.GerenciamentoTarefa> AddAsync(Entities.GerenciamentoTarefa tarefa);
    Task<Entities.GerenciamentoTarefa> UpdateAsync(Entities.GerenciamentoTarefa tarefa);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
