using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Infrastructure;
using SE1611_PRN221_ASM.Helper;
using SE1611_PRN221_ASM.Models;

namespace SE1611_PRN221_ASM.Controllers
{
    enum Status
    {
       Pending=0,
       Delivered=1
    }
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: OrderController
        public ActionResult ListOrders()
        {
            var list = _unitOfWork.OrderRepository.GetAll();

            return View("Orders",list);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            var orders = _unitOfWork.OrderDetailRepository.GetOrderDetailByOrderId(id);

            return View("View",orders);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Checkout(string address, string phone, double total)
        {
            var userSession = HttpContext.Session.GetObject<UserSession>("UserSession");
            var account = await _unitOfWork.AccountRepository.FindAccountByEmail(userSession.Email);

            int customerId = account.AccountId;
            var cart = _unitOfWork.CartRepository.GetCartByCustomerId(customerId);
            var orderDetails = new List<OrderDetail>();
            foreach (var cartItem in cart)
            {
                var orderDetail = new OrderDetail
                {

                    Quantity = cartItem.Quantity,
                    BookId = cartItem.BookId,
                    Price = cartItem.Book.Price,
                };
                orderDetails.Add(orderDetail);
                _unitOfWork.CartRepository.Delete(cartItem);   
            }
            var order = new Order
            {
                Address = address,
                Phone = phone,
                TotalAmount = total,
                CustomerId = customerId,
                PlaceDate = DateTime.Now,
                Status = (short?)Status.Pending,
                OrderDetails = orderDetails
            };
            order.OrderDetails = orderDetails;
            _unitOfWork.OrderRepository.Create(order);
            _unitOfWork.Save();

            userSession.CartItemCount = 0;
            HttpContext.Session.SetObject("UserSession", userSession);

            return View("View",orderDetails);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
