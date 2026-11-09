using System.Security.Claims;
using ApiJwt.Data;
using ApiJwt.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsuarioController : ControllerBase
{
    private readonly ILogger<UsuarioController> _logger;
    private readonly AppDbContext _context;
    private readonly IUsuarioService _usuarioService;
    public UsuarioController(ILogger<UsuarioController> logger, AppDbContext context, IUsuarioService usuarioService)
    {
        _logger = logger;
        _context = context;
        _usuarioService = usuarioService;
    }

    [HttpPost("novo-usuario")]
    public async Task<IActionResult> CreateUsuario(string email, string senha, string nome)
    {
        try
        {
            _logger.LogInformation("Iniciando criação de usuário com email {Email}", email);

            var usuario = await _usuarioService.CreateUsarioAsync(email, senha, nome);

            _logger.LogInformation("Criação de usuário com email {Email} concluída com sucesso", email);

            return CreatedAtAction(nameof(CreateUsuario), new { id = usuario.Id }, usuario);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar usuário com email {Email}", email);
            return StatusCode(500, "Ocorreu um erro ao processar sua solicitação.");
        }
    }

    [HttpDelete("me")]
    public async Task<IActionResult> DeleteUsuario()
    {
        try
        {
            _logger.LogInformation("Iniciando exclusão do usuário autenticado");

            var usuarioIdClaim = User.FindFirstValue(
            ClaimTypes.NameIdentifier
            );

            if (!long.TryParse(usuarioIdClaim, out long usuarioId))
                return Unauthorized();

            var excluido = await _usuarioService
            .DeleteUsuarioAsync(usuarioId);


            if (!excluido)
            {
                _logger.LogWarning("Usuário com ID {UsuarioId} não encontrado para exclusão",
                 usuarioId);

                return NotFound("Usuário não encontrado.");
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao deletar usuário");
            return StatusCode(500, "Ocorreu um erro ao processar sua solicitação.");
        }
    }
}