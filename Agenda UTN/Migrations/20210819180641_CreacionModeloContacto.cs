using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agenda_UTN.Migrations
{
    public partial class CreacionModeloContacto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 15, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: true),
                    CategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacto_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_CategoriaId",
                table: "Contacto",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacto");
        }
    }
}
