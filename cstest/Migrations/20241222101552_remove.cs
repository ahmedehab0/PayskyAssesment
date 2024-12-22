using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cstest.Migrations
{
    /// <inheritdoc />
    public partial class remove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountHolders_AccountHolderId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountHolderId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountHolderId",
                table: "Accounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountHolderId",
                table: "Accounts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountHolderId",
                table: "Accounts",
                column: "AccountHolderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountHolders_AccountHolderId",
                table: "Accounts",
                column: "AccountHolderId",
                principalTable: "AccountHolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
