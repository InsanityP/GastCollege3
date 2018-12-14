using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GastCollege3.Migrations
{
    public partial class updateeee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AanbiederId",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Full",
                table: "Events",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Aanbieder",
                columns: table => new
                {
                    AanbiederId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aanbieder", x => x.AanbiederId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_AanbiederId",
                table: "Events",
                column: "AanbiederId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Aanbieder_AanbiederId",
                table: "Events",
                column: "AanbiederId",
                principalTable: "Aanbieder",
                principalColumn: "AanbiederId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Aanbieder_AanbiederId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Aanbieder");

            migrationBuilder.DropIndex(
                name: "IX_Events_AanbiederId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "AanbiederId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Full",
                table: "Events");
        }
    }
}
