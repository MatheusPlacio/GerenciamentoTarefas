using GerenciamentoTarefas.Application.DTOs;
using GerenciamentoTarefas.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoTarefas.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Realizar login e obter token JWT
    /// </summary>
    /// <param name="loginDto">Credenciais de login</param>
    /// <returns>Token de acesso</returns>
    /// <remarks>
    /// Usuário de teste:
    /// - Usuário: admin
    /// - Senha: 123456
    /// </remarks>
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TokenResponseDto>> Login([FromBody] LoginDto loginDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var tokenResponse = await _authService.LoginAsync(loginDto);

        if (tokenResponse == null)
        {
            return Unauthorized(new { message = "Credenciais inválidas" });
        }

        return Ok(tokenResponse);
    }

    /// <summary>
    /// Informações sobre autenticação
    /// </summary>
    /// <returns>Informações de teste</returns>
    [HttpGet("info")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult GetAuthInfo()
    {
        return Ok(new
        {
            message = "API com autenticação JWT habilitada",
            usuarioTeste = "admin",
            senhaTeste = "123456",
            instrucoes = new
            {
                passo1 = "Faça POST /api/auth/login com as credenciais de teste",
                passo2 = "Copie o token retornado",
                passo3 = "Use o token no header: Authorization: Bearer {token}",
                passo4 = "Acesse os endpoints protegidos em /api/tasks"
            }
        });
    }
}
