
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
            var booksByDate = new List<Book>();
            try
            {
                //books = _unitOfWork.BookRepository.GetAll().ToList();
                books = _unitOfWork.BookRepository.GetBooksOrderByAverageRating().ToList();
                booksByDate = _unitOfWork.BookRepository.GetBooksOrderByAddedDate().ToList();
                //Console.WriteLine(books2.Count);
                ViewBag.BooksByDate = booksByDate;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
                
            
            return View(books);
        }
        [HttpGet]
        public IActionResult LoadBooks(string tab)
        {
            List<Book> books = new List<Book>();
            Console.WriteLine("Load books");
            if (tab == "novel")
            {
                // Filter books for Novel tab
                books = _unitOfWork.BookRepository.GetBooksOrderByCategory("Fiction").ToList();
            }
            else if (tab == "comics")
            {
                // Filter books for Comics tab
                books = _unitOfWork.BookRepository.GetBooksOrderByCategory("Romance").ToList();
            }
            else if (tab == "others")
            {
                // Filter books for Others tab
                books = _unitOfWork.BookRepository.GetBooksOrderByCategory("").ToList();
            }

            return PartialView("_ModelPartialView", books);
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