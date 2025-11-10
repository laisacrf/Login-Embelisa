using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace login_e_cadastro.Migrations
{
    /// <inheritdoc />
    public partial class RecriarBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PixId",
                table: "ContasMensais",
                newName: "Morador");

            migrationBuilder.AddColumn<string>(
                name: "Mes",
                table: "ContasMensais",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mes",
                table: "ContasMensais");

            migrationBuilder.RenameColumn(
                name: "Morador",
                table: "ContasMensais",
                newName: "PixId");
        }
    }
}
