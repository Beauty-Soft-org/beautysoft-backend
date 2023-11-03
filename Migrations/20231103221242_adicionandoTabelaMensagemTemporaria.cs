using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beautysoft.Migrations
{
    /// <inheritdoc />
    public partial class adicionandoTabelaMensagemTemporaria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MensagensTemporarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Habilitado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoMensagemTemporaria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MensagensTemporarias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Procedimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    InserirArquivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoProcedimento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnderecoEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenhaHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmSenhaHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Perfil = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnderecoEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenhaHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    SenhaSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TokenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Campo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MensagensTemporarias");

            migrationBuilder.DropTable(
                name: "Procedimentos");

            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Vouchers");
        }
    }
}
