using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiJwt.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureTarefaConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefas");

            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Concluida = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    DataVencimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UsuarioId = table.Column<long>(type: "INTEGER", nullable: false),
                    UsuarioId1 = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.Id);
                    table.CheckConstraint("CK_Tarefa_Descricao", "\"Descricao\" IS NULL OR length(\"Descricao\") <= 1000");
                    table.CheckConstraint("CK_Tarefa_Titulo", "length(trim(\"Titulo\")) BETWEEN 1 AND 120");
                    table.ForeignKey(
                        name: "FK_Tarefa_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarefa_Usuarios_UsuarioId1",
                        column: x => x.UsuarioId1,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.AddCheckConstraint(
                name: "CK_Usuario_Email",
                table: "Usuarios",
                sql: "length(trim(\"Email\")) BETWEEN 1 AND 100");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Usuario_Nome",
                table: "Usuarios",
                sql: "length(trim(\"Nome\")) BETWEEN 1 AND 100");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Usuario_SenhaHash",
                table: "Usuarios",
                sql: "length(trim(\"SenhaHash\")) BETWEEN 1 AND 255");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_UsuarioId",
                table: "Tarefa",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_UsuarioId1",
                table: "Tarefa",
                column: "UsuarioId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefa");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Usuario_Email",
                table: "Usuarios");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Usuario_Nome",
                table: "Usuarios");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Usuario_SenhaHash",
                table: "Usuarios");

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsarioId = table.Column<long>(type: "INTEGER", nullable: false),
                    Concluida = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataVencimeto = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarefas_Usuarios_UsarioId",
                        column: x => x.UsarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_UsarioId",
                table: "Tarefas",
                column: "UsarioId");
        }
    }
}
