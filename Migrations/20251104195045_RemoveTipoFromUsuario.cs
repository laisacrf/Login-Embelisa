using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace login_e_cadastro.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTipoFromUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Usuarios",
                newName: "Cpf");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Usuarios",
                newName: "Tipo");
        }
    }
}
