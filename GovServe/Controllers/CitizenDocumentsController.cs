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
    public class CitizenDocumentsController : Controller
    {
        private readonly GovServeContext _context;

        public CitizenDocumentsController(GovServeContext context)
        {
            _context = context;
        }

        // GET: CitizenDocuments
        public async Task<IActionResult> Index()
        {
            var govServeContext = _context.CitizenDocument.Include(c => c.Application);
            return View(await govServeContext.ToListAsync());
        }

        // GET: CitizenDocuments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizenDocument = await _context.CitizenDocument
                .Include(c => c.Application)
                .FirstOrDefaultAsync(m => m.CitizenDocumentID == id);
            if (citizenDocument == null)
            {
                return NotFound();
            }

            return View(citizenDocument);
        }

        // GET: CitizenDocuments/Create
        public IActionResult Create()
        {
            ViewData["ApplicationID"] = new SelectList(_context.Applications, "ApplicationID", "ApplicationID");
            return View();
        }

        // POST: CitizenDocuments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CitizenDocumentID,ApplicationID,DocumentType,FilePath,UploadedDate,VerificationStatus")] CitizenDocument citizenDocument)
        {
            if (ModelState.IsValid)
            {
                _context.Add(citizenDocument);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationID"] = new SelectList(_context.Applications, "ApplicationID", "ApplicationID", citizenDocument.ApplicationID);
            return View(citizenDocument);
        }

        // GET: CitizenDocuments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizenDocument = await _context.CitizenDocument.FindAsync(id);
            if (citizenDocument == null)
            {
                return NotFound();
            }
            ViewData["ApplicationID"] = new SelectList(_context.Applications, "ApplicationID", "ApplicationID", citizenDocument.ApplicationID);
            return View(citizenDocument);
        }

        // POST: CitizenDocuments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CitizenDocumentID,ApplicationID,DocumentType,FilePath,UploadedDate,VerificationStatus")] CitizenDocument citizenDocument)
        {
            if (id != citizenDocument.CitizenDocumentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(citizenDocument);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitizenDocumentExists(citizenDocument.CitizenDocumentID))
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
            ViewData["ApplicationID"] = new SelectList(_context.Applications, "ApplicationID", "ApplicationID", citizenDocument.ApplicationID);
            return View(citizenDocument);
        }

        // GET: CitizenDocuments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizenDocument = await _context.CitizenDocument
                .Include(c => c.Application)
                .FirstOrDefaultAsync(m => m.CitizenDocumentID == id);
            if (citizenDocument == null)
            {
                return NotFound();
            }

            return View(citizenDocument);
        }

        // POST: CitizenDocuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var citizenDocument = await _context.CitizenDocument.FindAsync(id);
            if (citizenDocument != null)
            {
                _context.CitizenDocument.Remove(citizenDocument);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitizenDocumentExists(int id)
        {
            return _context.CitizenDocument.Any(e => e.CitizenDocumentID == id);
        }
    }
}
