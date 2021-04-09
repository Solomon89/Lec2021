using Microsoft.EntityFrameworkCore.Migrations;

namespace Lec2021.Migrations
{
    public partial class addOwnerOfTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestsModels_AspNetUsers_UserTestId",
                table: "TestsModels");

            migrationBuilder.DropForeignKey(
                name: "FK_TestsModels_People_CreatorId",
                table: "TestsModels");

            migrationBuilder.RenameColumn(
                name: "UserTestId",
                table: "TestsModels",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "TestsModels",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_TestsModels_UserTestId",
                table: "TestsModels",
                newName: "IX_TestsModels_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_TestsModels_CreatorId",
                table: "TestsModels",
                newName: "IX_TestsModels_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestsModels_AspNetUsers_OwnerId",
                table: "TestsModels",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestsModels_People_PersonId",
                table: "TestsModels",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestsModels_AspNetUsers_OwnerId",
                table: "TestsModels");

            migrationBuilder.DropForeignKey(
                name: "FK_TestsModels_People_PersonId",
                table: "TestsModels");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "TestsModels",
                newName: "UserTestId");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "TestsModels",
                newName: "CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_TestsModels_PersonId",
                table: "TestsModels",
                newName: "IX_TestsModels_UserTestId");

            migrationBuilder.RenameIndex(
                name: "IX_TestsModels_OwnerId",
                table: "TestsModels",
                newName: "IX_TestsModels_CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestsModels_AspNetUsers_UserTestId",
                table: "TestsModels",
                column: "UserTestId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestsModels_People_CreatorId",
                table: "TestsModels",
                column: "CreatorId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
