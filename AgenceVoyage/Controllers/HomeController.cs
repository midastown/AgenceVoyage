using AgenceVoyage.Data;
using AgenceVoyage.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Linq;
using System.Security.Claims;
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

                    if (!forfaits_home.Contains(forfaits[indice]))
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

        [Authorize]
        public IActionResult Secured()
        {
            return View();
        }

        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Validate(string username, string password, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            // Check database for match in Clients (could be a stocked procedure)
            if (username == "bob" && password == "tako")
            {
                var claims = new List<Claim>()
                {
                    new Claim("username", username),
                    new Claim(ClaimTypes.NameIdentifier, username),
                    new Claim(ClaimTypes.Name, "Bob the farmer")
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return Redirect(returnUrl);
            }
            TempData["Error"] = "Error. Username or Password is invalid";
            return View("login");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
