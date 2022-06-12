using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopGiay.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopGiay.Models;

namespace ShopGiay.Controllers
{
    public class ShopController : Controller
    {
        private readonly ShopGiayContext _context;

        public ShopController(ShopGiayContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var giays = _context.Giay.Select(b => b);

            if (!string.IsNullOrEmpty(searchString))
            {
                giays = giays.Where(b => b.Title.Contains(searchString));
            }
            return View(await giays.ToListAsync());
        }



        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giay = await _context.Giay
                .FirstOrDefaultAsync(m => m.Id == id);
            if (giay == null)
            {
                return NotFound();
            }

            return View(giay);
        }
    }
}
