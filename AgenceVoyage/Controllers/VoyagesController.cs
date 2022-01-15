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
using System.Security.Claims;

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

        

        
        
        [Authorize]
        public async Task<IActionResult> Reserve(int id)
        {
            int userID = 1;

            var claims = User.Claims;
            foreach (var c in claims)
            {
                if (c.Type == "id")
                {
                    userID = Convert.ToInt32(c.Value);
                }
            }
            Voyage voyage = new Voyage(userID, id, DateTime.Now);
            if (ModelState.IsValid)
            {
                _context.Add(voyage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("index", await _context.Voyages.ToListAsync());
        }
    }
}
