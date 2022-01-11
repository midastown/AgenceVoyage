using AgenceVoyage.Data;
using AgenceVoyage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Linq;
using System.Threading.Tasks;

namespace AgenceVoyage.Controllers
{
    public class HomeController : Controller
    {
        private readonly VoyageContext _context;
        //private readonly ILogger<HomeController> _logger;

        public HomeController(VoyageContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            Random random = new Random();

            List<Forfait> forfaits_home = new List<Forfait>();
            List<Forfait> forfaits = await _context.Forfaits.ToListAsync();

            int indice;
            int nbAffichage = 0;

            while (nbAffichage < 6)
            {
                for (int i = 0; i < forfaits.Count; i++)
                {
                    indice = random.Next(0, forfaits.Count - 1);

                    if (!forfaits_home.Contains(forfaits[indice]) && nbAffichage < 6)
                    {
                        nbAffichage++;
                        forfaits_home.Add(forfaits[indice]);
                    }
                }
            }

            return View(forfaits_home);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
