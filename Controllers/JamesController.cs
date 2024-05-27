using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CLDV_Part2.Data;
using CLDV_Part2.Models;
using Microsoft.AspNetCore.Authorization;

namespace CLDV_Part2.Controllers
{
   
    public class JamesController : Controller
    {
        private readonly ApplicationDb _context;

        public JamesController(ApplicationDb context)
        {
            _context = context;
        }

        // GET: James
        [Authorize(Roles = "James,Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.james.ToListAsync());
        }

        [Authorize(Roles = "James,Admin")]
        // GET: James/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var james = await _context.james
                .FirstOrDefaultAsync(m => m.Id == id);
            if (james == null)
            {
                return NotFound();
            }

            return View(james);
        }
        [Authorize(Roles = "James,Admin")]
        // GET: James/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "James,Admin")]
        // POST: James/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Mobile,Email,Source")] James james)
        {
            if (ModelState.IsValid)
            {
                _context.Add(james);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(james);
        }
        [Authorize(Roles = "James,Admin")]
        // GET: James/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var james = await _context.james.FindAsync(id);
            if (james == null)
            {
                return NotFound();
            }
            return View(james);
        }

        [Authorize(Roles = "James,Admin")]
        // POST: James/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Mobile,Email,Source")] James james)
        {
            if (id != james.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(james);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JamesExists(james.Id))
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
            return View(james);
        }
        [Authorize(Roles = "Admin")]
        // GET: James/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var james = await _context.james
                .FirstOrDefaultAsync(m => m.Id == id);
            if (james == null)
            {
                return NotFound();
            }

            return View(james);
        }

        
        [Authorize(Roles = "Admin")]
        // POST: James/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var james = await _context.james.FindAsync(id);
            if (james != null)
            {
                _context.james.Remove(james);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JamesExists(int id)
        {
            return _context.james.Any(e => e.Id == id);
        }
    }
}
