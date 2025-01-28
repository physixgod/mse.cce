using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypePoste",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePoste", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Usines",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usines", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Ateliers",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsineCode = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ateliers", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Ateliers_Usines_UsineCode",
                        column: x => x.UsineCode,
                        principalTable: "Usines",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecteurAteliers",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AtelierCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecteurAteliers", x => x.Code);
                    table.ForeignKey(
                        name: "FK_SecteurAteliers_Ateliers_AtelierCode",
                        column: x => x.AtelierCode,
                        principalTable: "Ateliers",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lignes",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Computer_Input = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Computer_Output = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Equation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecteurAtelierCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lignes", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Lignes_SecteurAteliers_SecteurAtelierCode",
                        column: x => x.SecteurAtelierCode,
                        principalTable: "SecteurAteliers",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ateliers_UsineCode",
                table: "Ateliers",
                column: "UsineCode");

            migrationBuilder.CreateIndex(
                name: "IX_Lignes_SecteurAtelierCode",
                table: "Lignes",
                column: "SecteurAtelierCode");

            migrationBuilder.CreateIndex(
                name: "IX_SecteurAteliers_AtelierCode",
                table: "SecteurAteliers",
                column: "AtelierCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lignes");

            migrationBuilder.DropTable(
                name: "TypePoste");

            migrationBuilder.DropTable(
                name: "SecteurAteliers");

            migrationBuilder.DropTable(
                name: "Ateliers");

            migrationBuilder.DropTable(
                name: "Usines");
        }
    }
}
