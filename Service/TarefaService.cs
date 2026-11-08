using System;
using ApiJwt.Data;
using ApiJwt.Interface;
using ApiJwt.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiJwt.Service;

public class TarefaService : ITarefaService
{
    private readonly AppDbContext _context;
    private readonly ILogger<TarefaService> _logger;

    public TarefaService(AppDbContext context, ILogger<TarefaService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Tarefa>> GetAllTarefasAsync(int usuarioId)
    {
        try
        {
            _logger.LogInformation(
                "Iniciando busca de todas as tarefas para o usuario {UsuarioId}",
                usuarioId
            );

            var tarefas = await _context.Tarefa.Where(t => t.UsuarioId == usuarioId).ToListAsync();

            _logger.LogInformation(
                "Busca de todas as tarefas para o usuario {UsuarioId} concluída com sucesso",
                usuarioId
            );
            return tarefas;
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "Erro ao buscar todas as tarefas para o usuário {UsuarioId}",
                usuarioId
            );
            throw;
        }

    }

    public async Task<Tarefa?> GetTarefaByIdAsync(int id, int usuarioId)
    {


        try
        {
            _logger.LogInformation(
               "Iniciando busca de tarefa pelo id {TarefaId} para o usuário {UsuarioId}",
               id,
               usuarioId
           );

            var tarefa = await _context.Tarefa.FirstOrDefaultAsync(t => t.Id == id && t.UsuarioId == usuarioId);

            if (tarefa == null)
            {
                _logger.LogWarning(
                    "Tarefa com id {TarefaId} não encontrada para o usuário {UsuarioId}",
                    id,
                    usuarioId
                );
                return null;
            }
            else
            {
                _logger.LogInformation(
                    "Tarefa com id {TarefaId} encontrada para o usuário {UsuarioId}",
                    id,
                    usuarioId
                );
                return tarefa;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "Erro ao buscar tarefa com id {TarefaId} para o usuário {UsuarioId}",
                id,
                usuarioId
            );
            throw;
        }
    }

    public async Task<Tarefa> CreateTarefaAsync(Tarefa tarefa)
    {
        try
        {
            _logger.LogInformation(
            "Iniciando cadastro de tarefa para o usuário {UsuarioId}",
            tarefa.UsuarioId
            );

            _context.Tarefa.Add(tarefa);
            await _context.SaveChangesAsync();

            _logger.LogInformation(
            "Tarefa {TarefaId} cadastrada com sucesso",
            tarefa.Id
            );
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "Erro de persistência ao cadastrar tarefa do usuário {UsuarioId}",
                tarefa.UsuarioId
            );

            throw;
        }
        return tarefa;
    }

    public async Task<Tarefa> UpdateTarefaAsync(Tarefa tarefa)
    {
        try
        {
            _logger.LogInformation(
                "Iniciando atualização de tarefa {TarefaId} para o usuário {UsuarioId}",
                tarefa.Id,
                tarefa.UsuarioId
            );
            _context.Tarefa.Update(tarefa);

            await _context.SaveChangesAsync();

            _logger.LogInformation(
                "Tarefa {TarefaId} atualizada com sucesso para o usuário {UsuarioId}",
                tarefa.Id,
                tarefa.UsuarioId
            );
            return tarefa;
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "Erro ao atualizar tarefa do usuário {UsuarioId}",
                tarefa.UsuarioId
            );
            throw;
        }
    }

    public async Task<bool> DeleteTarefaAsync(int id, int usuarioId)
    {
        try
        {
            _logger.LogInformation(
                "Iniciando exclusão de tarefa com id {TarefaId} para o usuário {UsuarioId}",
                id,
                usuarioId
            );
            var tarefa = await _context.Tarefa.FirstOrDefaultAsync(t => t.Id == id && t.UsuarioId == usuarioId);

            if (tarefa == null)
            {
                _logger.LogWarning(
                    "Tarefa com id {TarefaId} não encontrada para o usuário {UsuarioId}",
                    id,
                    usuarioId
                );
                return false;
            }
            _context.Tarefa.Remove(tarefa);
            await _context.SaveChangesAsync();

            _logger.LogInformation(
                "Tarefa com id {TarefaId} excluída com sucesso para o usuário {UsuarioId}",
                id,
                usuarioId
            );
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "Erro ao excluir tarefa com id {TarefaId} para o usuário {UsuarioId}",
                id,
                usuarioId
            );
            throw;
        }
    }

}
