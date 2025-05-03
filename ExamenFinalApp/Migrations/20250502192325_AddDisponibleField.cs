using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenFinalApp.Migrations
{
    /// <inheritdoc />
    public partial class AddDisponibleField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Disponible",
                table: "Libros",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponible",
                table: "Libros");
        }
    }
}
