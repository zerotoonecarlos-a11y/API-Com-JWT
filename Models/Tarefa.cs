using System;

namespace ApiJwt.Models;

public class Tarefa
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public bool Concluida { get; set; }
    public DateTime DataVencimeto {get; set;}

    public long UsuarioId { get; set; }
    public Usuario? Usuario  { get; set; } = null;
}
