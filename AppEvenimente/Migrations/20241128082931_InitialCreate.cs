using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppEvenimente.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evenimente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumeEveniment = table.Column<string>(type: "TEXT", nullable: true),
                    DataEveniment = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Locatie = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evenimente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participanti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumeParticipant = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    EvenimentId = table.Column<int>(type: "INTEGER", nullable: false),
                    EventId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participanti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participanti_Evenimente_EventId",
                        column: x => x.EventId,
                        principalTable: "Evenimente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participanti_EventId",
                table: "Participanti",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participanti");

            migrationBuilder.DropTable(
                name: "Evenimente");
        }
    }
}
