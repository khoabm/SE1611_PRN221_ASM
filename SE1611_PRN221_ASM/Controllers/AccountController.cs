using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Repository.Entities;
using Repository.Infrastructure;
using Repository.Repository;
using SE1611_PRN221_ASM.Helper;
using SE1611_PRN221_ASM.Models;
using System.Security.Claims;
using Bcrypt = BCrypt.Net.BCrypt;
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
            var customer = new Customer();
            try
            {
                var userSession = HttpContext.Session.GetObject<UserSession>("UserSession");
                var account = await _unitOfWork.AccountRepository.FindAccountByEmail(userSession!.Email);

                if (account == null) return RedirectToAction(nameof(Index));
                customer = account.Customer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
            return View("AccountDetails", customer);
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
                        AccountType = loginAccount.AccountType
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
                        Birthday = Convert.ToDateTime(birthDay).Equals(default(DateTime)) ? null : Convert.ToDateTime(birthDay),
                        Status = (int)CustomerStatus.AVAILABLE,
                        Gender = gender
                    };
                    account.AccountType = (int)AccountType.EMAIL;
                    await _unitOfWork.AccountRepository.SignUp(account);
                }

                //await _unitOfWork.AccountRepository.SendConfirmationMail();
                return RedirectToAction(nameof(SignIn));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(SignUp));
            }
        }


        [SessionAuthorize]
        [HttpPost]
        public async Task<ActionResult> Update(Customer customer)
        {

            try
            {
                var userSession = HttpContext.Session.GetObject<UserSession>("UserSession");
                //Get the user from email on session
                var user = await _unitOfWork.AccountRepository.FindAccountByEmail(userSession!.Email);
                //Return if null
                if (user == null)
                {
                    TempData["Error"] = "Update failed";
                    return RedirectToAction(nameof(Details));
                }

                //Add data for update customer
                user.Customer!.Name = customer.Name;
                user.Customer!.Birthday = customer.Birthday;
                user.Customer!.Gender = customer.Gender;

                var updatedAccount = await _unitOfWork.AccountRepository.UpdateAccount(user.Customer);
                if (updatedAccount != null)
                {
                    UserSession updatedUserSession = new UserSession
                    {
                        Email = userSession!.Email,
                        Password = userSession.Password,
                        FullName = updatedAccount.Name!,
                        Gender = updatedAccount.Gender!,
                        BirthDay = updatedAccount.Birthday,
                        RoleId = userSession.RoleId
                    };

                    HttpContext.Session.SetObject("UserSession", updatedUserSession);
                    TempData["Success"] = "Update successful";
                }
            }
            catch (Exception)
            {
                TempData["Error"] = "Update failed";
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
        public async Task<IActionResult> LogOut()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Delete the authentication cookie
            Response.Cookies.Delete(CookieAuthenticationDefaults.AuthenticationScheme);
            Response.Cookies.Delete(GoogleDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> SendMail()
        {
            await _unitOfWork.AccountRepository.SendConfirmationMail();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [SessionAuthorize]
        public IActionResult ChangePassword()
        {
            var userSession = HttpContext.Session.GetObject<UserSession>("UserSession");
            if(userSession != null)
            {
                if(userSession.AccountType == 2) {
                return RedirectToAction(nameof(Details));
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("ChangePassword")]
        [SessionAuthorize]
        public async Task<IActionResult> ChangePasswordPost(string oldPassword, string password)
        {
            try
            {
                var userSession = HttpContext.Session.GetObject<UserSession>("UserSession");
                var user = await _unitOfWork.AccountRepository.FindAccountByEmail(userSession!.Email);
                if (user != null)
                {

                    if (Bcrypt.Verify(oldPassword, user.Password))
                    {
                        user.Password = Bcrypt.HashPassword(password);
                        _unitOfWork.AccountRepository.Update(user);
                        _unitOfWork.Save();
                        TempData["Success"] = "Password change successful";
                    }
                    else
                    {
                        TempData["Error"] = "Old password is incorect";
                    }
                }
                else
                {
                    TempData["Error"] = "User not found";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
            return RedirectToAction(nameof(ChangePassword));
        }
        //SIGNALR MOCK
        public IActionResult MockSendData(string email, string message)
        {
            _hubContext.Clients.User(email).SendAsync("ReceiveMessage", message);
            return RedirectToAction(nameof(Index));
        }
        //GOOGLE SIGNIN
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = "/")
        {
            return Challenge(new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleSignIn", "Account", null, Request.Scheme, Request.Host.ToString())
            }, "Google");
        }

        [AllowAnonymous]
        public async Task<IActionResult> GoogleSignIn()
        {
            // Set session data
            try
            {
                var result = await HttpContext.AuthenticateAsync("Google");
                if (result.Succeeded)
                {
                    //var gender = result.Principal.FindFirstValue("gender");

                    //Console.WriteLine("ACCOUNT CONTROLLER " + gender);
                    var googleEmail = result.Principal.FindFirstValue(ClaimTypes.Email);
                    var existingAccount = await _unitOfWork.AccountRepository.FindAccountByEmail(googleEmail);
                    if (existingAccount != null)
                    {
                        if (existingAccount.AccountType == (int)AccountType.EMAIL)
                        {
                            TempData["Error"] = "This email has been used";
                            return RedirectToAction(nameof(SignIn));
                        }
                        else
                        {
                            UserSession userSession = new UserSession
                            {
                                Email = existingAccount.Email,
                                Password = existingAccount.Password,
                                FullName = existingAccount.Customer!.Name!,
                                Gender = existingAccount.Customer!.Gender!,
                                BirthDay = existingAccount.Customer.Birthday,
                                RoleId = existingAccount.RoleId,
                                AccountType = existingAccount.AccountType
                            };
                            HttpContext.Session.SetObject("UserSession", userSession);
                        }
                    }
                    else
                    {
                        string email = result.Principal.FindFirstValue(ClaimTypes.Email);
                        string password = "";
                        int roleId = (int)RoleId.Customer;
                        short accountType = (int)AccountType.GOOGLE;
                        string customerName = result.Principal.FindFirstValue(ClaimTypes.Name);
                        short status = (int)CustomerStatus.AVAILABLE;
                        Account newAccount = new Account
                        {
                            Email = email,
                            Password = password,
                            RoleId = roleId,
                            AccountType = accountType,
                            Customer = new Customer
                            {
                                Name = customerName,
                                Status = status
                            }
                        };
                        await _unitOfWork.AccountRepository.SignUp(newAccount);
                        UserSession userSession = new UserSession
                        {
                            Email = newAccount.Email,
                            Password = newAccount.Password,
                            FullName = newAccount.Customer!.Name!,
                            Gender = newAccount.Customer!.Gender!,
                            BirthDay = newAccount.Customer.Birthday,
                            RoleId = newAccount.RoleId,
                            AccountType = newAccount.AccountType
                        };
                        HttpContext.Session.SetObject("UserSession", userSession);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
