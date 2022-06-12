using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopGiay.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public int Ordertotal { get; set; }

        public DateTime Orderplaced { get; set; }

    }
}
