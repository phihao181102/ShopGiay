using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopGiay.Models;

namespace ShopGiay.Data
{
    public class ShopGiayContext : DbContext
    {
        public ShopGiayContext (DbContextOptions<ShopGiayContext> options)
            : base(options)
        {
        }

        public DbSet<Giay> Giay { get; set; }

        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

    }
}
