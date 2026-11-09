using System;
using ApiJwt.Data;
using ApiJwt.Interface;

namespace ApiJwt.Service;

public class AuthService : IAuthService 
{
    private readonly IUsuarioService _usuarioService;
    private readonly AppDbContext _context;
    private readonly ILogger<AuthService> _logger;

    public AuthService(IUsuarioService usuarioService, AppDbContext context, ILogger<AuthService> logger)
    {
        _usuarioService = usuarioService;
        _context = context;
        _logger = logger;
    }

    public async Task<string?> ValidarLoginAsync(string email, string senha)
    {
        var usuario = await _usuarioService.GetUsuarioByEmailAsync(email);

        if (usuario == null || usuario.SenhaHash != senha)
        {
            _logger.LogWarning("Falha na validação de login para o email: {Email}", email);
            throw new UnauthorizedAccessException("Credenciais inválidas.");
        }

        // Aqui você pode gerar um token JWT ou realizar outras ações necessárias
        return "TokenGerado"; // Substitua isso pela lógica real de geração de token
    }

}
