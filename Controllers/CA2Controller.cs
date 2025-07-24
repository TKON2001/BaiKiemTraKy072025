using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoMvc.Data;
using DemoMvc.Models;

namespace DemoMvc.Controllers
{
    public class CA2Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public CA2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CA2
        public async Task<IActionResult> Index()
        {
            return View(await _context.CA2.ToListAsync());
        }

        // GET: CA2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cA2 = await _context.CA2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cA2 == null)
            {
                return NotFound();
            }

            return View(cA2);
        }

        // GET: CA2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CA2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre")] CA2 cA2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cA2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cA2);
        }

        // GET: CA2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cA2 = await _context.CA2.FindAsync(id);
            if (cA2 == null)
            {
                return NotFound();
            }
            return View(cA2);
        }

        // POST: CA2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre")] CA2 cA2)
        {
            if (id != cA2.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cA2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CA2Exists(cA2.Id))
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
            return View(cA2);
        }

        // GET: CA2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cA2 = await _context.CA2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cA2 == null)
            {
                return NotFound();
            }

            return View(cA2);
        }

        // POST: CA2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cA2 = await _context.CA2.FindAsync(id);
            if (cA2 != null)
            {
                _context.CA2.Remove(cA2);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CA2Exists(int id)
        {
            return _context.CA2.Any(e => e.Id == id);
        }
    }
}
