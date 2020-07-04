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
    public class VIPsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VIPsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VIPs
        public async Task<IActionResult> Index()
        {
            return View(await _context.VIPs.ToListAsync());
        }

        // GET: VIPs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vIP = await _context.VIPs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vIP == null)
            {
                return NotFound();
            }

            return View(vIP);
        }

        // GET: VIPs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VIPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] VIP vIP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vIP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vIP);
        }

        // GET: VIPs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vIP = await _context.VIPs.FindAsync(id);
            if (vIP == null)
            {
                return NotFound();
            }
            return View(vIP);
        }

        // POST: VIPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] VIP vIP)
        {
            if (id != vIP.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vIP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VIPExists(vIP.Id))
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
            return View(vIP);
        }

        // GET: VIPs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vIP = await _context.VIPs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vIP == null)
            {
                return NotFound();
            }

            return View(vIP);
        }

        // POST: VIPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vIP = await _context.VIPs.FindAsync(id);
            _context.VIPs.Remove(vIP);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VIPExists(int id)
        {
            return _context.VIPs.Any(e => e.Id == id);
        }
    }
}
