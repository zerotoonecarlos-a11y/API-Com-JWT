using ApiJwt.Data;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")] 
public class TerafaController : ControllerBase
{
    private readonly ILogger<TerafaController> _logger;
    private readonly AppDbContext _context;

    public TerafaController(ILogger<TerafaController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }
}