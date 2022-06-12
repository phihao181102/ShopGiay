using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopGiay.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopGiay.Models
{
    public class Cart
    {
        private readonly ShopGiayContext _context;

        public Cart(ShopGiayContext context)
        {
            _context = context;
        }
        public string Id { get; set; }

        public List<CartItem> CartItems { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<ShopGiayContext>();
            string cartId = session.GetString("Id") ?? Guid.NewGuid().ToString();

            session.SetString("Id", cartId);

            return new Cart(context) { Id = cartId };
        }

        public CartItem GetCartItem(Giay giay)
        {
            return _context.CartItems.SingleOrDefault(ci =>
            ci.Giay.Id == giay.Id && ci.CartId == Id);
        }
        public void AddToCart(Giay giay, int quaity)
        {
            var cartItem = GetCartItem(giay);

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    Giay = giay,
                    Quanity = quaity,
                    CartId = Id,
                };
                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quanity = +quaity;
            }
            _context.SaveChanges();
        }

        public int ReduceQuantity(Giay giay)
        {
            var cartItem = GetCartItem(giay);
            var remainingQuanity = 0;

            if (cartItem.Quanity > 1)
            {
                remainingQuanity = --cartItem.Quanity;
            }
            else
            {
                _context.CartItems.Remove(cartItem);
            }
            _context.SaveChanges();

            return remainingQuanity;
        }

        public int IncreaseQuantity(Giay giay)
        {
            var cartItem = GetCartItem(giay);
            var remainingQuanity = 0;

            if (cartItem != null)
            {

                if (cartItem.Quanity > 0)
                {
                    remainingQuanity = ++cartItem.Quanity;
                }
            }
            _context.SaveChanges();

            return remainingQuanity;
        }

        public void RemoveFormCart(Giay giay)
        {
            var cartItem = GetCartItem(giay);
            
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
            }
            _context.SaveChanges(); 
        }

        public void ClearCart()
        {
            var cartItems = _context.CartItems.Where(ci => ci.CartId == Id);

            _context.CartItems.RemoveRange(cartItems);

            _context.SaveChanges();
        }

        public List<CartItem> GetAllCartItems()
        {
            return CartItems ??
                (CartItems = _context.CartItems.Where(ci => ci.CartId == Id)
                     .Include(ci => ci.Giay)
                     .ToList());
        }

        public int GetCartTotal()
        {
            return _context.CartItems
                .Where(ci => ci.CartId == Id)
                .Select(ci => ci.Giay.Price * ci.Quanity)
                .Sum();
        }
    }
}
