using Microsoft.AspNetCore.Mvc;
using ShopGiay.Data;
using ShopGiay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopGiay.Controllers
{
    public class OrderController : Controller
    {
        private readonly ShopGiayContext  _context;
        private readonly Cart _cart;

        public OrderController(ShopGiayContext context, Cart cart)
        {
            _context = context;
            _cart = cart;
        }
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var cartItems = _cart.GetAllCartItems();
            _cart.CartItems = cartItems;
            if (_cart.CartItems.Count == 0)
            {
                ModelState.AddModelError("", "cart is your empty");
            }

            if (ModelState.IsValid)
            {
                CreateOrder(order);
                _cart.ClearCart();
                return View("CheckoutComplete", order);
            }
            return View(order);
        }

        public IActionResult CheckoutComplete(Order order)
        {
            return View(order);
        }

        public void CreateOrder(Order order)
        {
            order.Orderplaced = DateTime.Now;

            var cartItems = _cart.CartItems;

            foreach (var item in cartItems)
            {
                var orderItem = new OrderItem()
                {
                    Quantity = item.Quanity,
                    GiayId = item.Giay.Id,
                    OrderId = order.Id,
                    Price = item.Giay.Price * item.Quanity
                };
                order.OrderItems.Add(orderItem);
                order.Ordertotal += orderItem.Price;
            }
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
