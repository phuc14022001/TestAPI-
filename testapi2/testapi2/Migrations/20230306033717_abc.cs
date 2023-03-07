using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testapi2.Migrations
{
    public partial class abc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_phong_tangs_IdTang",
                table: "phong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_phong",
                table: "phong");

            migrationBuilder.RenameTable(
                name: "phong",
                newName: "phongs");

            migrationBuilder.RenameIndex(
                name: "IX_phong_IdTang",
                table: "phongs",
                newName: "IX_phongs_IdTang");

            migrationBuilder.AddPrimaryKey(
                name: "PK_phongs",
                table: "phongs",
                column: "IdPhong");

            migrationBuilder.AddForeignKey(
                name: "FK_phongs_tangs_IdTang",
                table: "phongs",
                column: "IdTang",
                principalTable: "tangs",
                principalColumn: "IdTang",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_phongs_tangs_IdTang",
                table: "phongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_phongs",
                table: "phongs");

            migrationBuilder.RenameTable(
                name: "phongs",
                newName: "phong");

            migrationBuilder.RenameIndex(
                name: "IX_phongs_IdTang",
                table: "phong",
                newName: "IX_phong_IdTang");

            migrationBuilder.AddPrimaryKey(
                name: "PK_phong",
                table: "phong",
                column: "IdPhong");

            migrationBuilder.AddForeignKey(
                name: "FK_phong_tangs_IdTang",
                table: "phong",
                column: "IdTang",
                principalTable: "tangs",
                principalColumn: "IdTang",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
