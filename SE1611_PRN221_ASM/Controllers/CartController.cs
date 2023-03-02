using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Infrastructure;
using Repository.Repository;
using SE1611_PRN221_ASM.Helper;
using SE1611_PRN221_ASM.Models;

namespace SE1611_PRN221_ASM.Controllers
{
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: CartController
        public async Task<IActionResult> Index()
        {
            var userSession = HttpContext.Session.GetObject<UserSession>("UserSession");

            if (userSession == null)
            {
                TempData["Message"] = "Please log in first.";
                return View("EmptyCart");
            }

            var account = await _unitOfWork.AccountRepository.FindAccountByEmail(userSession.Email);

            int customerId = account.AccountId;
            var list = _unitOfWork.CartRepository.GetCartByCustomerId(customerId);

            if (list == null || list.Count() == 0)
            {
                TempData["Message"] = "Cart is empty.";
                return View("EmptyCart");
            }

            return View(list);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult UpdateQuantity(int id, int quantity)
        //{
        //    var cart = _unitOfWork.CartRepository.GetById(id);
        //    if (cart == null)
        //    {
        //        return NotFound();
        //    }

        //    cart.Quantity = quantity;
        //    _unitOfWork.CartRepository.Update(cart);
        //    _unitOfWork.Save();

        //    return RedirectToAction(nameof(Index));
        //}

        // POST: CartController/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int bookId, int quantity)
        {
            var userSession = HttpContext.Session.GetObject<UserSession>("UserSession");

            if (userSession == null)
            {
                TempData["Message"] = "Please log in first.";
                return View("EmptyCart");
            }

            var account = await _unitOfWork.AccountRepository.FindAccountByEmail(userSession.Email);
            int customerId = account.AccountId;

            // check if the book is already in the cart
            var cartItem = _unitOfWork.CartRepository.GetByBookIdAndCustomerId(bookId, customerId);

            if (cartItem == null)
            {
                // book is not in cart, create a new cart item
                cartItem = new Cart
                {
                    Quantity = quantity,
                    BookId = bookId,
                    CustomerId = customerId
                };

                _unitOfWork.CartRepository.Create(cartItem);
                userSession.CartItemCount++;
                HttpContext.Session.SetObject("UserSession", userSession);
            }
            else
            {
                // book is already in cart, update its quantity
                cartItem.Quantity += quantity;
                _unitOfWork.CartRepository.Update(cartItem);
            }

            _unitOfWork.Save();

            TempData["Message"] = "Added to cart successfully.";
            TempData["MessageType"] = "success";

            // Get the URL of the previous page
            string url = Request.Headers["Referer"].ToString();

            // Redirect the user back to the previous page
            return Redirect(url);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCart(IEnumerable<Cart> cartItems)
        {
            var userSession = HttpContext.Session.GetObject<UserSession>("UserSession");

            if (userSession == null)
            {
                TempData["Message"] = "Please log in first.";
                return View("EmptyCart");
            }

            foreach (var cartItem in cartItems)
            {
                var item = _unitOfWork.CartRepository.GetById(cartItem.CartId);
                if (item != null)
                {
                    _unitOfWork.CartRepository.Update(item);
                }
            }

            _unitOfWork.Save();
            return View("Index");
        }

        // POST: CartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var cartItem = _unitOfWork.CartRepository.GetById(id);

            if (cartItem == null)
            {
                return NotFound();
            }

            _unitOfWork.CartRepository.Delete(cartItem);
            _unitOfWork.Save();

            var userSession = HttpContext.Session.GetObject<UserSession>("UserSession");
            if (userSession != null)
            {
                userSession.CartItemCount--;
                HttpContext.Session.SetObject("UserSession", userSession);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
