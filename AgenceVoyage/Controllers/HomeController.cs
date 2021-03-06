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
                indice = random.Next(0, forfaits.Count - 1);
                for (int i = 0; i < forfaits.Count; i++)
                {
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
            var user = await _context.Clients
                .FromSqlInterpolated($"exec [dbo].[GetUser] @username={username}").ToListAsync();
            
            if (user[0].password == password)
            {
                var claims = new List<Claim>()
                {
                    new Claim("username", username),
                    new Claim("id", user[0].idClient.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, username),
                    new Claim(ClaimTypes.Name, user[0].nom)
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
