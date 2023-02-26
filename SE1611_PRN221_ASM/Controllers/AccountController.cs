using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Infrastructure;
using Repository.Repository;
using SE1611_PRN221_ASM.Helper;
using SE1611_PRN221_ASM.Models;

namespace SE1611_PRN221_ASM.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AccountController> _logger;
        public AccountController(IUnitOfWork unitOfWork, ILogger<AccountController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        // GET: AccountController
        public async Task<ActionResult> Index(int page = 1)
        {
            var listOfAccounts = await _unitOfWork.AccountRepository.GetAllAccounts();
            
            int totalData = _unitOfWork.AccountRepository.CountData();
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
            return View(listOfAccounts);
        }
        [HttpPost]
        public async Task<IActionResult> DisableAccount(int accountId)
        {
            try
            {
                await _unitOfWork.AccountRepository.DisableAccount(accountId);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }
            return RedirectToAction(nameof(Index));
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

                if (loginAccount == null || String.IsNullOrEmpty(loginAccount.Email))
                {
                    TempData["Error"] = "Email or Password is incorrect";

                    return RedirectToAction(nameof(SignIn));
                }
                else if (loginAccount.Customer!.Status == (int)CustomerStatus.DISABLE)
                {
                    TempData["Error"] = "Account is in disable";
                    return RedirectToAction(nameof(SignIn));
                }
                else
                {
                    UserSession userSession = new UserSession
                    {
                        Email = loginAccount.Email,
                        Password = loginAccount.Password,
                        FullName = loginAccount.Customer!.Name!,
                        Gender = loginAccount.Customer.Gender!,
                        BirthDay = loginAccount.Customer.Birthday.ToString(),
                    };
                    HttpContext.Session.SetObject("UserSession", userSession);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: AccountController/SignUp
        [HttpPost]
        public async Task<ActionResult> SignUp(Account account, String name, String birthDay, String gender)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existAccount = await _unitOfWork.AccountRepository.FindAccountByEmail(account.Email);
                    if (existAccount != null)
                    {
                        TempData["SignUpError"] = "Account already exist";
                        return RedirectToAction(nameof(SignUp));
                    }
                    else
                    {
                        account.Customer = new Customer
                        {
                            Name = account.Customer!.Name,
                            Birthday = Convert.ToDateTime(birthDay),
                            Status = (int)CustomerStatus.AVAILABLE,
                            Gender = gender
                        };
                        await _unitOfWork.AccountRepository.SignUp(account);
                    }
                }
                //await _unitOfWork.AccountRepository.SendConfirmationMail();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(SignUp));
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
