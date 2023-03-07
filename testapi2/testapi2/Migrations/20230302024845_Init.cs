using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testapi2.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tangs",
                columns: table => new
                {
                    IdTang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSonha = table.Column<int>(type: "int", nullable: false),
                    ChuTro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tangs", x => x.IdTang);
                });

            migrationBuilder.CreateTable(
                name: "phong",
                columns: table => new
                {
                    IdPhong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoPhong = table.Column<int>(type: "int", nullable: false),
                    TenChuPhong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTang = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phong", x => x.IdPhong);
                    table.ForeignKey(
                        name: "FK_phong_tangs_IdTang",
                        column: x => x.IdTang,
                        principalTable: "tangs",
                        principalColumn: "IdTang",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_phong_IdTang",
                table: "phong",
                column: "IdTang");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "phong");

            migrationBuilder.DropTable(
                name: "tangs");
        }
    }
}
