using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GovServe.Data;
using GovServe.Models;

namespace GovServe.Controllers
{
    public class UsersController : Controller
    {
        private readonly GovServeContext _context;

        public UsersController(GovServeContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
			var roles = new List<string>
		 {
			 "Citizen",
			 "Officer",
			 "Supervisory Officer",
			 "Greviance Officer",
			 "Admin"
		 };
			return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,FullName,Email,Phone,Password,ConfirmPassword,Role")] User user)
        {
			if (ModelState.IsValid)
			{
				// Check Email Already Exists
				var emailExists = await _context.User
					.AnyAsync(x => x.Email.ToLower() == user.Email.ToLower());

				if (emailExists)
				{
					ModelState.AddModelError("Email", "This Email is already registered.");
					return View(user);
				}

				// Check Phone Already Exists
				var phoneExists = await _context.User
					.AnyAsync(x => x.Phone == user.Phone);

				if (phoneExists)
				{
					ModelState.AddModelError("Phone", "This Phone Number is already registered.");
					return View(user);
				}
				var roles = new List<string>
			 {
				  "Citizen",
				  "Officer",
				  "Supervisory Officer",
				  "Greviance Officer",
				  "Admin"
			 };
				ViewBag.Roles = new SelectList(roles);

				// Save User
				_context.Add(user);
				await _context.SaveChangesAsync();

				return RedirectToAction(nameof(Index));
			}

			return View(user);
		}

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,FullName,Email,Phone,Password,ConfirmPassword,Role")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.UserId == id);
        }

        public async Task<IActionResult> CitizenDashboard()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            var total = await _context.Applications
                        .CountAsync(x => x.UserId == userId);

            var approved = await _context.Applications
                        .CountAsync(x => x.UserId == userId && x.Status == "Approved");

            var rejected = await _context.Applications
                        .CountAsync(x => x.UserId == userId && x.Status == "Rejected");

            var pending = await _context.Applications
                        .CountAsync(x => x.UserId == userId && x.Status == "Under Review");

            ViewBag.Total = total;
            ViewBag.Approved = approved;
            ViewBag.Rejected = rejected;
            ViewBag.Pending = pending;

            return View();
        }

    }
}
