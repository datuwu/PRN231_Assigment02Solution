using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObjects.Migrations
{
    /// <inheritdoc />
    public partial class SomeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BooksAuthors",
                table: "BooksAuthors");

            migrationBuilder.DropIndex(
                name: "IX_BooksAuthors_BookId",
                table: "BooksAuthors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BooksAuthors",
                table: "BooksAuthors",
                columns: new[] { "BookId", "AuthorId" });

            migrationBuilder.CreateIndex(
                name: "IX_BooksAuthors_AuthorId",
                table: "BooksAuthors",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BooksAuthors",
                table: "BooksAuthors");

            migrationBuilder.DropIndex(
                name: "IX_BooksAuthors_AuthorId",
                table: "BooksAuthors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BooksAuthors",
                table: "BooksAuthors",
                columns: new[] { "AuthorId", "BookId" });

            migrationBuilder.CreateIndex(
                name: "IX_BooksAuthors_BookId",
                table: "BooksAuthors",
                column: "BookId");
        }
    }
}
