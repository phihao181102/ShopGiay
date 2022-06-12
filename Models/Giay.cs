using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShopGiay.Models
{
    public class Giay
    {

        public int Id { get; set; }

        [Required]
        [Display(Name ="Tên sản phẩm")]
        public string Title { get; set; }

        [MaxLength(length:100)]
        [Display(Name = "Thương hiệu")]
        public string Description { get; set; }

        [Required, DataType(DataType.Currency)]
        [Display(Name = "Giá")]
        public int Price { get; set; }

        [Display(Name ="Hình ảnh")]
        public string Image { get; set; }
    }
}
