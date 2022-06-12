using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopGiay.Data;
using ShopGiay.Models;

namespace ShopGiay.Controllers
{
    public class GiaysController : Controller
    {
        private readonly ShopGiayContext _context;

        public GiaysController(ShopGiayContext context)
        {
            _context = context;
        }

        // GET: Giays
        public async Task<IActionResult> Index()
        {
            return View(await _context.Giay.ToListAsync());
        }

        // GET: Giays/Details/5
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

        // GET: Giays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Giays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Price,Image")] Giay giay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(giay);
        }

        // GET: Giays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giay = await _context.Giay.FindAsync(id);
            if (giay == null)
            {
                return NotFound();
            }
            return View(giay);
        }

        // POST: Giays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Price,Image")] Giay giay)
        {
            if (id != giay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiayExists(giay.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(giay);
        }

        // GET: Giays/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Giays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var giay = await _context.Giay.FindAsync(id);
            _context.Giay.Remove(giay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiayExists(int id)
        {
            return _context.Giay.Any(e => e.Id == id);
        }
    }
}
