using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebDel3Part2.Migrations
{
    public partial class admins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserWrapper",
                columns: table => new
                {
                    AdminId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AdminId",
                table: "AspNetUsers",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Admin_AdminId",
                table: "AspNetUsers",
                column: "AdminId",
                principalTable: "UserWrapper",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Admin_AdminId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UserWrapper");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AdminId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "AspNetUsers");
        }
    }
}
