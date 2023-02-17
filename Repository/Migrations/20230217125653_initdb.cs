using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    author = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    image_link = table.Column<string>(type: "varchar(511)", unicode: false, maxLength: 511, nullable: true),
                    price = table.Column<double>(type: "float", nullable: true),
                    publisher = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    quantity_left = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<short>(type: "smallint", nullable: true, defaultValueSql: "((0))"),
                    title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("books_pkey", x => x.book_id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    genre_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    genre_name = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Genres__18428D42264014B7", x => x.genre_id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__760965CCF7B86864", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "Book_genre",
                columns: table => new
                {
                    book_genre_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    book_id = table.Column<int>(type: "int", nullable: false),
                    genre_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Book_gen__3AF2D0E0B7D53204", x => x.book_genre_id);
                    table.ForeignKey(
                        name: "FK__Book_genr__book___31EC6D26",
                        column: x => x.book_id,
                        principalTable: "Books",
                        principalColumn: "book_id");
                    table.ForeignKey(
                        name: "FK__Book_genr__genre__32E0915F",
                        column: x => x.genre_id,
                        principalTable: "Genres",
                        principalColumn: "genre_id");
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    account_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Accounts__46A222CD4BD1145A", x => x.account_id);
                    table.ForeignKey(
                        name: "FK__Accounts__role_i__276EDEB3",
                        column: x => x.role_id,
                        principalTable: "Roles",
                        principalColumn: "role_id");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    birthday = table.Column<DateTime>(type: "date", nullable: true),
                    gender = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    status = table.Column<short>(type: "smallint", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__CD65CB85534F5168", x => x.customer_id);
                    table.ForeignKey(
                        name: "FK__Customers__custo__2A4B4B5E",
                        column: x => x.customer_id,
                        principalTable: "Accounts",
                        principalColumn: "account_id");
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    cart_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    book_id = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Carts__2EF52A27F5930AD2", x => x.cart_id);
                    table.ForeignKey(
                        name: "FK__Carts__book_id__3D5E1FD2",
                        column: x => x.book_id,
                        principalTable: "Books",
                        principalColumn: "book_id");
                    table.ForeignKey(
                        name: "FK__Carts__customer___3E52440B",
                        column: x => x.customer_id,
                        principalTable: "Customers",
                        principalColumn: "customer_id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    comment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "text", nullable: false),
                    rating = table.Column<double>(type: "float", nullable: true),
                    comment_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    book_id = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comments__E795768797212946", x => x.comment_id);
                    table.ForeignKey(
                        name: "FK__Comments__book_i__398D8EEE",
                        column: x => x.book_id,
                        principalTable: "Books",
                        principalColumn: "book_id");
                    table.ForeignKey(
                        name: "FK__Comments__custom__3A81B327",
                        column: x => x.customer_id,
                        principalTable: "Customers",
                        principalColumn: "customer_id");
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    favorite_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    book_id = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Favorite__46ACF4CB0936277D", x => x.favorite_id);
                    table.ForeignKey(
                        name: "FK__Favorites__book___35BCFE0A",
                        column: x => x.book_id,
                        principalTable: "Books",
                        principalColumn: "book_id");
                    table.ForeignKey(
                        name: "FK__Favorites__custo__36B12243",
                        column: x => x.customer_id,
                        principalTable: "Customers",
                        principalColumn: "customer_id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    phone = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    status = table.Column<short>(type: "smallint", nullable: true),
                    place_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    total_amount = table.Column<double>(type: "float", nullable: true),
                    customer_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__465962298E70F8CB", x => x.order_id);
                    table.ForeignKey(
                        name: "FK__Orders__customer__412EB0B6",
                        column: x => x.customer_id,
                        principalTable: "Customers",
                        principalColumn: "customer_id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    order_details_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<double>(type: "float", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    book_id = table.Column<int>(type: "int", nullable: false),
                    order_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderDet__F6FB5AE46DDE9327", x => x.order_details_id);
                    table.ForeignKey(
                        name: "FK__OrderDeta__book___440B1D61",
                        column: x => x.book_id,
                        principalTable: "Books",
                        principalColumn: "book_id");
                    table.ForeignKey(
                        name: "FK__OrderDeta__order__44FF419A",
                        column: x => x.order_id,
                        principalTable: "Orders",
                        principalColumn: "order_id");
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "book_id", "author", "description", "image_link", "price", "publisher", "quantity_left", "status", "title" },
                values: new object[,]
                {
                    { 1, "Barack Obama", "A riveting, deeply personal account of history in the making, from the president who inspired us to believe in the power of democracy.\nIn the stirring, highly anticipated first volume of his presidential memoirs, Barack Obama tells the story of his improbable odyssey from young man searching for his identity to leader of the free world, describing in strikingly personal detail both his political education and the landmark moments of the first term of his historic presidency—a time of dramatic transformation and turmoil.", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1600357110l/55361205._SY475_.jpg", 35.649999999999999, "All IndieLit", 79, (short)1, "A Promised Land" },
                    { 2, "Trevor Noah", "The memoir of one man’s coming-of-age, set during the twilight of apartheid and the tumultuous days of freedom that followed.\nTrevor Noah’s unlikely path from apartheid South Africa to the desk of The Daily Show began with a criminal act: his birth.Trevor was born to a white Swiss father and a black Xhosa mother at a time when such a union was punishable by five years in prison.Living proof of his parents’ indiscretion, Trevor was kept mostly indoors for the earliest years of his life, bound by the extreme and often absurd measures his mother took to hide him from a government that could, at any moment, steal him away.Finally liberated by the end of South Africa’s tyrannical white rule, Trevor and his mother set forth on a grand adventure, living openly and freely and embracing the opportunities won by a centuries - long struggle.\nBorn a Crime is the story of a mischievous young boy who grows into a restless young man as he struggles to find himself in a world where he was never supposed to exist.It is also the story of that young man’s relationship with his fearless, rebellious, and fervently religious mother—his teammate, a woman determined to save her son from the cycle of poverty, violence, and abuse that would ultimately threaten her own life. ", "https://firebasestorage.googleapis.com/v0/b/spring-react-learning.appspot.com/o/images%2F29780253.jpeg061384cb-9a74-4571-ad91-fc2ad166e157?alt=media&token=021c0026-7bc6-4da9-8727-4967f15f3848", 15.65, "Spiegel & Grau", 120, (short)1, "Born a Crime: Stories From a South African Childhood" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "genre_id", "genre_name" },
                values: new object[,]
                {
                    { 1, "Fiction" },
                    { 2, "Non-fiction" },
                    { 3, "Thriller" },
                    { 4, "Romance" },
                    { 5, "Art" },
                    { 6, "Sci-fi" },
                    { 7, "History" },
                    { 8, "Horror" },
                    { 9, "Adventure" },
                    { 10, "Folktale" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "role_id", "role_name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "account_id", "email", "password", "role_id" },
                values: new object[,]
                {
                    { 1, "admin@gmail.com", "$2a$11$Q/R1KNyKvoL0al40jLe8pu7HgpBoJW931wIvgRfAxz1g9fzfChS0C", 1 },
                    { 2, "khoabm@gmail.com", "$2a$11$z3ze8hRqM3.5MX4.tzEsMO/Ruy2pUDCYShBqo9p0fEfB9In2KwQbi", 2 },
                    { 3, "khaitq@gmail.com", "$2a$11$JQhrDkQaFD9MweWoG/l3g.0m9VnvWKK9CADryqwL57t/ojulOlxOe", 2 },
                    { 4, "mainh@gmail.com", "$2a$11$E631HzuRQsQRYNMvHszqBuJdefv.DvGHBtZJLb6UmzAGFU3fKnccG", 2 }
                });

            migrationBuilder.InsertData(
                table: "Book_genre",
                columns: new[] { "book_genre_id", "book_id", "genre_id" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "customer_id", "birthday", "gender", "name", "status" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "M", "Admin", (short)1 },
                    { 2, new DateTime(2000, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "M", "Bui Minh Khoa", (short)1 },
                    { 3, new DateTime(2000, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "M", "Tran Quang Khai", (short)1 },
                    { 4, new DateTime(2000, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "F", "Nguyen Hong Mai", (short)1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_role_id",
                table: "Accounts",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Accounts__AB6E61649EDB0C88",
                table: "Accounts",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_genre_book_id",
                table: "Book_genre",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_Book_genre_genre_id",
                table: "Book_genre",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_book_id",
                table: "Carts",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_customer_id",
                table: "Carts",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_book_id",
                table: "Comments",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_customer_id",
                table: "Comments",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_book_id",
                table: "Favorites",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_customer_id",
                table: "Favorites",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_book_id",
                table: "OrderDetails",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_order_id",
                table: "OrderDetails",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_customer_id",
                table: "Orders",
                column: "customer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book_genre");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
