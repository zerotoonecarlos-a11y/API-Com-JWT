using System;
using ApiJwt.Models;

namespace ApiJwt.Interface;

public interface ITarefaService
{
     Task<List<Tarefa>> GetAllTarefasAsync(int usuarioId);
     Task<Tarefa?> GetTarefaByIdAsync(int id, int usuarioId);
     Task<Tarefa> CreateTarefaAsync(Tarefa tarefa);

}
