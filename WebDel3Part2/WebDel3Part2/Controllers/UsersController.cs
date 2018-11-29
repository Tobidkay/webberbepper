using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebDel3Part2.Data;
using WebDel3Part2.Models;

namespace WebDel3Part2.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;


        public UsersController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email")] User user)
        {
            if (ModelState.IsValid)
            {
                var users = _context.Users.Where(x => x.Email == user.Email);
                var userIds = new List<string>();
                foreach (var _user in users)
                {
                    userIds.Add(_user.Id);
                }

                foreach (var userId in userIds)
                {
                    var claims = _context.UserClaims.Where(x => x.UserId == userId);
                    bool IsAdmin = false;
                    foreach (var claim in claims)
                    {
                        if (claim.ClaimValue == "Admin")
                        {
                            IsAdmin = true;
                        }
                    }

                    if (!IsAdmin)
                    {
                        foreach (var AddClaims in users)
                        {
                            await _userManager.AddClaimAsync(AddClaims, new Claim("Admin", "Admin"));
                        }
                    }
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
    }
}
