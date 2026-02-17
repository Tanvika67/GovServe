using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GovServe.Data;
using GovServe.Models;
using Microsoft.AspNetCore.Authentication;

namespace GovServe.Controllers
{
    public class LoginsController : Controller
    {
        private readonly GovServeContext _context;

        public LoginsController(GovServeContext context)
        {
            _context = context;
        }

        // GET: Logins
        public async Task<IActionResult> Index()
        {
            return View(await _context.Login.ToListAsync());
        }

        // GET: Logins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.Login
                .FirstOrDefaultAsync(m => m.Id == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // GET: Logins/Create
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

        // POST: Logins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Password,ConfirmPassword,Role")] Login login)
        {
			if (ModelState.IsValid)
			{
				var user = await _context.User
					.FirstOrDefaultAsync(x => x.Email == login.Email);

				//Email Not Match 
				if (user == null)
				{
					ModelState.AddModelError("", "Invalid Email");
					return View(login);
				}

				// Password Not Match 
				if (user.Password != login.Password)
				{
					ModelState.AddModelError("", "Password Incorrect");
					return View(login);
				}

				// Role Not Match 
				if (user.Role != login.Role)
				{
					ModelState.AddModelError("", "Invalid Role");
					return View(login);
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
				// Credentials Match → Dashboard Redirect
				//return RedirectToAction("Dashboard", "User");
				_context.Login.Add(login);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index", "Logins");

			}

			return View(login);
		}

		// LogOut Method
		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync();
			return RedirectToAction("Create","Logins");
		}

		// GET: Logins/ForgotPassword
		public IActionResult ForgotPassword()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ForgotPassword(Login model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			// Check Email exists in User table
			var user = await _context.User
				.FirstOrDefaultAsync(x => x.Email == model.Email);

			if (user == null)
			{
				ModelState.AddModelError("", "Email not found");
				return View(model);
			}

			// Check Password match
			if (model.Password != model.ConfirmPassword)
			{
				ModelState.AddModelError("", "Passwords do not match");
				return View(model);
			}

			// Update Password
			user.Password = model.Password;  

			_context.Update(user);
			await _context.SaveChangesAsync();

			TempData["Success"] = "Password reset successfully!";

			return RedirectToAction("Create"); // Back to Login
		}
		// GET: Logins/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var login = await _context.Login.FindAsync(id);
			if (login == null)
			{
				return NotFound();
			}
			return View(login);
		}

		// POST: Logins/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Password,ConfirmPassword,Role")] Login login)
		{
			if (id != login.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(login);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!LoginExists(login.Id))
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
			return View(login);
		}

		// GET: Logins/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var login = await _context.Login
				.FirstOrDefaultAsync(m => m.Id == id);
			if (login == null)
			{
				return NotFound();
			}

			return View(login);
		}

		// POST: Logins/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var login = await _context.Login.FindAsync(id);
			if (login != null)
			{
				_context.Login.Remove(login);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool LoginExists(int id)
        {
            return _context.Login.Any(e => e.Id == id);
        }
    }
}
