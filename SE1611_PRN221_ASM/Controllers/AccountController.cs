using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Repository.Entities;
using Repository.Infrastructure;
using Repository.Repository;
using SE1611_PRN221_ASM.Helper;
using SE1611_PRN221_ASM.Models;
using System.Security.Claims;

namespace SE1611_PRN221_ASM.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AccountController> _logger;
        private readonly IHubContext<NotificationHub> _hubContext;
        public AccountController(IUnitOfWork unitOfWork, ILogger<AccountController> logger, IHubContext<NotificationHub> hubContext)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _hubContext = hubContext;
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
            TempData["Success"] = "Demo Success";
            TempData["Error"] = "Demo Error";
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
        [SessionAuthorize]
        [HttpGet]
        public async Task<IActionResult> Details()

        {
            var account = new Account();
            try
            {
                var userSession = HttpContext.Session.GetObject<UserSession>("UserSession");
                account = await _unitOfWork.AccountRepository.FindAccountByEmail(userSession!.Email);
                if(account == null) return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw new Exception();
            }
            return View("AccountDetails", account);
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
                        BirthDay = loginAccount.Customer.Birthday,
                        RoleId = loginAccount.RoleId,
                    };
                    var cartItemCount = _unitOfWork.CartRepository.GetCartByCustomerId(loginAccount.Customer.CustomerId).Count();
                    var favoriteItemCount = _unitOfWork.FavoriteRepository.GetFavoriteByCustomerId(loginAccount.Customer.CustomerId).Count();
                    userSession.CartItemCount = cartItemCount;
                    userSession.FavoriteItemCount = favoriteItemCount;

                    HttpContext.Session.SetObject("UserSession", userSession);
                    HttpContext.Session.GetObject<UserSession>("UserSession");
                }
                return RedirectToAction(nameof(Index), "Home");
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

        
        [SessionAuthorize]
        [HttpPost]
        public async Task<ActionResult> Update(Account account)
        {
            
            try
            {
                Console.WriteLine(account.Customer.Birthday.ToString());
                //var userSession = HttpContext.Session.GetObject<UserSession>("UserSession");
                //var updatedAccount = await _unitOfWork.AccountRepository.UpdateAccount(userSession!.Email);
                //if(updatedAccount != null)
                //{
                //    UserSession updatedUserSession = new UserSession
                //    {
                //        Email = updatedAccount.Email,
                //        Password = updatedAccount.Password,
                //        FullName = updatedAccount.Customer!.Name!,
                //        Gender = updatedAccount.Customer.Gender!,
                //        BirthDay = updatedAccount.Customer.Birthday,
                //        RoleId = updatedAccount.RoleId
                //    };

                //    HttpContext.Session.SetObject("UserSession", userSession);
                //}
            }
            catch (Exception)
            {
                TempData["UpdateError"] = "Update failed";
                throw new Exception();
            }
            return RedirectToAction(nameof(Details));
        }

        // POST: AccountController/Edit/5
        //[HttpGet]
        //public ActionResult Edit()
        //{

        //}

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }


        //[HttpGet]
        //public IActionResult SignInWithGoogle()
        //{

        //    var authenticationProperties = new AuthenticationProperties
        //    {
        //        RedirectUri = Url.Action("","/signin-google")
        //    };
        //    Console.WriteLine("Google ne`");
        //    return Challenge(new AuthenticationProperties {RedirectUri = "/signin-google" }, GoogleDefaults.AuthenticationScheme);
        //}

        //[HttpGet]
        //public async Task<IActionResult> HandleGoogleSignIn()
        //{
        //    var authenticateResult = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
        //    Console.WriteLine("Handle google signin");
        //    if (!authenticateResult.Succeeded)
        //    {
        //        Console.WriteLine("AUTHENTICATED FAILED");
        //        // Handle the sign-in failure
        //    }

        //    var email = authenticateResult.Principal.FindFirst(ClaimTypes.Email)?.Value;

        //    // Sign in the user
        //    // ...

        //    return RedirectToAction(nameof(HomeController.Index), "Home");
        //}

    }
}
