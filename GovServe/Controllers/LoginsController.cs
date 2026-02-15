using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GovServe.Data;
using GovServe.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Client;

namespace GovServe.Controllers
{
	public class LoginsController : Controller
	{
		private readonly GovServeContext _context;

		public LoginsController(GovServeContext context)
		{
			_context = context;
		}

		//GET: Logins
		//public async Task<IActionResult> Index()
		//{
		//	var govServeContext = _context.Login.Include(l => l.Registration);
		//	return View(await govServeContext.ToListAsync());
		//}



		// GET: Logins/Create
		public IActionResult Create()
		{
			ViewData["Email"] = new SelectList(_context.Registration, "Email", "Email");
			return View();
		}

		// POST: Logins/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Email,Password,Role")] Login login)
		{
			if (ModelState.IsValid)
			{
				var user = await _context.Registration
					.FirstOrDefaultAsync(x => x.Email.ToLower() == login.Email.ToLower());

				if (user == null)
				{
					ModelState.AddModelError("", "Invalid Email");
					return View(login);
				}

				if (user.PasswordHash != login.Password)
				{
					ModelState.AddModelError("", "Password Incorrect");
					return View(login);
				}

				//if (user.Role != login.Role)
				//{
				//	ModelState.AddModelError("", "Invalid Role");
				//	return View(login);
				//}

				return RedirectToAction("Index", "Home");
			}

			return View(login);
		}

		public IActionResult Logout()
		{
			return RedirectToAction("Create", "Logins");
		}

		public IActionResult ForgotPassword()
		{
			return View();
		}



	}
}