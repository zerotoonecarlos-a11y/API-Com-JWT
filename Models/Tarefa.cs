using System;

namespace ApiJwt.Models;

public class Tarefa
{
    public long Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public bool Concluida { get; set; } = false;
    public DateTime DataVencimento {get; set;}

    public long UsuarioId { get; set; }
    public Usuario? Usuario  { get; set; } = null;
}
