using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopGiay.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        
        public int Quantity { get; set; }

        public int Price { get; set; }

        public int OrderId { get; set; }

        public int GiayId { get; set; }

        public Order Order{ get; set; }

        public  Giay Giay { get; set; }
    }
}
