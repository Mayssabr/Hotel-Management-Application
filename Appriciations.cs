﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotellerie_Mayssa.Models.HotellerieModel;

namespace Hotellerie_Mayssa.Controllers
{
    public class Appriciations : Controller
    {
        private readonly HotellerieDbContext _context;

        public Appriciations(HotellerieDbContext context)
        {
            _context = context;
        }

        // GET: Appriciations
        public async Task<IActionResult> Index()
        {
            var hotellerieDbContext = _context.Appreciations.Include(a => a.Hotel);
            return View(await hotellerieDbContext.ToListAsync());
        }

        // GET: Appriciations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Appreciations == null)
            {
                return NotFound();
            }

            var appreciation = await _context.Appreciations
                .Include(a => a.Hotel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appreciation == null)
            {
                return NotFound();
            }

            return View(appreciation);
        }

        // GET: Appriciations/Create
        public IActionResult Create()
        {
            ViewData["HotelId"] = new SelectList(_context.Hotels, "Id", "Nom");
            return View();
        }

        // POST: Appriciations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomPres,Commentaire,HotelId")] Appreciation appreciation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appreciation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelId"] = new SelectList(_context.Hotels, "Id", "Nom", appreciation.HotelId);
            return View(appreciation);
        }

        // GET: Appriciations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Appreciations == null)
            {
                return NotFound();
            }

            var appreciation = await _context.Appreciations.FindAsync(id);
            if (appreciation == null)
            {
                return NotFound();
            }
            ViewData["HotelId"] = new SelectList(_context.Hotels, "Id", "Nom", appreciation.HotelId);
            return View(appreciation);
        }

        // POST: Appriciations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomPres,Commentaire,HotelId")] Appreciation appreciation)
        {
            if (id != appreciation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appreciation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppreciationExists(appreciation.Id))
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
            ViewData["HotelId"] = new SelectList(_context.Hotels, "Id", "Nom", appreciation.HotelId);
            return View(appreciation);
        }

        // GET: Appriciations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Appreciations == null)
            {
                return NotFound();
            }

            var appreciation = await _context.Appreciations
                .Include(a => a.Hotel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appreciation == null)
            {
                return NotFound();
            }

            return View(appreciation);
        }

        // POST: Appriciations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Appreciations == null)
            {
                return Problem("Entity set 'HotellerieDbContext.Appreciations'  is null.");
            }
            var appreciation = await _context.Appreciations.FindAsync(id);
            if (appreciation != null)
            {
                _context.Appreciations.Remove(appreciation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppreciationExists(int id)
        {
          return (_context.Appreciations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
