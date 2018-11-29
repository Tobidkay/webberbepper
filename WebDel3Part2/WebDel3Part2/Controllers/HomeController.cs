using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebDel3Part2.Data;
using WebDel3Part2.Models;
using WebDel3Part2.ViewModels;

namespace WebDel3Part2.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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

        public async void PromoteToAdmin(string email)
        {
            var user = _context.Users.FirstOrDefault(x => email != null && x.Email == email);
            var identityUserClaims = _context.UserClaims.Where(x => x.UserId == user.Id && x.ClaimValue == "Admin").ToArray();
            if (!identityUserClaims.Any())
            {
                await _userManager.AddClaimAsync(user, new Claim("Admin", "Admin"));
            }
        }
    }
}
