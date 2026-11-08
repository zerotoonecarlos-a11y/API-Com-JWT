using System;
using ApiJwt.Data;
using ApiJwt.Interface;
using ApiJwt.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiJwt.Service;

public class UsuarioService
{
    private readonly AppDbContext _context;
    private readonly ILogger<UsuarioService> _logger;

    public UsuarioService(AppDbContext context, ILogger<UsuarioService> logger)
    {
        _context = context;
        _logger = logger;
    }
   
}
