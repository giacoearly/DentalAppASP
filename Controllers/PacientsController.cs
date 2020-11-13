using System;
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
    public class PacientsController : Controller
    {
        private readonly DentalAppContext _context;

        public PacientsController(DentalAppContext context)
            {
              _context = context;
            }
        //We check matches on First name or Last name
        // Nume = Last name ; Prenume = First name
        public async Task<IActionResult> Index(string searchString)
        {
            var pacients = from p in _context.Pacient
                         select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                pacients  = pacients.Where(s => s.Nume.StartsWith(searchString) || s.Prenume.StartsWith(searchString));
            }

            return View(await pacients.ToListAsync());
        }

        // GET: Pacients
    //    public async Task<IActionResult> Index()
     //   {
      //      return View(await _context.Pacient.ToListAsync());
     //
    //}

        // GET: Pacients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacient = await _context.Pacient
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacient == null)
            {
                return NotFound();
            }

            return View(pacient);
        }

        // GET: Pacients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pacients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume,Prenume,NumarFisa,Medic,SerieCi,NumarCi,Cnp,Telefon,Observatii")] Pacient pacient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pacient);
        }

        // GET: Pacients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacient = await _context.Pacient.FindAsync(id);
            if (pacient == null)
            {
                return NotFound();
            }
            return View(pacient);
        }

        // POST: Pacients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nume,Prenume,NumarFisa,Medic,SerieCi,NumarCi,Cnp,Telefon,Observatii")] Pacient pacient)
        {
            if (id != pacient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacientExists(pacient.Id))
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
            return View(pacient);
        }

        // GET: Pacients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacient = await _context.Pacient
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacient == null)
            {
                return NotFound();
            }

            return View(pacient);
        }

        // POST: Pacients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacient = await _context.Pacient.FindAsync(id);
            _context.Pacient.Remove(pacient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacientExists(int id)
        {
            return _context.Pacient.Any(e => e.Id == id);
        }
    }
}
