using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$Uw1/YfvQVTleaIhs.KwXPOnFGx1g9kkaIwQwW6x8m0XyHEMmSQBwy");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$z0DpVE2voBdzIWLhuV6fUel/JbINsYyJeAYuaPqaO6jXlAxp07dPO");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$BhYSpNSNaF.WtgrTzyXwVOvDU/hqGRvXp2F4CSjxpAnBRdEOT3LzW");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$ATWMcq9xxixZeiclgeIMn.J.Pvz7M0K9aYWLS7Svvi1Vwy/G.wHou");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$zgqaM3B8rVXxuPkTIW4/9ehpMIZ4akCIj6IPT/pT1W2IkPg3ZTT8e");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 6,
                column: "password",
                value: "$2a$11$lWWBW4ntXqmmoeoAYr5KrutZR5RxuNIxM7oNUeRyuUyz7KrrWZqK6");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 7,
                column: "password",
                value: "$2a$11$OeUPgMD6aloseNyUn/.SWeMZCnIKmfIx3wR0Ck/fX.aIoNPPGiACK");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 8,
                column: "password",
                value: "$2a$11$qq7SnWwlAh86aUz03cfdE.rhzpLuguPtoidpJSliYiqA5LdfAU6oq");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 9,
                column: "password",
                value: "$2a$11$6VYJbOuaL8ZBuyF50cxufeBsgDl4mp7HZfD0pDVnpqN8d/VGBqPIW");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 10,
                column: "password",
                value: "$2a$11$9z3Ug8zvrql7cRbdKL53MefUuAEkSLN5ifvp9zKrQRigQB/q/7Jqe");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 11,
                column: "password",
                value: "$2a$11$pb7g9wacLUjJqmafTwXpd.59Fh70Re3ZC0l6IURlawBNQfmFhOZsK");

            migrationBuilder.InsertData(
                table: "Book_genre",
                columns: new[] { "book_genre_id", "book_id", "genre_id" },
                values: new object[,]
                {
                    { 3, 1, 7 },
                    { 4, 3, 7 },
                    { 5, 6, 2 },
                    { 6, 7, 3 },
                    { 7, 8, 4 },
                    { 8, 9, 5 },
                    { 9, 10, 6 },
                    { 10, 11, 7 },
                    { 11, 12, 9 },
                    { 12, 13, 8 },
                    { 13, 14, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 13);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$aHrgPIrDD7/v4SJm/gS5/OQwImI6dxG.UIRGHRFwkVbJDRY9nlfWC");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$8UQpJoZB3k5Dt6f2WyxXAubNGZCKNcq2W9QATEIOmtBD/479gNi86");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$8YH3HGQEH4vaajxBiSdnjuIpAs1XAwtrv/INDt/N8tqGhySH3/m4y");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$dmbx58/nhew6Fzs4qITRO.OPvQpN9YZYUnMX6TWEn.9bAEoGhQBsW");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$f1FDuApKFd/Gice7JBDYBOyV6AhdlRGDd09N7V5POWIG2oMjfNmSG");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 6,
                column: "password",
                value: "$2a$11$9gWAmq74vvrN9UbNbbUnIuJASGzjXLFlHTZD84lV8KawInTxLmfGG");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 7,
                column: "password",
                value: "$2a$11$rQfL9nV7idjDXBcD6MOqretT442tQOHxresAC/v5O32iu0wRQ3rRa");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 8,
                column: "password",
                value: "$2a$11$TnMl4CL0ffWRCr/Foxfy4OO5wRPJr0or2/rDBS382s98WpgQYcwqa");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 9,
                column: "password",
                value: "$2a$11$l7H4laSQ4aSJCL5o2OnIwOnXpzi51Kbk8u54a82XBYpx7g.hrveia");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 10,
                column: "password",
                value: "$2a$11$PaT9NtIGP4wV9anzTmD24.meymjkZtpYZuTa/t1jNYxVatzJZzw5q");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 11,
                column: "password",
                value: "$2a$11$WY/kmiWk1H7zVKwq0NHeZOdMmwXYBB3cHRJC2QBUd3dokKdZlXTKG");
        }
    }
}
