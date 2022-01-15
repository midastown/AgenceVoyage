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
    public class ClientsController : Controller
    {
        private readonly VoyageContext _context;

        public ClientsController(VoyageContext context)
        {
            _context = context;
        }

        

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idClient,username,password,nom,prenom,adresse,ville,codePostal,modePaiement")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "Home");
            }
            return View(client);
        }

        
    }
}
