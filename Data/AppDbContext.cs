using ApiJwt.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiJwt.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Tarefa> Tarefa { get; set; }
}