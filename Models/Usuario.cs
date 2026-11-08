namespace ApiJwt.Models;

public class Usuario
{
    public long Id { get; set; }
    public string Nome {get; set;} = string.Empty;
    public string Email {get; set;} = string.Empty;
    public string SenhaHash {get; set;} = string.Empty;
    public List<Tarefa> Tarefas { get; set; } = new List<Tarefa>();

}