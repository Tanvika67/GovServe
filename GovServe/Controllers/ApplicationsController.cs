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
            var govServeContext = _context.Applications.Include(a => a.User);
            return View(await govServeContext.ToListAsync());
        }

        // GET: Applications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applications = await _context.Applications
                .Include(a => a.User)
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
            ViewData["UserId"] = new SelectList(_context.Registration, "UserId", "Email");
            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationID,UserId,SubmittedDate,Status")] Applications applications)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applications);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Registration, "UserId", "Email", applications.UserId);
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
            ViewData["UserId"] = new SelectList(_context.Registration, "UserId", "Email", applications.UserId);
            return View(applications);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicationID,UserId,SubmittedDate,Status")] Applications applications)
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
            ViewData["UserId"] = new SelectList(_context.Registration, "UserId", "Email", applications.UserId);
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
                .Include(a => a.User)
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
    }
}
