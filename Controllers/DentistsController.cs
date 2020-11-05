﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DentalApp.Data;
using DentalApp.Models;

namespace DentalApp.Controllers
{
    public class DentistsController : Controller
    {
        private readonly DentalAppContext _context;

        public DentistsController(DentalAppContext context)
        {
            _context = context;
        }

        // GET: Dentists
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dentist.ToListAsync());
        }

        // GET: Dentists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dentist = await _context.Dentist
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dentist == null)
            {
                return NotFound();
            }

            return View(dentist);
        }

        // GET: Dentists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dentists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume,Prenume,Telefon,Observatii")] Dentist dentist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dentist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dentist);
        }

        // GET: Dentists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dentist = await _context.Dentist.FindAsync(id);
            if (dentist == null)
            {
                return NotFound();
            }
            return View(dentist);
        }

        // POST: Dentists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nume,Prenume,Telefon,Observatii")] Dentist dentist)
        {
            if (id != dentist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dentist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DentistExists(dentist.Id))
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
            return View(dentist);
        }

        // GET: Dentists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dentist = await _context.Dentist
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dentist == null)
            {
                return NotFound();
            }

            return View(dentist);
        }

        // POST: Dentists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dentist = await _context.Dentist.FindAsync(id);
            _context.Dentist.Remove(dentist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DentistExists(int id)
        {
            return _context.Dentist.Any(e => e.Id == id);
        }
    }
}
