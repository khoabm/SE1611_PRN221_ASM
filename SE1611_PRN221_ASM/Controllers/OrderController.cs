﻿using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Infrastructure;
using SE1611_PRN221_ASM.Helper;
using SE1611_PRN221_ASM.Models;

namespace SE1611_PRN221_ASM.Controllers
{
    enum Status
    {
        Pending = 0,
        Accepted = 1,
        Delivering= 2,
        Delivered = 3
    }
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private static string[] sortOptions = { "latest", "oldest"};

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var userSession = HttpContext.Session.GetObject<UserSession>("UserSession");

            if (userSession == null)
            {
                TempData["Message"] = "Please log in first.";
                return View("EmptyOrder");
            }

            var account = await _unitOfWork.AccountRepository.FindAccountByEmail(userSession.Email);
            int customerId = account.AccountId;
            var list = _unitOfWork.OrderRepository.GetOrderByCustomerId(customerId);
            if (list == null || !list.Any())
            {
                TempData["Message"] = "Looks like you haven't made any orders yet! Start shopping now.";
                return View("EmptyOrder");
            }

            return View(list);
        }

        public async Task<IActionResult> ListOrders(string query
            , double minPrice = 0
            , double maxPrice = 1000000000
            , int page = 1
            , int size = 9
            , string sort = "latest")
        {
            var userSession = HttpContext.Session.GetObject<UserSession>("UserSession");
            var account = await _unitOfWork.AccountRepository.FindAccountByEmail(userSession.Email);

            int customerId = account.AccountId;

            var (orders, totalItems) = _unitOfWork.OrderRepository.SearchOrdersCustomer(query, minPrice, maxPrice, page, size, sort, customerId);
            //string[] orderSortOptions = new string[2];
            //orderSortOptions[0] = sort;
            //int j = 1;
            //for (int i = 0; i < 2; i++)
            //{
            //    if (!sortOptions[j].Equals(sort))
            //    {
            //        orderSortOptions[j] = sortOptions[i];
            //        j++;
            //    }
            //}
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
                maxPrice = (int)maxPrice,
                minPrice = (int)minPrice,
                query = query,
                size = size
            };
            ViewBag.Pagination = pagination;
            ViewBag.TotalItems = totalItems;
            ViewBag.SearchModel = searchModel;
            ViewBag.Sort = sort;
            foreach (var o in orders)
            {
                var customer = _unitOfWork.CustomerRepository.GetById(o.CustomerId);
                o.Customer = customer;
            }
            return View("Orders",orders);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            var orders = _unitOfWork.OrderDetailRepository.GetOrderDetailByOrderId(id);

            return View("View", orders);
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
                var book = _unitOfWork.BookRepository.GetById(orderDetail.BookId);
                book.QuantityLeft -= cartItem.Quantity;
                orderDetails.Add(orderDetail);
                _unitOfWork.CartRepository.Delete(cartItem);
                _unitOfWork.BookRepository.Update(book);
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
            TempData["Success"] = "Checkout successfully.";

            return View("View", orderDetails);
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
