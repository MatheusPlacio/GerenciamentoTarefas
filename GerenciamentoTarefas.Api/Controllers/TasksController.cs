using GerenciamentoTarefas.Application.DTOs;
using GerenciamentoTarefas.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoTarefas.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[Authorize]
public class TasksController : ControllerBase
{
    private readonly IGerenciamentoTarefasService _tarefasService;

    public TasksController(IGerenciamentoTarefasService tarefasService)
    {
        _tarefasService = tarefasService;
    }

    /// <summary>
    /// Listar todas as tarefas
    /// </summary>
    /// <param name="concluida">Filtrar por status de conclusão (opcional)</param>
    /// <returns>Lista de tarefas</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<GerenciamentoTarefasDto>>> GetTasks([FromQuery] bool? concluida = null)
    {
        var tarefas = concluida.HasValue 
            ? await _tarefasService.GetByConclusaoStatusAsync(concluida.Value)
            : await _tarefasService.GetAllAsync();

        return Ok(tarefas);
    }

    /// <summary>
    /// Buscar uma tarefa específica
    /// </summary>
    /// <param name="id">ID da tarefa</param>
    /// <returns>Tarefa encontrada</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GerenciamentoTarefasDto>> GetTask(int id)
    {
        var tarefa = await _tarefasService.GetByIdAsync(id);
        
        if (tarefa == null)
            return NotFound(new { message = "Tarefa não encontrada" });

        return Ok(tarefa);
    }

    /// <summary>
    /// Criar uma nova tarefa
    /// </summary>
    /// <param name="createDto">Dados da tarefa a ser criada</param>
    /// <returns>Tarefa criada</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GerenciamentoTarefasDto>> CreateTask([FromBody] CreateGerenciamentoTarefasDto createDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var tarefa = await _tarefasService.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetTask), new { id = tarefa.Id }, tarefa);
    }

    /// <summary>
    /// Atualizar uma tarefa existente
    /// </summary>
    /// <param name="id">ID da tarefa</param>
    /// <param name="updateDto">Dados atualizados da tarefa</param>
    /// <returns>Tarefa atualizada</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GerenciamentoTarefasDto>> UpdateTask(int id, [FromBody] UpdateGerenciamentoTarefasDto updateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var tarefa = await _tarefasService.UpdateAsync(id, updateDto);
        
        if (tarefa == null)
            return NotFound(new { message = "Tarefa não encontrada" });

        return Ok(tarefa);
    }

    /// <summary>
    /// Excluir uma tarefa
    /// </summary>
    /// <param name="id">ID da tarefa</param>
    /// <returns>Confirmação da exclusão</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteTask(int id)
    {
        var deleted = await _tarefasService.DeleteAsync(id);
        
        if (!deleted)
            return NotFound(new { message = "Tarefa não encontrada" });

        return NoContent();
    }

}
