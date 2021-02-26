using Microsoft.EntityFrameworkCore.Migrations;

namespace Lec2021.Migrations
{
    public partial class AddPeople : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "TestsModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestsModels_CreatorId",
                table: "TestsModels",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestsModels_People_CreatorId",
                table: "TestsModels",
                column: "CreatorId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestsModels_People_CreatorId",
                table: "TestsModels");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropIndex(
                name: "IX_TestsModels_CreatorId",
                table: "TestsModels");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "TestsModels");
        }
    }
}
