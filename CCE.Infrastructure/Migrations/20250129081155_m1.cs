using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TypePoste",
                table: "TypePoste");

            migrationBuilder.RenameTable(
                name: "TypePoste",
                newName: "TypePostes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypePostes",
                table: "TypePostes",
                column: "Code");

            migrationBuilder.CreateTable(
                name: "ProductionPotentielles",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CodeLigne = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cadence = table.Column<long>(type: "bigint", nullable: true),
                    CadenceNominale = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionPotentielles", x => x.Code);
                    table.ForeignKey(
                        name: "FK_ProductionPotentielles_Lignes_CodeLigne",
                        column: x => x.CodeLigne,
                        principalTable: "Lignes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductionPotentielles_CodeLigne",
                table: "ProductionPotentielles",
                column: "CodeLigne");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionPotentielles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypePostes",
                table: "TypePostes");

            migrationBuilder.RenameTable(
                name: "TypePostes",
                newName: "TypePoste");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypePoste",
                table: "TypePoste",
                column: "Code");
        }
    }
}
