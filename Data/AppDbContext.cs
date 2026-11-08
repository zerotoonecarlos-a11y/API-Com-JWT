
using ApiJwt.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiJwt.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Tarefa> Tarefa { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable(table =>
            {
                table.HasCheckConstraint(
                    "CK_Usuario_Nome",
                    "length(trim(\"Nome\")) BETWEEN 1 AND 100"
                );

                table.HasCheckConstraint(
                    "CK_Usuario_Email",
                    "length(trim(\"Email\")) BETWEEN 1 AND 100"
                );

                table.HasCheckConstraint(
                    "CK_Usuario_SenhaHash",
                    "length(trim(\"SenhaHash\")) BETWEEN 1 AND 255"
                );
            });

            entity.HasKey(u => u.Id);

            entity.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(u => u.SenhaHash)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<Tarefa>(entity =>
        {
            entity.ToTable(table =>
            {
                table.HasCheckConstraint(
                    "CK_Tarefa_Titulo",
                    "length(trim(\"Titulo\")) BETWEEN 1 AND 120"
                );

                table.HasCheckConstraint(
                    "CK_Tarefa_Descricao",
                    "\"Descricao\" IS NULL OR length(\"Descricao\") <= 1000"
                );
            });

            entity.HasKey(t => t.Id);

            entity.Property(t => t.Titulo)
                .IsRequired()
                .HasMaxLength(120);

            entity.Property(t => t.Descricao)
                .HasMaxLength(1000);

            entity.Property(t => t.Concluida)
                .HasDefaultValue(false);

            entity.Property(t => t.DataVencimento)
                .IsRequired();

            entity.HasOne(t => t.Usuario)
                .WithMany()
                .HasForeignKey(t => t.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(t => t.UsuarioId);
        });
    }
}