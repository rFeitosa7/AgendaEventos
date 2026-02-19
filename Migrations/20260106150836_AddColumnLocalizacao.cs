using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agendamento_de_Eventos.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnLocalizacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Localizacao",
                table: "Agendamento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localizacao",
                table: "Agendamento");
        }
    }
}
