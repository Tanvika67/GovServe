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
    public class ApplicationsController : Controller
    {
        private readonly GovServeContext _context;

        public ApplicationsController(GovServeContext context)
        {
            _context = context;
        }

        // GET: Applications
        public async Task<IActionResult> Index()
        {
            return View(await _context.Applications.ToListAsync());
        }

        // GET: Applications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applications = await _context.Applications
                .FirstOrDefaultAsync(m => m.ApplicationID == id);
            if (applications == null)
            {
                return NotFound();
            }

            return View(applications);
        }

        // GET: Applications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationID,UserId,ServiceID,SubmittedDate,WorkflowStatus,Status")] Applications applications)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applications);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applications);
        }

        // GET: Applications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applications = await _context.Applications.FindAsync(id);
            if (applications == null)
            {
                return NotFound();
            }
            return View(applications);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicationID,UserId,ServiceID,SubmittedDate,WorkflowStatus,Status")] Applications applications)
        {
            if (id != applications.ApplicationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applications);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationsExists(applications.ApplicationID))
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
            return View(applications);
        }

        // GET: Applications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applications = await _context.Applications
                .FirstOrDefaultAsync(m => m.ApplicationID == id);
            if (applications == null)
            {
                return NotFound();
            }

            return View(applications);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applications = await _context.Applications.FindAsync(id);
            if (applications != null)
            {
                _context.Applications.Remove(applications);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationsExists(int id)
        {
            return _context.Applications.Any(e => e.ApplicationID == id);
        }


		public IActionResult OfficerDashboard()
		{
			//written by nikita and here need to join the department table to get the department id of the login officer and then filter the applications based on that department id
			int departmentId = 2; // login officer cha department id (demo sathi)

			// Total assigned to department
			//int assigned = _context.Applications
			//			   .Where(a => a.DepartmentId == departmentId)
			//			   .Count();

			//// Approved
			//int approved = _context.Applications
			//			   .Where(a => a.DepartmentId == departmentId && a.Status == "Approved")
			//			   .Count();

			//// Pending
			//int pending = _context.Applications
			//			  .Where(a => a.DepartmentId == departmentId && a.Status == "Pending")
			//			  .Count();

			//// Rejected
			//int rejected = _context.Applications
			//			   .Where(a => a.DepartmentId == departmentId && a.Status == "Rejected")
			//			   .Count();

			//ViewBag.Assigned = assigned;
			//ViewBag.Approved = approved;
			//ViewBag.Pending = pending;
			//ViewBag.Rejected = rejected;

			return View();
		}
	}
}
