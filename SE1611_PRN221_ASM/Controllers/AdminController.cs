
using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Infrastructure;
using SE1611_PRN221_ASM.Helper;
using SE1611_PRN221_ASM.Models;
using System.Text;

namespace SE1611_PRN221_ASM.Controllers
{
    
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AccountController> _logger;

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
        public ActionResult Index()
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
        public async Task<IActionResult> Accounts(String orderBy, String status, int page = 1, [FromQuery] String query = "")
        {
            Console.WriteLine(query);
            var (listOfAccounts, totalData) = await _unitOfWork.AccountRepository.SearchAccountsWithPagination(orderBy, status, page, 5, query);

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
            return View(listOfAccounts);
        }

        // GET: AdminController/Create
        [HttpGet]
        public ActionResult Create()
        {
            List<Book> books = _unitOfWork.BookRepository.GetAll().ToList();
            ViewBag.Genres = _unitOfWork.GenreRepository.GetAll().ToList();
            return View(books);
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string title, string author, string description, string publisher, string price, string quantity, int status, int[] genres, IFormFile picture)
        {
            try
            {
                string bookauthor = title + author;
                string imgurl = await UploadToFirebase(picture, bookauthor, Path.GetExtension(picture.FileName));
                Book book = new Book();
                book.Title = title;
                book.Author = author;
                book.Description = description;
                book.Publisher = publisher;
                book.Price = float.Parse(price.Replace(",",""));
                book.QuantityLeft = int.Parse(quantity.Replace(",",""));
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
                
                //Console.WriteLine(file.FileName);
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return RedirectToAction(nameof(Create));
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        public async Task<ActionResult> Disable(int accountId)
        {
            try
            {
                await _unitOfWork.AccountRepository.DisableAccount(accountId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
