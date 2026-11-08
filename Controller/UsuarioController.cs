using ApiJwt.Data;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly ILogger<UsuarioController> _logger;
    private readonly AppDbContext _context;
    public UsuarioController(ILogger<UsuarioController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }
}