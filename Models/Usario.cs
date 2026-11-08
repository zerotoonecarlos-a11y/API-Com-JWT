namespace ApiJwt.Models;

public class Usario
{
    public long Id { get; set; }
    public string Nome {get; set;} = string.Empty;
    public string Email {get; set;} = string.Empty;
    public string SenhaHash {get; set;} = string.Empty;
    public List<Tarefas> Tarefas { get; set; } = new List<Tarefas>();

}