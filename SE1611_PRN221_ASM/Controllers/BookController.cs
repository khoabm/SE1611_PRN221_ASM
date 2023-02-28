using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Entities;
using Repository.Infrastructure;
using SE1611_PRN221_ASM.Models;

namespace SE1611_PRN221_ASM.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: BookController
        public ActionResult Index(string query
            ,string[] genres
            ,double minPrice = 0
            ,double maxPrice = 1000000000
            ,int page=1
            ,int size=9
            ,string sort="latest")
        {
            Console.WriteLine(sort);
            var (books, totalItems) = _unitOfWork.BookRepository.SearchBooks(query, genres, minPrice, maxPrice,page,size,sort);
            var totalPages = (int)Math.Ceiling((double)totalItems / size);
            var startPage = Math.Max(1, page - size);
            var endPage = Math.Min(totalPages, page + size);
            var pagination = new PaginationViewModel
            {
                CurrentPage = page,
                TotalPages = totalPages,
                StartPage = startPage,
                EndPage = endPage
            };
            var searchModel = new SearchModel
            {
                genres = genres,
                maxPrice = (int)maxPrice,
                minPrice = (int)minPrice,
                query = query,
                size = size,
                sort = sort
            };
            ViewBag.Pagination = pagination;
            ViewBag.TotalItems = totalItems;
            ViewBag.SearchModel = searchModel;    
            ViewBag.Genres = _unitOfWork.GenreRepository.GetAll().ToList();
            return View(books);
        }
        
        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book = _unitOfWork.BookRepository.GetById(id);
            if (book == null) return NotFound();
            ViewBag.BookGenres = _unitOfWork.BookRepository.GetBookGenres(id);
            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.BookRepository.Create(book);
                    _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: BookController/Edit/5
        [HttpGet("book/Edit/{id}")]
        public ActionResult Edit([FromRoute]int id)
        {
            Book b = _unitOfWork.BookRepository.GetById(id);
            if (b != null)
            {
                return View(b);
            }
            return View("Book not found");
        }

        // POST: BookController/Edit/5
        [HttpPost("book/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromRoute]int id,[FromForm]Book book)
        {
            try
            {
                    if (ModelState.IsValid)
                    {
                        _unitOfWork.BookRepository.Update(book);
                        _unitOfWork.Save();
                        return RedirectToAction(nameof(Index));
                    }
                    return NotFound();
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            Book b = _unitOfWork.BookRepository.GetById(id);
            if (b == null) return NotFound();
            return View(b);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Book book)
        {
            try
            {
                if (id != book.BookId)
                {
                    return NotFound();
                }
                else _unitOfWork.BookRepository.Delete(book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
