using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Infrastructure;

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
        public ActionResult Index()
        {
            var list = _unitOfWork.BookRepository.GetAll();
            Console.WriteLine("im heRE");
            return View(list);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book = _unitOfWork.BookRepository.GetById(id);
            if (book == null) return NotFound();
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
        [HttpGet("Book/Edit/{id}")]
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
        [HttpPost("Book/Edit/{id}")]
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
