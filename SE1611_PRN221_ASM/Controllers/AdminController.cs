
using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> MyAction()
        {
            // Upload a file to Firebase Storage
            try
            {
                var fileStream = new MemoryStream(Encoding.UTF8.GetBytes("Hello, world!"));

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
                        .Child("my-folder")
                        .Child("my-text-2.txt")
                        .PutAsync(fileStream, cancellation.Token);
                String downloadUrl = await task;
                Console.WriteLine(downloadUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
            
            return RedirectToAction(nameof(Index));
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


        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
