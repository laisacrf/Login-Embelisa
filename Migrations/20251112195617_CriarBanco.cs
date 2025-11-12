using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace login_e_cadastro.Migrations
{
    /// <inheritdoc />
    public partial class CriarBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContasMensais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Morador = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    Mes = table.Column<string>(type: "TEXT", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PixId = table.Column<string>(type: "TEXT", nullable: false),
                    PixCodigo = table.Column<string>(type: "TEXT", nullable: false),
                    Pago = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasMensais", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContasMensais");
        }
    }
}
