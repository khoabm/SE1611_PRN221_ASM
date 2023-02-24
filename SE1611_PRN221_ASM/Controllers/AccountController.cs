using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Infrastructure;
using SE1611_PRN221_ASM.Helper;
using SE1611_PRN221_ASM.Models;

namespace SE1611_PRN221_ASM.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: AccountController
        public async Task<ActionResult> Index()
        {
            var listOfAccounts = await _unitOfWork.AccountRepository.GetAllAccounts();
            return View(listOfAccounts);
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult SignIn()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        public async Task<ActionResult> SignIn(Account account)
        {
            try
            {
                var loginAccount = await _unitOfWork.AccountRepository.SignIn(account);

                if (loginAccount == null) return View();
                UserSession userSession = new UserSession
                {
                    Email = loginAccount.Email,
                    Password = loginAccount.Password,
                    FullName = loginAccount.Customer.Name!,
                    Gender = loginAccount.Customer.Gender!,
                    BirthDay = loginAccount.Customer.Birthday.ToString(),
                };
                HttpContext.Session.SetObject("UserSession", userSession);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
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

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
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
