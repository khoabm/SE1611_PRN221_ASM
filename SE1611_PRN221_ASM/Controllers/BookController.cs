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
        private static string[] sortOptions = {"latest","oldest","price","rating"};

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
            var (books, totalItems) = _unitOfWork.BookRepository.SearchBooks(query, genres, minPrice, maxPrice,page,size,sort);
            string[] bookSortOptions = new string[4];
            bookSortOptions[0] = sort;
            int j = 1;
            for (int i = 0; i < 4; i++)
            {
                if (!sortOptions[i].Equals(sort))
                {
                    bookSortOptions[j] = sortOptions[i];
                    j++;
                }
            }
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
                sortOptions = bookSortOptions
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
            try
            {
                var book = _unitOfWork.BookRepository.GetById(id);
                if (book == null) return RedirectToAction(nameof(Index));
                else
                {
                    var similarBooks = _unitOfWork.BookRepository.GetBooksWithTheSameGenres(book);
                    List<Comment> comments = _unitOfWork.CommentRepository.GetAllCommentOfABookNoPaging(id).ToList();
                    if (comments.Count != 0)
                    {
                        book.AverageRating = Math.Ceiling(comments.Average(c => c.Rating)!.Value);
                    }
                    else
                    {
                        book.AverageRating = 0;
                    }
                    ViewBag.commentNum = comments.Count();
                    ViewBag.BookGenres = _unitOfWork.BookRepository.GetBookGenres(id);
                    ViewBag.SimilarBooks = similarBooks;
                    return View(book);
                }
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
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
