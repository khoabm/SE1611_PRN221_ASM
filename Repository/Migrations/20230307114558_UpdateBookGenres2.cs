using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookGenres2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$vMBjodhcUy5vOcRYOfu02.wz810YysFrHOBKa5Kq5DSBS29MoJLVW");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$ymdioOZMhly81x8HOMeqUu4j4oZHkJM/Z78ontam4tKmcfio4/Os2");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$M.EV9MeRgPd4lnTMXSlZYedYq4jQf3NJYvsERLlohDvLe7cBCGwhi");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$gz/xeqPy.0UoqggUBtmCOOfDbg4xXa0yay6ondWEHVGtafkQSFeZ6");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$tODVCpYfjotcuB0YeZb98OSmH5tn5IZ295MXF27DDPPiPUVbJipPO");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 6,
                column: "password",
                value: "$2a$11$f.kLwjnxXDu1sExPsDrth.kxD8ROg/VQXzWzgAdVescKUDpxQVcEi");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 7,
                column: "password",
                value: "$2a$11$bN7KNsUKNqbF6OxLJ8aiS.H/t3hwaVSjngomzH1o2d4nwPIOjGJgi");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 8,
                column: "password",
                value: "$2a$11$gNucaMA61Mgho5ijH7wprOnA2gwptDO7d56eFG.X.iqwjtzYeLeoa");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 9,
                column: "password",
                value: "$2a$11$..dKs54L16bZCWu3.2T6IODp6o3wyDSoCHKsGPTLvX4iEViNCJJzi");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 10,
                column: "password",
                value: "$2a$11$Z.NFysx9DpG02L.SmY3mkOk099Ic4I8E77H7LHNz5fQYo900l2Zf2");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 11,
                column: "password",
                value: "$2a$11$fDLa2GSpFEpdXD.Zq0K3cOc.PX9MgkAiPp8h6iPMfUZh2WoOAvpzm");

            migrationBuilder.UpdateData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 13,
                column: "book_id",
                value: 13);

            migrationBuilder.InsertData(
                table: "Book_genre",
                columns: new[] { "book_genre_id", "book_id", "genre_id" },
                values: new object[,]
                {
                    { 14, 13, 5 },
                    { 15, 14, 10 },
                    { 16, 15, 5 },
                    { 17, 15, 2 },
                    { 18, 19, 7 },
                    { 19, 39, 7 },
                    { 20, 39, 9 },
                    { 21, 16, 1 },
                    { 22, 16, 7 },
                    { 23, 17, 1 },
                    { 24, 17, 7 },
                    { 25, 18, 1 },
                    { 26, 18, 7 },
                    { 27, 20, 2 },
                    { 28, 21, 3 },
                    { 29, 21, 8 },
                    { 30, 22, 2 },
                    { 31, 22, 5 },
                    { 32, 23, 1 },
                    { 33, 23, 3 },
                    { 34, 24, 3 },
                    { 35, 24, 1 },
                    { 36, 24, 8 },
                    { 37, 25, 3 },
                    { 38, 25, 8 },
                    { 39, 26, 3 },
                    { 40, 26, 1 },
                    { 41, 27, 9 },
                    { 42, 28, 9 },
                    { 43, 31, 2 },
                    { 44, 31, 2 },
                    { 45, 32, 2 },
                    { 46, 33, 2 },
                    { 47, 34, 2 },
                    { 48, 35, 2 },
                    { 49, 36, 2 },
                    { 50, 36, 9 },
                    { 51, 36, 4 },
                    { 52, 37, 1 },
                    { 53, 37, 6 },
                    { 54, 38, 4 },
                    { 55, 38, 5 },
                    { 56, 40, 2 },
                    { 57, 40, 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 57);

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

            migrationBuilder.UpdateData(
                table: "Book_genre",
                keyColumn: "book_genre_id",
                keyValue: 13,
                column: "book_id",
                value: 14);
        }
    }
}
