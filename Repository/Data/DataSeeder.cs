using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository.Data
{
    public static class DataSeeder
    {
        public static void SeedRole(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasData(
                    new Role() { RoleId = 1, RoleName = "Admin" },
                    new Role() { RoleId = 2, RoleName = "Customer" }
                );
        }
        public static void SeedGenre(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .HasData(
                    new Genre() { GenreId = 1, GenreName = "Fiction" },
                    new Genre() { GenreId = 2, GenreName = "Non-fiction" },
                    new Genre() { GenreId = 3, GenreName = "Thriller" },
                    new Genre() { GenreId = 4, GenreName = "Romance" },
                    new Genre() { GenreId = 5, GenreName = "Art" },
                    new Genre() { GenreId = 6, GenreName = "Sci-fi" },
                    new Genre() { GenreId = 7, GenreName = "History" },
                    new Genre() { GenreId = 8, GenreName = "Horror" },
                    new Genre() { GenreId = 9, GenreName = "Adventure" },
                    new Genre() { GenreId = 10, GenreName = "Folktale" }
                );
        }
        public static void SeedBook(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasData(
                    new Book()
                    {
                        BookId = 1,
                        Author = "Barack Obama",
                        Description = "A riveting, deeply personal account of history in the making, from the president who inspired us to believe in the power of democracy.\nIn the stirring, highly anticipated first volume of his presidential memoirs, Barack Obama tells the story of his improbable odyssey from young man searching for his identity to leader of the free world, describing in strikingly personal detail both his political education and the landmark moments of the first term of his historic presidency—a time of dramatic transformation and turmoil.",
                        ImageLink = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1600357110l/55361205._SY475_.jpg",
                        Price = 35.65,
                        Publisher = "All IndieLit",
                        QuantityLeft = 79,
                        Status = 1,
                        Title = "A Promised Land"
                    },
                    new Book()
                    {
                        BookId = 2,
                        Author = "Trevor Noah",
                        Description = "The memoir of one man’s coming-of-age, set during the twilight of apartheid and the tumultuous days of freedom that followed.\nTrevor Noah’s unlikely path from apartheid South Africa to the desk of The Daily Show began with a criminal act: his birth.Trevor was born to a white Swiss father and a black Xhosa mother at a time when such a union was punishable by five years in prison.Living proof of his parents’ indiscretion, Trevor was kept mostly indoors for the earliest years of his life, bound by the extreme and often absurd measures his mother took to hide him from a government that could, at any moment, steal him away.Finally liberated by the end of South Africa’s tyrannical white rule, Trevor and his mother set forth on a grand adventure, living openly and freely and embracing the opportunities won by a centuries - long struggle.\nBorn a Crime is the story of a mischievous young boy who grows into a restless young man as he struggles to find himself in a world where he was never supposed to exist.It is also the story of that young man’s relationship with his fearless, rebellious, and fervently religious mother—his teammate, a woman determined to save her son from the cycle of poverty, violence, and abuse that would ultimately threaten her own life. ",
                        ImageLink = "https://firebasestorage.googleapis.com/v0/b/spring-react-learning.appspot.com/o/images%2F29780253.jpeg061384cb-9a74-4571-ad91-fc2ad166e157?alt=media&token=021c0026-7bc6-4da9-8727-4967f15f3848",
                        Price = 15.65,
                        Publisher = "Spiegel & Grau",
                        QuantityLeft = 120,
                        Status = 1,
                        Title = "Born a Crime: Stories From a South African Childhood"
                    }, new Book()
                    {
                        BookId = 3,
                        Author = "Johann Hari",
                        Description = "The memoir of one man’s coming-of-age, set during the twilight of apartheid and the tumultuous days of freedom that followed.\nTrevor Noah’s unlikely path from apartheid South Africa to the desk of The Daily Show began with a criminal act: his birth.Trevor was born to a white Swiss father and a black Xhosa mother at a time when such a union was punishable by five years in prison.Living proof of his parents’ indiscretion, Trevor was kept mostly indoors for the earliest years of his life, bound by the extreme and often absurd measures his mother took to hide him from a government that could, at any moment, steal him away.Finally liberated by the end of South Africa’s tyrannical white rule, Trevor and his mother set forth on a grand adventure, living openly and freely and embracing the opportunities won by a centuries - long struggle.\nBorn a Crime is the story of a mischievous young boy who grows into a restless young man as he struggles to find himself in a world where he was never supposed to exist.It is also the story of that young man’s relationship with his fearless, rebellious, and fervently religious mother—his teammate, a woman determined to save her son from the cycle of poverty, violence, and abuse that would ultimately threaten her own life. ",
                        ImageLink = "https://firebasestorage.googleapis.com/v0/b/spring-react-learning.appspot.com/o/images%2F29780253.jpeg061384cb-9a74-4571-ad91-fc2ad166e157?alt=media&token=021c0026-7bc6-4da9-8727-4967f15f3848",
                        Price = 15.65,
                        Publisher = "Spiegel & Grau",
                        QuantityLeft = 120,
                        Status = 1,
                        Title = "Born a Crime: Stories From a South African Childhood"
                    }
                );
        }
        public static void SeedBookGenre(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookGenre>()
                .HasData(
                    new BookGenre() { BookGenreId = 1, BookId = 1, GenreId = 2 },
                    new BookGenre() { BookGenreId = 2, BookId = 2, GenreId = 2 }
                );
        }
        public static void SeedAccount(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasData(
                    new Account()
                    {
                        AccountId = 1,
                        Email = "admin@gmail.com",
                        Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                        RoleId = 1,
                    },
                    new Account()
                    {
                        AccountId = 2,
                        Email = "khoabm@gmail.com",
                        Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                        RoleId = 2,
                    },
                    new Account()
                    {
                        AccountId = 3,
                        Email = "khaitq@gmail.com",
                        Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                        RoleId = 2,
                    },
                    new Account()
                    {
                        AccountId = 4,
                        Email = "mainh@gmail.com",
                        Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                        RoleId = 2,
                    }, 
                    new Account()
                    {
                        AccountId = 5,
                        Email = "dangvungocan@gmail.com",
                        Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                        RoleId = 2,
                    }, 
                    new Account()
                    {
                        AccountId = 6,
                        Email = "duongthekhang@gmail.com",
                        Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                        RoleId = 2,
                    }, 
                    new Account()
                    {
                        AccountId = 7,
                        Email = "giangphuongthao@gmail.com",
                        Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                        RoleId = 2,
                    }, 
                    new Account()
                    {
                        AccountId = 8,
                        Email = "letrandao@gmail.com",
                        Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                        RoleId = 2,
                    }, 
                    new Account()
                    {
                        AccountId = 9,
                        Email = "ngoquocbao@gmail.com",
                        Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                        RoleId = 2,
                    }, 
                    new Account()
                    {
                        AccountId = 10,
                        Email = "hoanghuyentrang@gmail.com",
                        Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                        RoleId = 2,
                    }, 
                    new Account()
                    {
                        AccountId = 11,
                        Email = "hoangtung@gmail.com",
                        Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                        RoleId = 2,
                    }
                );
        }
        public static void SeedCustomer(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasData(
                    new Customer()
                    {
                        CustomerId = 1,
                        Birthday = new DateTime(2000, 8, 10),
                        Gender = "M",
                        Name = "Admin",
                        Status = 1
                    },
                    new Customer()
                    {
                        CustomerId = 2,
                        Birthday = new DateTime(2000, 5, 10),
                        Gender = "M",
                        Name = "Bui Minh Khoa",
                        Status = 1
                    },
                    new Customer()
                    {
                        CustomerId = 3,
                        Birthday = new DateTime(2000, 4, 10),
                        Gender = "M",
                        Name = "Tran Quang Khai",
                        Status = 1
                    },
                    new Customer()
                    {
                        CustomerId = 4,
                        Birthday = new DateTime(2000, 11, 10),
                        Gender = "F",
                        Name = "Nguyen Hong Mai",
                        Status = 1
                    }, 
                    new Customer()
                    {
                        CustomerId = 5,
                        Birthday = new DateTime(1987, 04, 02),
                        Gender = "M",
                        Name = "Dang Vu Ngoc An",
                        Status = 1
                    }, 
                    new Customer()
                    {
                        CustomerId = 6,
                        Birthday = new DateTime(1995, 08, 05),
                        Gender = "F",
                        Name = "Duong The Khang",
                        Status = 1
                    }, new Customer()
                    {
                        CustomerId = 7,
                        Birthday = new DateTime(1988, 12, 24),
                        Gender = "F",
                        Name = "Giang Phuong Thao",
                        Status = 1
                    }, new Customer()
                    {
                        CustomerId = 8,
                        Birthday = new DateTime(1987, 10, 06),
                        Gender = "M",
                        Name = "Le Tran Dao",
                        Status = 1
                    }, new Customer()
                    {
                        CustomerId = 9,
                        Birthday = new DateTime(1977, 08, 22),
                        Gender = "M",
                        Name = "Ngo Quoc Bao",
                        Status = 1
                    }, new Customer()
                    {
                        CustomerId = 10,
                        Birthday = new DateTime(1995, 09, 18),
                        Gender = "F",
                        Name = "Hoang Huyen Trang",
                        Status = 1
                    }, new Customer()
                    {
                        CustomerId = 11,
                        Birthday = new DateTime(2000, 12, 10),
                        Gender = "F",
                        Name = "Hoang Tung",
                        Status = 1
                    }
                );
        }
    }
}
