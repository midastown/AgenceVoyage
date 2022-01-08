using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgenceVoyage.Data;
using AgenceVoyage.Models;

namespace AgenceVoyage.Controllers
{
    public class VoyagesController : Controller
    {
        private readonly VoyageContext _context;

        public VoyagesController(VoyageContext context)
        {
            _context = context;
        }

        // GET: Voyages
        public async Task<IActionResult> Index()
        {
            return View(await _context.Voyages.ToListAsync());
        }

        // GET: Voyages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voyage = await _context.Voyages
                .FirstOrDefaultAsync(m => m.idClient == id);
            if (voyage == null)
            {
                return NotFound();
            }

            return View(voyage);
        }

        // GET: Voyages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Voyages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idClient,idForfait,dateVoyage")] Voyage voyage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voyage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voyage);
        }

        // GET: Voyages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voyage = await _context.Voyages.FindAsync(id);
            if (voyage == null)
            {
                return NotFound();
            }
            return View(voyage);
        }

        // POST: Voyages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idClient,idForfait,dateVoyage")] Voyage voyage)
        {
            if (id != voyage.idClient)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voyage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoyageExists(voyage.idClient))
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
            return View(voyage);
        }

        // GET: Voyages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voyage = await _context.Voyages
                .FirstOrDefaultAsync(m => m.idClient == id);
            if (voyage == null)
            {
                return NotFound();
            }

            return View(voyage);
        }

        // POST: Voyages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voyage = await _context.Voyages.FindAsync(id);
            _context.Voyages.Remove(voyage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoyageExists(int id)
        {
            return _context.Voyages.Any(e => e.idClient == id);
        }
    }
}
