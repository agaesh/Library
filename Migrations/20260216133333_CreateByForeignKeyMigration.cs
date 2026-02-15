using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class CreateByForeignKeyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreateById",
                table: "Borrows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_CreateById",
                table: "Borrows",
                column: "CreateById");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Users_CreateById",
                table: "Borrows",
                column: "CreateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Users_CreateById",
                table: "Borrows");

            migrationBuilder.DropIndex(
                name: "IX_Borrows_CreateById",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "Borrows");
        }
    }
}
