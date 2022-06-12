using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopGiay.Data;
using System;
using System.Linq;
namespace ShopGiay.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ShopGiayContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<ShopGiayContext>>()))
            {
                
                if (context.Giay.Any())
                {
                    return; 
                }
                context.Giay.AddRange(
                new Giay
                {
                    Title = "GIÀY ULTRABOOST 22",
                    Description = "Giày Thể Thao",
                    Price = 91,
                    Image = "https://assets.adidas.com/images/w_383,h_383,f_auto,q_auto,fl_lossy,c_fill,g_auto/5ae921bb08034aa2803fad7800abdd7f_9366/gi%C3%A0y-ultraboost-22.jpg"
                },
                new Giay
                {
                    Title = "GIÀY ULTRABOOST 22",
                    Description = "Giày Thể Thao",
                    Price = 91,
                    Image = "https://assets.adidas.com/images/w_383,h_383,f_auto,q_auto,fl_lossy,c_fill,g_auto/5ae921bb08034aa2803fad7800abdd7f_9366/gi%C3%A0y-ultraboost-22.jpg" 
                }
                );
                context.SaveChanges();//lưu dữ liệu
            }
        }
    }
}