using System;
using ApiJwt.Data;
using ApiJwt.Interface;
using ApiJwt.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiJwt.Service;

public class TarefaService : ITarefaService
{
    private readonly AppDbContext _context;
     
    public TarefaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Tarefa>> GetAllTarefasAsync(int usuarioId)
    {
        return await _context.Tarefa.Where(t => t.UsuarioId == usuarioId).ToListAsync();
    }

    public async Task<Tarefa?> GetTarefaByIdAsync(int id, int usuarioId)
    {
       return await _context.Tarefa.FirstOrDefaultAsync(t => t.Id == id && t.UsuarioId == usuarioId);
    }

    public async Task<Tarefa> CreateTarefaAsync(Tarefa tarefa)
    {
        // Implementação do método para criar uma nova tarefa
        throw new NotImplementedException();
    }
}
