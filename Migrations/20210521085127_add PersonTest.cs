using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lec2021.Migrations
{
    public partial class addPersonTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    TestsModelId = table.Column<int>(type: "int", nullable: true),
                    TestStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonTests_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonTests_TestsModels_TestsModelId",
                        column: x => x.TestsModelId,
                        principalTable: "TestsModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonTests_PersonId",
                table: "PersonTests",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonTests_TestsModelId",
                table: "PersonTests",
                column: "TestsModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonTests");
        }
    }
}
