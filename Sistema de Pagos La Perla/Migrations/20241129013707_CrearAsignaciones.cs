using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_de_Pagos_La_Perla.Migrations
{
    /// <inheritdoc />
    public partial class CrearAsignaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asignaciones",
                columns: table => new
                {
                    AsignacionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundoID = table.Column<int>(type: "int", nullable: false),
                    Tarea = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descuento = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: true),
                    Tarifa = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Turno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    FechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaciones", x => x.AsignacionID);
                    table.ForeignKey(
                        name: "FK_Asignaciones_Fundos_FundoID",
                        column: x => x.FundoID,
                        principalTable: "Fundos",
                        principalColumn: "FundoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asignaciones_FundoID",
                table: "Asignaciones",
                column: "FundoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asignaciones");
        }
    }
}
