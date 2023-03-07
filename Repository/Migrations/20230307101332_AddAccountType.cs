using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "AccountType",
                table: "Accounts",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 1,
                columns: new[] { "AccountType", "password" },
                values: new object[] { (short)1, "$2a$11$aHrgPIrDD7/v4SJm/gS5/OQwImI6dxG.UIRGHRFwkVbJDRY9nlfWC" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 2,
                columns: new[] { "AccountType", "password" },
                values: new object[] { (short)1, "$2a$11$8UQpJoZB3k5Dt6f2WyxXAubNGZCKNcq2W9QATEIOmtBD/479gNi86" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 3,
                columns: new[] { "AccountType", "password" },
                values: new object[] { (short)1, "$2a$11$8YH3HGQEH4vaajxBiSdnjuIpAs1XAwtrv/INDt/N8tqGhySH3/m4y" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 4,
                columns: new[] { "AccountType", "password" },
                values: new object[] { (short)1, "$2a$11$dmbx58/nhew6Fzs4qITRO.OPvQpN9YZYUnMX6TWEn.9bAEoGhQBsW" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 5,
                columns: new[] { "AccountType", "password" },
                values: new object[] { (short)1, "$2a$11$f1FDuApKFd/Gice7JBDYBOyV6AhdlRGDd09N7V5POWIG2oMjfNmSG" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 6,
                columns: new[] { "AccountType", "password" },
                values: new object[] { (short)1, "$2a$11$9gWAmq74vvrN9UbNbbUnIuJASGzjXLFlHTZD84lV8KawInTxLmfGG" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 7,
                columns: new[] { "AccountType", "password" },
                values: new object[] { (short)1, "$2a$11$rQfL9nV7idjDXBcD6MOqretT442tQOHxresAC/v5O32iu0wRQ3rRa" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 8,
                columns: new[] { "AccountType", "password" },
                values: new object[] { (short)1, "$2a$11$TnMl4CL0ffWRCr/Foxfy4OO5wRPJr0or2/rDBS382s98WpgQYcwqa" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 9,
                columns: new[] { "AccountType", "password" },
                values: new object[] { (short)1, "$2a$11$l7H4laSQ4aSJCL5o2OnIwOnXpzi51Kbk8u54a82XBYpx7g.hrveia" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 10,
                columns: new[] { "AccountType", "password" },
                values: new object[] { (short)1, "$2a$11$PaT9NtIGP4wV9anzTmD24.meymjkZtpYZuTa/t1jNYxVatzJZzw5q" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 11,
                columns: new[] { "AccountType", "password" },
                values: new object[] { (short)1, "$2a$11$WY/kmiWk1H7zVKwq0NHeZOdMmwXYBB3cHRJC2QBUd3dokKdZlXTKG" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "Accounts");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$7SS1oUFKdNiCbRznzPWjB./V7nZMi7TdQlyM4DI5oJPEXQ2/GnFJW");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$PF/mdyY8GNXr59t3/llzCuFvOevStHW3vNt5l73MbCEQer0NT4CY6");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$gqjVZISoG/kCZWk43v/tF.BKCm8nVNjphDP0Hl2Yb6t0.CiNWHK2G");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$f2s5Q.iUKMP.EVj2Y5NRfOwzuRtrQTBbBWUWcWMq7.vOgHpV5puBC");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$0nZMDIIdt0zKXihQAsyY8.eP7UKNlHlc23pTd/Ri9gdl40g8ycZKO");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 6,
                column: "password",
                value: "$2a$11$WnhHBRMlLdeMsOz5qbFxo.ZTX9BjSJZ9MUHmx/4ko458QfSp2uwr6");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 7,
                column: "password",
                value: "$2a$11$R4PlhUgjEyoDMMVLQW4JdOgQgiOub.Hxgpsd7a5He5r.AY5nHEPu.");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 8,
                column: "password",
                value: "$2a$11$JeAzI5ngeGTXAiMO0Qc7TuFRWpyf12yWyyIwCbVwDQ1BroMskzYqS");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 9,
                column: "password",
                value: "$2a$11$DSeqlu8I6TOL7ebeMTOIh.XYu.ZXXnaOhloxZTxnI3.yosqRH/tTy");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 10,
                column: "password",
                value: "$2a$11$9rl/SM7ooc2AYR4.ONA94.sRU2nZFLvDgFRjZo1HUv37a87clqTri");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 11,
                column: "password",
                value: "$2a$11$f9j/d0MZMU1MJkjOaNxhPudV00j9bNXEUMF6R8MB7UlAXnP4rB9rO");
        }
    }
}
