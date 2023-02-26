<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SE1611_PRN221_ASM.Helper;
=======
﻿using Microsoft.AspNetCore.Mvc;
using Repository.Infrastructure;
>>>>>>> 8badeea4e7f7e639bb9ce3dc6b3c6860cc0d4516
using SE1611_PRN221_ASM.Models;
using System.Diagnostics;

namespace SE1611_PRN221_ASM.Controllers
{

    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult AjaxAction()
        {
            return PartialView("_AjaxPartialView");
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [SessionAuthorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}