using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InternetCafe.Data;
using InternetCafe.Models;
using InternetCafe.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace InternetCafe.Controllers
{
    [Authorize]
    public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reservations.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            CreateReservationViewModel model = new CreateReservationViewModel();
            model.Devices = _context.Devices.ToList();
            model.IRLs = _context.IRLs.ToList();
            model.VIPs = _context.VIPs.ToList();
            return View(model);
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateReservationViewModel reservation)
        {
            Reservation r = new Reservation();
            r.Name = reservation.Name;
            r.Date = reservation.Date;
            r.StartTime = reservation.StartTime;
            r.EndTime = reservation.EndTime;
            r.Customer = reservation.Customer;
            r.VIP = _context.VIPs.Where(x => x.Id == reservation.VIPId).FirstOrDefault();
            r.Device = _context.Devices.Where(x => x.Id == reservation.DeviceId).FirstOrDefault();
            r.IRL = _context.IRLs.Where(x => x.Id == reservation.IRLId).FirstOrDefault();

            if (ModelState.IsValid)
            {
                _context.Add(r);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            CreateReservationViewModel model = new CreateReservationViewModel();
            model.Name = reservation.Name;
            model.Date = reservation.Date;
            model.Customer = reservation.Customer;
            model.StartTime = reservation.StartTime;
            model.EndTime = reservation.EndTime;

            model.Devices = _context.Devices.ToList();
            model.IRLs = _context.IRLs.ToList();
            model.VIPs = _context.VIPs.ToList();
            return View(model);

            
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  CreateReservationViewModel reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }

            Reservation oldReservation = _context.Reservations.Where(x => x.Id == reservation.Id).FirstOrDefault();
            oldReservation.Name = reservation.Name;
            oldReservation.Date = reservation.Date;
            oldReservation.Customer = reservation.Customer;
            oldReservation.StartTime = reservation.StartTime;
            oldReservation.EndTime = reservation.EndTime;
            oldReservation.Device = _context.Devices.Where(x => x.Id == reservation.DeviceId).FirstOrDefault();
            oldReservation.VIP = _context.VIPs.Where(x => x.Id == reservation.VIPId).FirstOrDefault();
            oldReservation.IRL = _context.IRLs.Where(x => x.Id == reservation.IRLId).FirstOrDefault();
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }
    }
}
