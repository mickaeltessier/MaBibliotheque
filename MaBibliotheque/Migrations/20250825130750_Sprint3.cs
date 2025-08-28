using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaBibliotheque.Migrations
{
    /// <inheritdoc />
    public partial class Sprint3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publisher_Books_BookId",
                table: "Publisher");

            migrationBuilder.DropIndex(
                name: "IX_Publisher_BookId",
                table: "Publisher");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Publisher");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Publisher",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Publisher_BookId",
                table: "Publisher",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publisher_Books_BookId",
                table: "Publisher",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
