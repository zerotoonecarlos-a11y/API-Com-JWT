using System;
using ApiJwt.Models;

namespace ApiJwt.Interface;

public interface ITarefaService
{
     Task<List<Tarefa>> GetAllTarefasAsync(long usuarioId);
     Task<Tarefa?> GetTarefaByIdAsync(long id, long usuarioId);
     Task<Tarefa> CreateTarefaAsync(Tarefa tarefa);
     Task<Tarefa> UpdateTarefaAsync(Tarefa tarefa);
     Task<bool> DeleteTarefaAsync(long id, long usuarioId);

}
