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

        
    }
}
