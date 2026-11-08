using System;

namespace ApiJwt.Models;

public class Tarefas
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public bool Concluida { get; set; }
    public DateTime DataVencimeto {get; set;}

    public long UsarioId { get; set; }
    public Usario Usario { get; set; } = null;
}
