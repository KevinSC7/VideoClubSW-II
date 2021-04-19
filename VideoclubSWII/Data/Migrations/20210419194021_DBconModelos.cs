using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoclubSWII.Data.Migrations
{
    public partial class DBconModelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compañias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compañias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(nullable: false),
                    FechaLanzamiento = table.Column<DateTime>(nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Portada = table.Column<string>(nullable: true),
                    compañiaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Peliculas_Compañias_compañiaId",
                        column: x => x.compañiaId,
                        principalTable: "Compañias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alquileres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pago = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    FechaComienzo = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    peliculaId = table.Column<int>(nullable: true),
                    compañiaId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alquileres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alquileres_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alquileres_Compañias_compañiaId",
                        column: x => x.compañiaId,
                        principalTable: "Compañias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alquileres_Peliculas_peliculaId",
                        column: x => x.peliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RelacionesCategoriaPelicula",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    peliculaId = table.Column<int>(nullable: true),
                    categoriaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelacionesCategoriaPelicula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelacionesCategoriaPelicula_Categorias_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RelacionesCategoriaPelicula_Peliculas_peliculaId",
                        column: x => x.peliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_UserId",
                table: "Alquileres",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_compañiaId",
                table: "Alquileres",
                column: "compañiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_peliculaId",
                table: "Alquileres",
                column: "peliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_compañiaId",
                table: "Peliculas",
                column: "compañiaId");

            migrationBuilder.CreateIndex(
                name: "IX_RelacionesCategoriaPelicula_categoriaId",
                table: "RelacionesCategoriaPelicula",
                column: "categoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_RelacionesCategoriaPelicula_peliculaId",
                table: "RelacionesCategoriaPelicula",
                column: "peliculaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alquileres");

            migrationBuilder.DropTable(
                name: "RelacionesCategoriaPelicula");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Compañias");
        }
    }
}
