using Microsoft.AspNetCore.Mvc;
using ShopGiay.Data;
using ShopGiay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopGiay.Controllers
{
    public class CartController : Controller
    {
        private readonly ShopGiayContext context, _context;
        private readonly Cart _cart;

        public CartController(ShopGiayContext context, Cart cart)
        {
            _context = context;
            _cart = cart;
        }
        public IActionResult Index()
        {
            var items = _cart.GetAllCartItems();
            _cart.CartItems = items;
            return View(_cart);
        }
        public IActionResult AddToCart(int id)
        {
            var selectedGiay = GetGiayById(id);

            if (selectedGiay !=null)
            {
                _cart.AddToCart(selectedGiay, 1);
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFormCart(int id)
        {
            var selectedGiay = GetGiayById(id);

            if (selectedGiay != null)
            {
                _cart.RemoveFormCart(selectedGiay);
            }
            return RedirectToAction("Index");
        }

        public IActionResult ReduceQuantity(int id)
        {
            var selectedGiay = GetGiayById(id);

            if (selectedGiay != null)
            {
                _cart.ReduceQuantity(selectedGiay);
            }
            return RedirectToAction("Index");
        }

        public IActionResult IncreaseQuantity(int id)
        {
            var selectedGiay = GetGiayById(id);

            if (selectedGiay != null)
            {
                _cart.IncreaseQuantity(selectedGiay);
            }
            return RedirectToAction("Index");
        }

        public IActionResult ClearCart()
        {
            _cart.ClearCart();

            return RedirectToAction("Index");
        }

        public Giay GetGiayById(int id)
        {
            return _context.Giay.FirstOrDefault(b => b.Id == id);
        }
    }
}
