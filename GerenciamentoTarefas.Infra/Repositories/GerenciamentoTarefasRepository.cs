using GerenciamentoTarefas.Domain.Entities;
using GerenciamentoTarefas.Domain.Interfaces;
using GerenciamentoTarefas.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoTarefas.Infra.Repositories;

public class TarefaRepository : ITarefaRepository
{
    private readonly SqlServerContext _context;

    public TarefaRepository(SqlServerContext context)
    {
        _context = context;
    }

    public async Task<Domain.Entities.GerenciamentoTarefa?> GetByIdAsync(int id)
    {
        return await _context.GerenciamentoTarefas
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Domain.Entities.GerenciamentoTarefa>> GetAllAsync()
    {
        return await _context.GerenciamentoTarefas
            .OrderByDescending(x => x.DataCriacao)
            .ToListAsync();
    }

    public async Task<IEnumerable<Domain.Entities.GerenciamentoTarefa>> GetByConclusaoStatusAsync(bool concluida)
    {
        return await _context.GerenciamentoTarefas
            .Where(x => x.Concluida == concluida)
            .OrderByDescending(x => x.DataCriacao)
            .ToListAsync();
    }

    public async Task<Domain.Entities.GerenciamentoTarefa> AddAsync(Domain.Entities.GerenciamentoTarefa tarefa)
    {
        await _context.GerenciamentoTarefas.AddAsync(tarefa);
        await _context.SaveChangesAsync();
        return tarefa;
    }

    public async Task<Domain.Entities.GerenciamentoTarefa> UpdateAsync(Domain.Entities.GerenciamentoTarefa tarefa)
    {
        _context.GerenciamentoTarefas.Update(tarefa);
        await _context.SaveChangesAsync();
        return tarefa;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var tarefa = await GetByIdAsync(id);
        if (tarefa == null)
            return false;

        _context.GerenciamentoTarefas.Remove(tarefa);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.GerenciamentoTarefas
            .AnyAsync(x => x.Id == id);
    }
}
