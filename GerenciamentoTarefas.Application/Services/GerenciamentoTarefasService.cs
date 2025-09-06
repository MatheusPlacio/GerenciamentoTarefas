using AutoMapper;
using GerenciamentoTarefas.Application.DTOs;
using GerenciamentoTarefas.Application.Interfaces;
using GerenciamentoTarefas.Domain.Entities;
using GerenciamentoTarefas.Domain.Interfaces;

namespace GerenciamentoTarefas.Application.Services;

public class GerenciamentoTarefasService : IGerenciamentoTarefasService
{
    private readonly ITarefaRepository _repository;
    private readonly IMapper _mapper;

    public GerenciamentoTarefasService(ITarefaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GerenciamentoTarefasDto?> GetByIdAsync(int id)
    {
        var tarefa = await _repository.GetByIdAsync(id);
        return tarefa != null ? _mapper.Map<GerenciamentoTarefasDto>(tarefa) : null;
    }

    public async Task<IEnumerable<GerenciamentoTarefasDto>> GetAllAsync()
    {
        var tarefas = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<GerenciamentoTarefasDto>>(tarefas);
    }

    public async Task<IEnumerable<GerenciamentoTarefasDto>> GetByConclusaoStatusAsync(bool concluida)
    {
        var tarefas = await _repository.GetByConclusaoStatusAsync(concluida);
        return _mapper.Map<IEnumerable<GerenciamentoTarefasDto>>(tarefas);
    }

    public async Task<GerenciamentoTarefasDto> CreateAsync(CreateGerenciamentoTarefasDto createDto)
    {
        var tarefa = _mapper.Map<GerenciamentoTarefa>(createDto);
        var tarefaCriada = await _repository.AddAsync(tarefa);
        return _mapper.Map<GerenciamentoTarefasDto>(tarefaCriada);
    }

    public async Task<GerenciamentoTarefasDto?> UpdateAsync(int id, UpdateGerenciamentoTarefasDto updateDto)
    {
        var tarefaExistente = await _repository.GetByIdAsync(id);
        if (tarefaExistente == null)
            return null;

        tarefaExistente.AtualizarTitulo(updateDto.Titulo);
        tarefaExistente.AtualizarDescricao(updateDto.Descricao);
        
        if (updateDto.Concluida != tarefaExistente.Concluida)
        {
            if (updateDto.Concluida)
                tarefaExistente.MarcarComoConcluida();
            else
                tarefaExistente.MarcarComoPendente();
        }

        var tarefaAtualizada = await _repository.UpdateAsync(tarefaExistente);
        return _mapper.Map<GerenciamentoTarefasDto>(tarefaAtualizada);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _repository.ExistsAsync(id);
    }
}
