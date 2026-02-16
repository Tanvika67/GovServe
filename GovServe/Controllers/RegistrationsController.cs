/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GovServe.Data;
using GovServe.Models;
using Microsoft.AspNetCore.Authorization;

namespace GovServe.Controllers
{
	public class RegistrationsController : Controller
	{
		private readonly GovServeContext _context;

		public RegistrationsController(GovServeContext context)
		{
			_context = context;
		}

		// GET: Registrations
		[Authorize(Roles = "Admin")]// Only allow admins to access the Index
		public async Task<IActionResult> Index()
		{
			return View(await _context.Registration.ToListAsync());
		}

		// GET: Registrations/Details/5
		[Authorize(Roles = "Admin")]// Only allow admins to access the Details
		public async Task<IActionResult> Details(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var registration = await _context.Registration
				.FirstOrDefaultAsync(m => m.Email == id);
			if (registration == null)
			{
				return NotFound();
			}

			return View(registration);
		}

		// GET: Registrations/Create

		public IActionResult Create()
		{
			return View();
		}

		// POST: Registrations/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Email,FullName,Phone,PasswordHash")] Registration registration)
		{
			if (ModelState.IsValid)
			{
				// Check Email Already Exists
				var emailExists = await _context.Registration
					.AnyAsync(x => x.Email.ToLower() == registration.Email.ToLower());

				if (emailExists)
				{
					ModelState.AddModelError("Email", "This Email is already registered.");
					return View(registration);
				}

				// Check Phone Already Exists (Optional but Professional)
				var phoneExists = await _context.Registration
					.AnyAsync(x => x.Phone == registration.Phone);

				if (phoneExists)
				{
					ModelState.AddModelError("Phone", "This Phone Number is already registered.");
					return View(registration);
				}

				// Save Registration
				_context.Add(registration);
				await _context.SaveChangesAsync();

				return RedirectToAction(nameof(Index));
			}

			return View(registration);
		}

		// GET: Registrations/Edit/5
		public async Task<IActionResult> Edit(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var registration = await _context.Registration.FindAsync(id);
			if (registration == null)
			{
				return NotFound();
			}
			return View(registration);
		}

		// POST: Registrations/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(string id, [Bind("Email,FullName,Phone,PasswordHash")] Registration registration)
		{
			if (id != registration.Email)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(registration);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!RegistrationExists(registration.Email))
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
			return View(registration);
		}

		// GET: Registrations/Delete/5
		[Authorize(Roles = "Admin")]// Only allow admins to access the delete 
		public async Task<IActionResult> Delete(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var registration = await _context.Registration
				.FirstOrDefaultAsync(m => m.Email == id);
			if (registration == null)
			{
				return NotFound();
			}

			return View(registration);
		}

		// POST: Registrations/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(string id)
		{
			var registration = await _context.Registration.FindAsync(id);
			if (registration != null)
			{
				_context.Registration.Remove(registration);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool RegistrationExists(string id)
		{
			return _context.Registration.Any(e => e.Email == id);
		}
	}
}*/
