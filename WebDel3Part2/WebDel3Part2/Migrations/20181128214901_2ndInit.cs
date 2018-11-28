using Microsoft.EntityFrameworkCore.Migrations;

namespace WebDel3Part2.Migrations
{
    public partial class _2ndInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentType_ESImage_ImageESImageId",
                table: "ComponentType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESImage",
                table: "ESImage");

            migrationBuilder.RenameTable(
                name: "ESImage",
                newName: "EsImages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EsImages",
                table: "EsImages",
                column: "ESImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentType_EsImages_ImageESImageId",
                table: "ComponentType",
                column: "ImageESImageId",
                principalTable: "EsImages",
                principalColumn: "ESImageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentType_EsImages_ImageESImageId",
                table: "ComponentType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EsImages",
                table: "EsImages");

            migrationBuilder.RenameTable(
                name: "EsImages",
                newName: "ESImage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESImage",
                table: "ESImage",
                column: "ESImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentType_ESImage_ImageESImageId",
                table: "ComponentType",
                column: "ImageESImageId",
                principalTable: "ESImage",
                principalColumn: "ESImageId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
