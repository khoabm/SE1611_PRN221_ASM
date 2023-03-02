using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Infrastructure;
using SE1611_PRN221_ASM.Models;

namespace SE1611_PRN221_ASM.Controllers
{
    public class CommentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Test(int id, string comment, int customerId, int rating)
        {
            Console.WriteLine($"id: {id}, comment: {comment}, customerId: {customerId}, rating: {rating}");
            var postComment = new Comment
            {
                Content = comment,
                Rating = rating,
                BookId = id,
                CustomerId = customerId,
                CommentDate = DateTime.UtcNow           
            };
           
           // _unitOfWork.CommentRepository.InsertComment(postComment);
            Console.WriteLine(postComment);
            return RedirectToAction("GetComment", new { bookId = id });
        }

        // GET: CommentController
        // ~/getcomment?id=1?page=1
        public IActionResult GetComment(int bookId, int page = 1)
        {
            var (commentByBooks, totalItems) = _unitOfWork.CommentRepository.GetAllCommentOfABook(bookId, page);
            Console.WriteLine("Total Comments: " + totalItems);
            var totalPages = (int)Math.Ceiling((double)totalItems / 3);

            var startPage = Math.Max(1, page - 3);
            var endPage = Math.Min(totalPages, page + 3);

            // Create a PaginationViewModel object and store it in the ViewBag or ViewData
            var pagination = new PaginationViewModel
            {
                CurrentPage = page,
                TotalPages = totalPages,
                StartPage = startPage,
                EndPage = endPage
            };

            ViewBag.Pagination = pagination;
            ViewBag.CommentPage = page;
            ViewBag.Comments = commentByBooks;
            ViewBag.TotalItems = totalItems;
            return PartialView("_CommentPartialView");
        }

    }
}
