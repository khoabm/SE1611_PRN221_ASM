
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SE1611_PRN221_ASM.Helper;


using Repository.Infrastructure;

using SE1611_PRN221_ASM.Models;
using System.Diagnostics;
using Repository.Entities;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace SE1611_PRN221_ASM.Controllers
{
    [SessionAuthorize]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HomeController> _logger;
        public HomeController(IUnitOfWork unitOfWork, ILogger<HomeController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }


        [AllowAnonymous]
        public IActionResult Index()
        {
            var books = new List<Book>();
            var booksByDate = new List<Book>();
            var genresByBook = new List<Genre>();
            try
            {
                //books = _unitOfWork.BookRepository.GetAll().ToList();
                books = _unitOfWork.BookRepository.GetBooksOrderByAverageRating().ToList();
                booksByDate = _unitOfWork.BookRepository.GetBooksOrderByAddedDate().ToList();
                //Console.WriteLine(books2.Count);
                genresByBook = _unitOfWork.GenreRepository.GetGenresOrderByNumberOfBooks().ToList();
                ViewBag.BooksByDate = booksByDate.Take(6);
                ViewBag.GenresByBook = genresByBook;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }


            return View(books);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult LoadBooks(string tab)
        {
            List<Book> books = new List<Book>();
            try
            {
                books = _unitOfWork.BookRepository.GetBooksOrderByCategory(tab).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }


            return PartialView("_ModelPartialView", books);
        }
        [AllowAnonymous]
        public IActionResult ContactUs()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult AboutUs()
        {
            return View("About");
        }
        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl = "/")
        {
            return Challenge(new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleSignIn", "Home", null, Request.Scheme, Request.Host.ToString())
            }, "Google");
        }
        [AllowAnonymous]
        public async Task<IActionResult> GoogleSignIn()
        {
            // Set session data
            var result = await HttpContext.AuthenticateAsync("Google");
            if (result.Succeeded)
            {
                UserSession userSession = new UserSession
                {
                    Email = result.Principal.FindFirstValue(ClaimTypes.Email),
                    Password = "",
                    FullName = "Khoa Bui",
                    Gender = "M",
                    BirthDay = new DateTime(2002, 06, 27),
                    RoleId = 2,
                };
                HttpContext.Session.SetObject("UserSession", userSession);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}