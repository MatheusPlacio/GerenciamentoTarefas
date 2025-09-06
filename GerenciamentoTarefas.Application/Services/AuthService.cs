using GerenciamentoTarefas.Application.DTOs;
using GerenciamentoTarefas.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GerenciamentoTarefas.Application.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    // Usuário fixo para teste
    private const string USUARIO_TESTE = "admin";
    private const string SENHA_TESTE = "123456";

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<TokenResponseDto?> LoginAsync(LoginDto loginDto)
    {
        // Validar credenciais do usuário fixo
        if (!ValidateCredentials(loginDto.Usuario, loginDto.Senha))
        {
            return null;
        }

        // Gerar token JWT
        var token = GenerateJwtToken(loginDto.Usuario);
        var expiration = DateTime.UtcNow.AddHours(2); // Token válido por 2 horas

        return await Task.FromResult(new TokenResponseDto
        {
            Token = token,
            Expiration = expiration,
            Usuario = loginDto.Usuario
        });
    }

    public bool ValidateCredentials(string usuario, string senha)
    {
        // Validação simples com usuário fixo
        return usuario == USUARIO_TESTE && senha == SENHA_TESTE;
    }

    private string GenerateJwtToken(string usuario)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, usuario),
            new Claim(ClaimTypes.NameIdentifier, usuario),
            new Claim("usuario", usuario),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
