using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgenceVoyage.Data;
using AgenceVoyage.Models;
using Microsoft.AspNetCore.Authorization;

namespace AgenceVoyage.Controllers
{
    public class ForfaitsController : Controller
    {
        private readonly VoyageContext _context;

        public ForfaitsController(VoyageContext context)
        {
            _context = context;
        }

        // GET: Forfaits
        public async Task<IActionResult> Index()
        {
            return View(await _context.Forfaits.ToListAsync());
        }

        // GET: Forfaits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forfait = await _context.Forfaits
                .FirstOrDefaultAsync(m => m.idForfait == id);
            if (forfait == null)
            {
                return NotFound();
            }

            return View(forfait);
        }

        // GET: Forfaits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Forfaits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idForfait,destination,prix,duree")] Forfait forfait)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forfait);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(forfait);
        }

        // GET: Forfaits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forfait = await _context.Forfaits.FindAsync(id);
            if (forfait == null)
            {
                return NotFound();
            }
            return View(forfait);
        }

        // POST: Forfaits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idForfait,destination,prix,duree")] Forfait forfait)
        {
            if (id != forfait.idForfait)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forfait);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForfaitExists(forfait.idForfait))
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
            return View(forfait);
        }

        // GET: Forfaits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forfait = await _context.Forfaits
                .FirstOrDefaultAsync(m => m.idForfait == id);
            if (forfait == null)
            {
                return NotFound();
            }

            return View(forfait);
        }

        // POST: Forfaits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var forfait = await _context.Forfaits.FindAsync(id);
            _context.Forfaits.Remove(forfait);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForfaitExists(int id)
        {
            return _context.Forfaits.Any(e => e.idForfait == id);
        }

        [Authorize]
        public async Task<IActionResult> Reserve(int id)
        {
            return View(await _context.Forfaits.ToListAsync());
        }
    }
}
