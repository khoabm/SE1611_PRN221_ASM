using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$Q/R1KNyKvoL0al40jLe8pu7HgpBoJW931wIvgRfAxz1g9fzfChS0C");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$z3ze8hRqM3.5MX4.tzEsMO/Ruy2pUDCYShBqo9p0fEfB9In2KwQbi");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$JQhrDkQaFD9MweWoG/l3g.0m9VnvWKK9CADryqwL57t/ojulOlxOe");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "account_id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$E631HzuRQsQRYNMvHszqBuJdefv.DvGHBtZJLb6UmzAGFU3fKnccG");
        }
    }
}
