using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BussinessObjects.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Address", "City", "Email", "FirstName", "LastName", "Phone", "State", "Zip" },
                values: new object[,]
                {
                    { 1, "123 Main St", "New York", "john.doe@example.com", "John", "Doe", "123-456-7890", "NY", "10001" },
                    { 2, "456 Elm St", "Los Angeles", "jane.smith@example.com", "Jane", "Smith", "987-654-3210", "CA", "90001" },
                    { 3, "789 Oak St", "Chicago", "michael.johnson@example.com", "Michael", "Johnson", "555-555-5555", "IL", "60001" },
                    { 4, "101 Pine St", "London", "emily.brown@example.com", "Emily", "Brown", "111-222-3333", null, "W1A 1AA" },
                    { 5, "555 Cedar St", "Sydney", "david.wilson@example.com", "David", "Wilson", "444-444-4444", "NSW", "2000" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "City", "Country", "PublisherName", "State" },
                values: new object[,]
                {
                    { 1, "New York", "USA", "Publisher A", "NY" },
                    { 2, "Los Angeles", "USA", "Publisher B", "CA" },
                    { 3, "Chicago", "USA", "Publisher C", "IL" },
                    { 4, "London", "UK", "Publisher D", "DJ" },
                    { 5, "Sydney", "Australia", "Publisher E", "NSW" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Editor" },
                    { 3, "Author" },
                    { 4, "Reader" },
                    { 5, "Guest" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Advance", "Note", "Price", "PublishedDate", "PublisherId", "Royalty", "Title", "Type", "YTDSales" },
                values: new object[,]
                {
                    { 1, "10.00", "Great book!", 19.989999999999998, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "20.00", "Book 1", "Fiction", null },
                    { 2, "15.00", "Informative", 24.989999999999998, new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "25.00", "Book 2", "Non-Fiction", null },
                    { 3, "12.00", "Thriller", 17.989999999999998, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "22.00", "Book 3", "Mystery", null },
                    { 4, "14.00", "Out of this world", 21.989999999999998, new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "24.00", "Book 4", "Science Fiction", null },
                    { 5, "8.00", "Love story", 14.99, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "18.00", "Book 5", "Romance", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "HireDate", "LastName", "MiddleName", "Password", "PublisherId", "RoleId", "Source" },
                values: new object[,]
                {
                    { 1, "admin@example.com", "Admin", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "adminpass", null, 1, "Internal" },
                    { 2, "editor@example.com", "Editor", new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "editorpass", null, 2, "Internal" },
                    { 3, "author@example.com", "Author", new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "authorpass", 1, 3, "External" },
                    { 4, "reader@example.com", "Reader", new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "readerpass", 2, 4, "External" },
                    { 5, "guest@example.com", "Guest", new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "guestpass", null, 5, "External" }
                });

            migrationBuilder.InsertData(
                table: "BooksAuthors",
                columns: new[] { "AuthorId", "BookId", "AuthorOrder", "RoyalityPercentage" },
                values: new object[,]
                {
                    { 1, 1, "Primary", 10 },
                    { 2, 1, "Secondary", 20 },
                    { 3, 2, "Primary", 15 },
                    { 4, 3, "Primary", 12 },
                    { 5, 4, "Primary", 18 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
