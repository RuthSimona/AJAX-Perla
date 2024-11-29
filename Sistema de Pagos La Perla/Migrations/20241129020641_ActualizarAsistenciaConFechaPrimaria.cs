using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_de_Pagos_La_Perla.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarAsistenciaConFechaPrimaria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UsuarioRegistro",
                table: "Trabajadores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "Asistencias",
                columns: table => new
                {
                    AsistenciaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaAsistencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AsignacionID = table.Column<int>(type: "int", nullable: false),
                    TrabajadorID = table.Column<int>(type: "int", nullable: false),
                    CantidadCompletada = table.Column<int>(type: "INT", nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencias", x => x.AsistenciaID);
                    table.ForeignKey(
                        name: "FK_Asistencias_Asignaciones_AsignacionID",
                        column: x => x.AsignacionID,
                        principalTable: "Asignaciones",
                        principalColumn: "AsignacionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asistencias_Trabajadores_TrabajadorID",
                        column: x => x.TrabajadorID,
                        principalTable: "Trabajadores",
                        principalColumn: "TrabajadorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_AsignacionID",
                table: "Asistencias",
                column: "AsignacionID");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_TrabajadorID",
                table: "Asistencias",
                column: "TrabajadorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asistencias");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioRegistro",
                table: "Trabajadores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
