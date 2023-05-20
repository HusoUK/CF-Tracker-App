using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CFTrackerServices.Migrations
{
    /// <inheritdoc />
    public partial class newForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BodyMassIndexes_Users_UserId",
                table: "BodyMassIndexes");

            migrationBuilder.DropForeignKey(
                name: "FK_LungFunctions_Users_UserId",
                table: "LungFunctions");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "LungFunctions",
                newName: "UserInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_LungFunctions_UserId",
                table: "LungFunctions",
                newName: "IX_LungFunctions_UserInfoId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BodyMassIndexes",
                newName: "UserInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_BodyMassIndexes_UserId",
                table: "BodyMassIndexes",
                newName: "IX_BodyMassIndexes_UserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_BodyMassIndexes_Users_UserInfoId",
                table: "BodyMassIndexes",
                column: "UserInfoId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LungFunctions_Users_UserInfoId",
                table: "LungFunctions",
                column: "UserInfoId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BodyMassIndexes_Users_UserInfoId",
                table: "BodyMassIndexes");

            migrationBuilder.DropForeignKey(
                name: "FK_LungFunctions_Users_UserInfoId",
                table: "LungFunctions");

            migrationBuilder.RenameColumn(
                name: "UserInfoId",
                table: "LungFunctions",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_LungFunctions_UserInfoId",
                table: "LungFunctions",
                newName: "IX_LungFunctions_UserId");

            migrationBuilder.RenameColumn(
                name: "UserInfoId",
                table: "BodyMassIndexes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BodyMassIndexes_UserInfoId",
                table: "BodyMassIndexes",
                newName: "IX_BodyMassIndexes_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BodyMassIndexes_Users_UserId",
                table: "BodyMassIndexes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LungFunctions_Users_UserId",
                table: "LungFunctions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
