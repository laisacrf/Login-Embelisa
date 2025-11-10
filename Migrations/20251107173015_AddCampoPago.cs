using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace login_e_cadastro.Migrations
{
    /// <inheritdoc />
    public partial class AddCampoPago : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Pago",
                table: "ContasMensais",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pago",
                table: "ContasMensais");
        }
    }
}
