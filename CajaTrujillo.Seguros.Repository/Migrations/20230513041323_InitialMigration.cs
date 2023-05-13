using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CajaTrujillo.Seguros.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dni = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seguros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Compania = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipoSeguro = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FactorImpuesto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PorcentajeComision = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoPrima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Moneda = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EdadMaxima = table.Column<int>(type: "int", nullable: false),
                    ImporteMensual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cobertura = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Afiliaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroPoliza = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaAfiliacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVigencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    SeguroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afiliaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Afiliaciones_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Afiliaciones_Seguros_SeguroId",
                        column: x => x.SeguroId,
                        principalTable: "Seguros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    AfiliacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_Afiliaciones_AfiliacionId",
                        column: x => x.AfiliacionId,
                        principalTable: "Afiliaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Afiliaciones_ClienteId",
                table: "Afiliaciones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Afiliaciones_SeguroId",
                table: "Afiliaciones",
                column: "SeguroId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_AfiliacionId",
                table: "Pagos",
                column: "AfiliacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Afiliaciones");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Seguros");
        }
    }
}
