using System;
using ApiJwt.Data;
using ApiJwt.Interface;
using ApiJwt.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiJwt.Service;

public class UsuarioService : IUsuarioService
{
    private readonly AppDbContext _context;
    private readonly ILogger<UsuarioService> _logger;

    public UsuarioService(AppDbContext context, ILogger<UsuarioService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Usuario> CreateUsarioAsync(string email, string senha, string nome)
    {
        try
        {
            _logger.LogInformation(
                "Iniciando criação de usuário com email {Email}",
                email
            );

            var usuario = new Usuario
            {
                Email = email,
                Senha = senha,
                Nome = nome
            };

            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            _logger.LogInformation(
                "Criação de usuário com email {Email} concluída com sucesso",
                email
            );

            return usuario;
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "Erro ao criar usuário com email {Email}",
                email
            );
            throw;
        }
    }

    public async Task<bool> DeleteUsuarioAsync(long usuarioId)
    {
        try
        {
            _logger.LogInformation(
                "Iniciando exclusão de usuário com ID {UsuarioId}",
                usuarioId
            );

            var usuario = await _context.Usuario.FindAsync(usuarioId);
            if (usuario == null)
            {
                _logger.LogWarning(
                    "Usuário com ID {UsuarioId} não encontrado para exclusão",
                    usuarioId
                );
                return false;
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            _logger.LogInformation(
                "Exclusão de usuário com ID {UsuarioId} concluída com sucesso",
                usuarioId
            );
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "Erro ao excluir usuário com ID {UsuarioId}",
                usuarioId
            );
            throw;
        }
    }
   
}
