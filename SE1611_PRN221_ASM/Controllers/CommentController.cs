using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Infrastructure;
using SE1611_PRN221_ASM.Helper;
using SE1611_PRN221_ASM.Models;

namespace SE1611_PRN221_ASM.Controllers
{
    
    public class CommentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CommentController> _logger;
        public CommentController(IUnitOfWork unitOfWork, ILogger<CommentController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpPost]
        [SessionAuthorize]
        public async Task<IActionResult> Test(int id, string comment, int rating)
        {
            try
            {
                var userSession = HttpContext.Session.GetObject<UserSession>("UserSession");
                Account? account = await _unitOfWork.AccountRepository.FindAccountByEmail(userSession!.Email);
                int customerId = 0;
                if (account != null)
                {
                    customerId = account.AccountId;
                }
                else
                {
                    return RedirectToAction("SignIn", "Account");
                }
                var postComment = new Comment
                {
                    Content = comment,
                    Rating = rating,
                    BookId = id,
                    CustomerId = customerId,
                    CommentDate = DateTime.UtcNow
                };

                //Console.WriteLine($"id: {id}, comment: {comment}, customerEmail: {account.AccountId}, rating: {rating}, customerId: {customerId}");
                _unitOfWork.CommentRepository.InsertComment(postComment);
                Console.WriteLine(postComment);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Comment Controller error: {ex.Message}");
                throw;
            }
            return RedirectToAction("GetComment", new { bookId = id });
        }

        // GET: CommentController
        // ~/getcomment?id=1?page=1
        [HttpGet]
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
