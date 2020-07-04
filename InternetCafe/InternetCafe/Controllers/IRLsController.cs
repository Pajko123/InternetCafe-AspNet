using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InternetCafe.Data;
using InternetCafe.Models;
using Microsoft.AspNetCore.Authorization;

namespace InternetCafe.Controllers
{
    [Authorize]
    public class IRLsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IRLsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IRLs
        public async Task<IActionResult> Index()
        {
            return View(await _context.IRLs.ToListAsync());
        }

        // GET: IRLs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iRL = await _context.IRLs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iRL == null)
            {
                return NotFound();
            }

            return View(iRL);
        }

        // GET: IRLs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IRLs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] IRL iRL)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iRL);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iRL);
        }

        // GET: IRLs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iRL = await _context.IRLs.FindAsync(id);
            if (iRL == null)
            {
                return NotFound();
            }
            return View(iRL);
        }

        // POST: IRLs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] IRL iRL)
        {
            if (id != iRL.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iRL);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IRLExists(iRL.Id))
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
            return View(iRL);
        }

        // GET: IRLs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iRL = await _context.IRLs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iRL == null)
            {
                return NotFound();
            }

            return View(iRL);
        }

        // POST: IRLs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iRL = await _context.IRLs.FindAsync(id);
            _context.IRLs.Remove(iRL);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IRLExists(int id)
        {
            return _context.IRLs.Any(e => e.Id == id);
        }
    }
}
