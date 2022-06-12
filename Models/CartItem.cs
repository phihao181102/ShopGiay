using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ShopGiay.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopGiay.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public Giay Giay { get; set; }

        public int Quanity { get; set; }

        public string CartId { get; set; }

        
    }
}

