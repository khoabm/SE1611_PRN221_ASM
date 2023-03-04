using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Infrastructure;
using SE1611_PRN221_ASM.Helper;
using SE1611_PRN221_ASM.Models;

namespace SE1611_PRN221_ASM.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FavoriteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: FavoriteController
        public async Task<IActionResult> Index()
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

            return View(list);
        }


        // GET: FavoriteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FavoriteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FavoriteController/Create
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

        // GET: FavoriteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FavoriteController/Edit/5
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

        // GET: FavoriteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FavoriteController/Delete/5
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
