using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class SeedCustomerData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$LuVXu4z2izB5AGbr8PkCUO3urg1DyrFuW1MEcRCgCfvRlU9Uqot5W");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$cOVsoiD.QtWsZ4cPYNscGO0woRwOBykpH1ORnAhWMy3Dz2nF.zfjy");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$bdLf3gdK3qUUO0jYOb1yYeRdON1jmmXIaTbtVqTYXC9BrqdhCaWz2");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$IAqsvenleUcp3PfZGTA2huQFOZs5C1dAmUCWr8W88q8NLYtz9CXc.");

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "account_id", "email", "password", "role_id" },
                values: new object[,]
                {
                    { 5, "dangvungocan@gmail.com", "$2a$11$L.UelH77wJ4vgi6Gy.En8OH9pRgceJ3AVd2sVcrz.O6fbqEyW2QKG", 2 },
                    { 6, "duongthekhang@gmail.com", "$2a$11$vB/hmdxsolBpaEWHbyp/7.cYbJLsKKCIMi5I/eOOkcC4Zpck2tXR2", 2 },
                    { 7, "giangphuongthao@gmail.com", "$2a$11$83KXaIAc.N0QwUV1V/J69OTJ4Ba034AiRpSPAY9g6eVP.KNItR8Su", 2 },
                    { 8, "letrandao@gmail.com", "$2a$11$knBb94.ORyoZ0vhW8WOwp.vwX6CZCbYCGWNWX.fh2M0e.PhW.2u.y", 2 },
                    { 9, "ngoquocbao@gmail.com", "$2a$11$sFJq7C.SyeAIRrVgELQYs.jeM0QG2EpTm5OhC3yeohXVTylFfUVwm", 2 },
                    { 10, "hoanghuyentrang@gmail.com", "$2a$11$2N22iTOMNIbhfMhMq4LjC.U2jmjgNQ0jIBL6OBEuWWyyXt5H7Ou6W", 2 },
                    { 11, "hoangtung@gmail.com", "$2a$11$o2xq8Cd2w.nxkBX0ePuHleZojaByUGH.P7AUmlrHvEK7KOxHgiBKO", 2 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "customer_id", "birthday", "gender", "name", "status" },
                values: new object[,]
                {
                    { 5, new DateTime(1987, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "M", "Dang Vu Ngoc An", (short)1 },
                    { 6, new DateTime(1995, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "F", "Duong The Khang", (short)1 },
                    { 7, new DateTime(1988, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "F", "Giang Phuong Thao", (short)1 },
                    { 8, new DateTime(1987, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "M", "Le Tran Dao", (short)1 },
                    { 9, new DateTime(1977, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "M", "Ngo Quoc Bao", (short)1 },
                    { 10, new DateTime(1995, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "F", "Hoang Huyen Trang", (short)1 },
                    { 11, new DateTime(2000, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "F", "Hoang Tung", (short)1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customer_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customer_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customer_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customer_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customer_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customer_id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customer_id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$n1Nmj7vC5eay2G0n8NSsd.Fh.hU7iWopKZo.YRUS.qEYObyvo4I3K");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$vr2mQPWXaQuOzRwu/EtE5uXBpysmvcpjlN4vfgN1uOwQ5K3hUdgyu");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$nl0.1a.w5F/mVtzAYRDtTeEmRqqPE1i1d/pPdhBjzKHYBNqA.irwK");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$K8/VhEzgfW3.v96LfanrSeA4.v4hsWiyKT9LZV9D./akwawn7aq.e");
        }
    }
}
