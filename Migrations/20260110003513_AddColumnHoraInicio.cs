using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agendamento_de_Eventos.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnHoraInicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Horainicio",
                table: "Agendamento",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Horainicio",
                table: "Agendamento");
        }
    }
}
