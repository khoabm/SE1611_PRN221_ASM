using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Infrastructure;
using SE1611_PRN221_ASM.Helper;
using SE1611_PRN221_ASM.Models;

namespace SE1611_PRN221_ASM.Controllers
{
    [SessionAuthorize]
    public class FavoriteController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FavoriteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: FavoriteController
        public async Task<IActionResult> Index(int page = 1, int pageSize = 9)
        {
            var userSession = HttpContext.Session.GetObject<UserSession>("UserSession");

            if (userSession == null)
            {
                TempData["Message"] = "Please log in first.";
                return View("EmptyFavorite");
            }

            var account = await _unitOfWork.AccountRepository.FindAccountByEmail(userSession.Email);

            int customerId = account.AccountId;
            var list = _unitOfWork.FavoriteRepository.GetFavoriteByCustomerId(customerId);

            if (list == null || !list.Any())
            {
                TempData["Message"] = "You have not added any favorites.";
                return View("EmptyFavorite");
            }

            var totalItems = list.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            list = list.Skip((page - 1) * pageSize).Take(pageSize);
            var startPage = Math.Max(1, page - pageSize);
            var endPage = Math.Min(totalPages, page + pageSize);
            var pagination = new PaginationViewModel
            {
                CurrentPage = page,
                TotalPages = totalPages,
                StartPage = startPage,
                EndPage = endPage
            };
            ViewBag.Pagination = pagination;
            ViewBag.PageSize = pageSize;
            
            return View(list);
        }


        // GET: FavoriteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add(int bookId)
        {
            var userSession = HttpContext.Session.GetObject<UserSession>("UserSession");

            if (userSession == null)
            {
                TempData["Message"] = "Please log in first.";
                return View("EmptyFavorite");
            }

            var account = await _unitOfWork.AccountRepository.FindAccountByEmail(userSession.Email);

            int customerId = account.AccountId;

            var existingFavorite = _unitOfWork.FavoriteRepository.GetByBookIdAndCustomerId(bookId, customerId);

            if (existingFavorite != null)
            {
                TempData["Message"] = "This book is already in your favorites.";
                return RedirectToAction("Index");
            }

            var favorite = new Favorite
            {
                BookId = bookId,
                CustomerId = customerId
            };

            _unitOfWork.FavoriteRepository.Create(favorite);
            _unitOfWork.Save();

            userSession.FavoriteItemCount++;
            HttpContext.Session.SetObject("UserSession", userSession);

            TempData["Success"] = "Added to favorites successfully.";

            string url = Request.Headers["Referer"].ToString();

            return Redirect(url);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int bookId)
        {
            var userSession = HttpContext.Session.GetObject<UserSession>("UserSession");

            if (userSession == null)
            {
                TempData["Message"] = "Please log in first.";
                return View("EmptyFavorite");
            }

            var account = await _unitOfWork.AccountRepository.FindAccountByEmail(userSession.Email);

            int customerId = account.AccountId;
            var favoriteItem = _unitOfWork.FavoriteRepository.GetByBookIdAndCustomerId(bookId, customerId);

            if (favoriteItem == null)
            {
                return NotFound();
            }

            _unitOfWork.FavoriteRepository.Delete(favoriteItem);
            _unitOfWork.Save();

            userSession.FavoriteItemCount--;
            HttpContext.Session.SetObject("UserSession", userSession);

            TempData["Success"] = "Removed book from favorites.";

            string url = Request.Headers["Referer"].ToString();

            return Redirect(url);
        }
    }
}
