using Microsoft.EntityFrameworkCore.Migrations;

namespace Barta_Timea_Proiect.Migrations
{
    public partial class WineAssortment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandID",
                table: "Wine",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Assortment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssortmentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assortment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WineAssortment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WineID = table.Column<int>(nullable: false),
                    AssortmentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineAssortment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WineAssortment_Assortment_AssortmentID",
                        column: x => x.AssortmentID,
                        principalTable: "Assortment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WineAssortment_Wine_WineID",
                        column: x => x.WineID,
                        principalTable: "Wine",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wine_BrandID",
                table: "Wine",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_WineAssortment_AssortmentID",
                table: "WineAssortment",
                column: "AssortmentID");

            migrationBuilder.CreateIndex(
                name: "IX_WineAssortment_WineID",
                table: "WineAssortment",
                column: "WineID");

            migrationBuilder.AddForeignKey(
                name: "FK_Wine_Brand_BrandID",
                table: "Wine",
                column: "BrandID",
                principalTable: "Brand",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wine_Brand_BrandID",
                table: "Wine");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "WineAssortment");

            migrationBuilder.DropTable(
                name: "Assortment");

            migrationBuilder.DropIndex(
                name: "IX_Wine_BrandID",
                table: "Wine");

            migrationBuilder.DropColumn(
                name: "BrandID",
                table: "Wine");
        }
    }
}
