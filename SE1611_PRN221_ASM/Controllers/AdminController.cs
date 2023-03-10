
using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Entities;
using Repository.Infrastructure;
using SE1611_PRN221_ASM.Helper;
using SE1611_PRN221_ASM.Models;
using System.Text;

namespace SE1611_PRN221_ASM.Controllers
{
    [SessionAuthorize]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AccountController> _logger;
        private static string[] sortOptions = { "latest", "oldest" };


        private static String ApiKey = "AIzaSyCIaH3IzEahld6Nt_kb8EmPxgZ1hqZ-4GQ";
        private static String Bucket = "bookseller-5f813.appspot.com";
        private static String Email = "minhkhoa2706@gmail.com";
        private static String Password = "khoaminh2706";

        public AdminController(IUnitOfWork unitOfWork, ILogger<AccountController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;

        }

        // GET: AdminController
        public ActionResult Index(string query = ""
            , double minPrice = 0
            , double maxPrice = 1000000000
            , int page = 1
            , int size = 9
            , string sort = "latest")
        {
            //var list = _unitOfWork.OrderRepository.GetAll();
            if (query == null) query = "";
            var (orders, totalItems) = _unitOfWork.OrderRepository.SearchOrders(query, minPrice, maxPrice, page, size, sort);
            //string[] orderSortOptions = new string[2];
            //orderSortOptions[0] = sort;
            //int j = 1;
            //for (int i = 0; i < 2; i++)
            //{
            //    if (!sortOptions[j].Equals(sort))
            //    {
            //        orderSortOptions[j] = sortOptions[i];
            //        j++;
            //    }
            //}
            var totalPages = (int)Math.Ceiling((double)totalItems / size);
            var startPage = Math.Max(1, page - size);
            var endPage = Math.Min(totalPages, page + size);
            var pagination = new PaginationViewModel
            {
                CurrentPage = page,
                TotalPages = totalPages,
                StartPage = startPage,
                EndPage = endPage
            };
            var statistics = new StatisticsViewModel
            {
                TotalCustomers = _unitOfWork.CustomerRepository.GetAll().Count() - 1,
                TotalBooksSold = _unitOfWork.OrderRepository.GetTotalBookSold(),
                BooksSoldThisMonth = _unitOfWork.OrderRepository.GetBooksSoldThisMonth(),
                TotalEarnings = _unitOfWork.OrderRepository.GetTotalEarnings()
            };
            ViewBag.Statistics = statistics;
            ViewBag.Pagination = pagination;
            ViewBag.TotalItems = totalItems;
            ViewBag.Sort = sort;
            ViewBag.Query = query;
            foreach (var o in orders)
            {
                var customer = _unitOfWork.CustomerRepository.GetById(o.CustomerId);
                o.Customer = customer;
            }
            return View(orders);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateStatus(int id)
        {
            return View();
        }
        private async Task<MemoryStream> ConvertToMemoryStreamAsync(IFormFile file)
        {
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0; // Reset the position to the beginning of the stream
            return memoryStream;
        }
        private async Task<String> UploadToFirebase(IFormFile file, string bookAuthor, string extension)
        {
            // Upload a file to Firebase Storage
            String downloadUrl = "";
            try
            {
                var fileStream = await ConvertToMemoryStreamAsync(file);

                var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                var a = await auth.SignInWithEmailAndPasswordAsync(Email, Password);

                var cancellation = new CancellationTokenSource();

                var task = new FirebaseStorage(
                        Bucket,
                     new FirebaseStorageOptions
                     {
                         AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                         ThrowOnCancel = true,
                     })
                        .Child("book-cover")
                        .Child(bookAuthor + extension)
                        .PutAsync(fileStream, cancellation.Token);
                downloadUrl = await task;
                Console.WriteLine(downloadUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }

            return downloadUrl;
            // ...
        }
        public async Task<IActionResult> Accounts(string orderBy = "id", int page = 1, string query = "")
        {
            if (query == null) query = "";
            var (listOfAccounts, totalData) = await _unitOfWork.AccountRepository.SearchAccountsWithPagination(orderBy, page, 5, query);

            //int totalData = _unitOfWork.AccountRepository.CountData();
            // Calculate pagination data
            var totalPages = (int)Math.Ceiling((double)totalData / 5);

            var startPage = Math.Max(1, page - 5);
            var endPage = Math.Min(totalPages, page + 5);
            _logger.LogInformation(totalData.ToString());
            // Create a PaginationViewModel object and store it in the ViewBag or ViewData
            var pagination = new PaginationViewModel
            {
                CurrentPage = page,
                TotalPages = totalPages,
                StartPage = startPage,
                EndPage = endPage
            };

            ViewBag.Pagination = pagination;
            ViewBag.Query = query;
            ViewBag.OrderBy = orderBy;
            return View(listOfAccounts);
        }

        // GET: AdminController/Create
        [HttpGet("/admin/book")]
        public ActionResult Create(int page = 1)
        {
            List<Book> books = _unitOfWork.BookRepository.GetAll().ToList();
            var totalData = books.Count;
            var totalPages = (int)Math.Ceiling((double)totalData / 7);
            var startPage = Math.Max(1, page - 7);
            var endPage = Math.Min(totalPages, page + 7);

            // Create a PaginationViewModel object and store it in the ViewBag or ViewData
            var pagination = new PaginationViewModel
            {
                CurrentPage = page,
                TotalPages = totalPages,
                StartPage = startPage,
                EndPage = endPage
            };

            ViewBag.Pagination = pagination;
            ViewBag.Genres = _unitOfWork.GenreRepository.GetAll().ToList();
            return View(PaginatedList<Book>.Create(books.AsQueryable(), page, 7));
        }
        private bool IsPicture(IFormFile file)
        {
            // List of known picture file extensions
            var pictureExtensions = new[] { ".jpg", ".jpeg", ".png", ".bmp" };

            // Get the file extension of the uploaded file
            var fileExtension = Path.GetExtension(file.FileName).ToLower();

            // Check if the file extension is in the list of known picture extensions
            return pictureExtensions.Contains(fileExtension);
        }
        // POST: AdminController/Create
        [HttpPost("/admin/book")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string title, string author, string description, string publisher, string price, string quantity, int status, int[] genres, IFormFile picture)
        {
            try
            {
                if (IsPicture(picture))
                {
                    string bookauthor = title + author;
                    string imgurl = await UploadToFirebase(picture, bookauthor, Path.GetExtension(picture.FileName));
                    Book book = new Book();
                    book.Title = title;
                    book.Author = author;
                    book.Description = description;
                    book.Publisher = publisher;
                    book.Price = Math.Round(float.Parse(price.Replace(",", "")), 2);
                    book.QuantityLeft = int.Parse(quantity.Replace(",", ""));
                    book.Status = Convert.ToInt16(status);
                    book.ImageLink = imgurl;
                    book.AddedDate = DateTime.UtcNow;
                    _unitOfWork.BookRepository.Create(book);
                    _unitOfWork.Save();
                    foreach (var genre in genres)
                    {
                        _unitOfWork.BookRepository.CreateBookGenre(book.BookId, genre);
                        _unitOfWork.Save();
                    }
                    TempData["Success"] = "Book added";
                    return RedirectToAction(nameof(Create));
                }
                else
                {
                    TempData["Error"] = "Picture is wrong format";
                    return RedirectToAction(nameof(Create));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                TempData["Error"] = e.Message.ToString();
                return RedirectToAction(nameof(Create));
            }
        }

        // GET: AdminController/Edit/5
        [HttpGet("/admin/details")]
        public ActionResult Edit(int id, int page = 1)
        {
            Book book = _unitOfWork.BookRepository.GetById(id);
            if (book != null)
            {
                var (comments, totalData) = _unitOfWork.CommentRepository.GetAllCommentOfABook(id, page);
                var totalPages = (int)Math.Ceiling((double)totalData / 3);
                var startPage = Math.Max(1, page - 3);
                var endPage = Math.Min(totalPages, page + 3);
                // Create a PaginationViewModel object and store it in the ViewBag or ViewData
                var pagination = new PaginationViewModel
                {
                    CurrentPage = page,
                    TotalPages = totalPages,
                    StartPage = startPage,
                    EndPage = endPage
                };
                ViewBag.BookGenres = _unitOfWork.BookRepository.GetBookGenres(id);
                ViewBag.Pagination = pagination;
                ViewBag.Book = book;
                ViewBag.Genres = _unitOfWork.GenreRepository.GetAll().ToList();
                ViewBag.Comments = comments;
                return View();
            }
            else return RedirectToAction(nameof(Create));
        }

        // POST: AdminController/Edit/5
        [HttpPost("/admin/details")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string title, string author, string description, string publisher, string price, string quantity, int status, int[] genres, IFormFile? picture)
        {
            try
            {
                Book book = _unitOfWork.BookRepository.GetById(id);
                if (book != null)
                {
                    string bookauthor = title + author;
                    string imgurl = book.ImageLink;
                    if (picture != null)
                    {
                        if (IsPicture(picture))
                        {
                            imgurl = await UploadToFirebase(picture, bookauthor, Path.GetExtension(picture.FileName));
                        }
                        else return RedirectToAction(nameof(Edit), id);
                    }
                    book.Title = title;
                    book.Author = author;
                    book.Description = description;
                    book.Publisher = publisher;
                    book.Price = Math.Round(float.Parse(price.Replace(",", "")), 2);
                    book.QuantityLeft = int.Parse(quantity.Replace(",", ""));
                    book.Status = Convert.ToInt16(status);
                    book.ImageLink = imgurl;
                    _unitOfWork.BookRepository.Update(book);
                    _unitOfWork.Save();
                    List<BookGenre> bg = _unitOfWork.BookGenreRepository.GetAll().Where(bookgenre => bookgenre.BookId == id).ToList();
                    foreach (var bookGenre in bg)
                    {
                        _unitOfWork.BookGenreRepository.Delete(bookGenre);
                        _unitOfWork.Save();
                    }
                    foreach (var genre in genres)
                    {
                        _unitOfWork.BookRepository.CreateBookGenre(book.BookId, genre);
                        _unitOfWork.Save();
                    }
                    //Update thanh cong ne
                    TempData["Success"] = "Book updated";
                    return RedirectToAction(nameof(Create));
                }
                // book id = null
                TempData["Error"] = "Book not found";
                return RedirectToAction(nameof(Create));
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message.ToString();
                Console.WriteLine(e.Message.ToString());
                return RedirectToAction(nameof(Edit), id);
            }
        }
        [HttpPost("/admin/delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Book book = _unitOfWork.BookRepository.GetById(id);
                if (book != null)
                {
                    List<BookGenre> bg = _unitOfWork.BookGenreRepository.GetAll().Where(bookgenre => bookgenre.BookId == id).ToList();
                    foreach (var bookGenre in bg)
                    {
                        _unitOfWork.BookGenreRepository.Delete(bookGenre);
                        _unitOfWork.Save();
                    }
                    _unitOfWork.BookRepository.Delete(book);
                    _unitOfWork.Save();
                    TempData["Success"] = "Book deleted";
                }
                else
                {
                    TempData["Error"] = "Book not found";
                }
            }
            catch(Exception e)
            {
                TempData["Error"] = e.Message.ToString();
            }
            return RedirectToAction(nameof(Create));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: AdminController/Delete/5
        public async Task<ActionResult> Disable(int accountId, string status)
        {
            try
            {
                await _unitOfWork.AccountRepository.DisableAccount(accountId, status);
                
                TempData["Success"] = "Updated successfully";
                return Redirect(Request.Headers["Referer"].ToString());
            }
            catch
            {
                TempData["Error"] = "Update user status failed";
                return Redirect(Request.Headers["Referer"].ToString());
            }
        }

        [HttpGet("/admin/book/search")]
        public ActionResult Search(string query, int page = 1)
        {
            try
            {
                var (books, totalItems) = _unitOfWork.BookRepository.SearchBooksAdmin(query, new string[0], 0, 1000000, page, 7, "latest");
                var totalData = totalItems;
                var totalPages = (int)Math.Ceiling((double)totalData / 7);
                var startPage = Math.Max(1, page - 7);
                var endPage = Math.Min(totalPages, page + 7);

                // Create a PaginationViewModel object and store it in the ViewBag or ViewData
                var pagination = new PaginationViewModel
                {
                    CurrentPage = page,
                    TotalPages = totalPages,
                    StartPage = startPage,
                    EndPage = endPage
                };
                Console.WriteLine(pagination);
                ViewBag.Pagination = pagination;
                ViewBag.Genres = _unitOfWork.GenreRepository.GetAll().ToList();
                return View("Create", PaginatedList<Book>.Create(books.AsQueryable(), page, 7));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Create));
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOrder(int orderId, short orderStatus)
        {
            var order = _unitOfWork.OrderRepository.GetById(orderId);
            order.Status = orderStatus;
            _unitOfWork.OrderRepository.Update(order);
            _unitOfWork.Save();

            //var list = _unitOfWork.OrderRepository.GetAll();
            //var list = _unitOfWork.OrderRepository.GetAll();
            var statistics = new StatisticsViewModel
            {
                TotalCustomers = _unitOfWork.CustomerRepository.GetAll().Count() - 1,
                TotalBooksSold = _unitOfWork.OrderRepository.GetTotalBookSold(),
                BooksSoldThisMonth = _unitOfWork.OrderRepository.GetBooksSoldThisMonth(),
                TotalEarnings = _unitOfWork.OrderRepository.GetTotalEarnings()
            };
            ViewBag.Statistics = statistics;

            return Redirect(Request.Headers["Referer"].ToString());
        }


        public ActionResult OrderDetail(int id)
        {
            var orders = _unitOfWork.OrderDetailRepository.GetOrderDetailByOrderId(id);

            return View(orders);
        }


    }
}
