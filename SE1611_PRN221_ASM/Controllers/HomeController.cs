
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SE1611_PRN221_ASM.Helper;


using Repository.Infrastructure;

using SE1611_PRN221_ASM.Models;
using System.Diagnostics;
using Repository.Entities;

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
            var books = new List<Book>();
            try
            {
                //books = _unitOfWork.BookRepository.GetAll().ToList();
                books = _unitOfWork.BookRepository.GetBooksOrderByAverageRating().ToList();
                //Console.WriteLine(books2.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
                
            
            return View(books);
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