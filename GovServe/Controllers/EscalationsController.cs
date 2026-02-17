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
    public class EscalationsController : Controller
    {
        private readonly GovServeContext _context;

        public EscalationsController(GovServeContext context)
        {
            _context = context;
        }

        // GET: Escalations1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Escalation.ToListAsync());
        }

        // GET: Escalations1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escalation = await _context.Escalation
                .FirstOrDefaultAsync(m => m.EscalationId == id);
            if (escalation == null)
            {
                return NotFound();
            }

            return View(escalation);
        }

        // GET: Escalations1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Escalations1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EscalationId,CaseId,RaisedByType,Reason,Status,CreatedDate")] Escalation escalation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escalation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(escalation);
        }

        // GET: Escalations1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escalation = await _context.Escalation.FindAsync(id);
            if (escalation == null)
            {
                return NotFound();
            }
            return View(escalation);
        }

        // POST: Escalations1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EscalationId,CaseId,RaisedByType,Reason,Status,CreatedDate")] Escalation escalation)
        {
            if (id != escalation.EscalationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escalation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscalationExists(escalation.EscalationId))
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
            return View(escalation);
        }

        // GET: Escalations1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escalation = await _context.Escalation
                .FirstOrDefaultAsync(m => m.EscalationId == id);
            if (escalation == null)
            {
                return NotFound();
            }

            return View(escalation);
        }

        // POST: Escalations1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var escalation = await _context.Escalation.FindAsync(id);
            if (escalation != null)
            {
                _context.Escalation.Remove(escalation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscalationExists(int id)
        {
            return _context.Escalation.Any(e => e.EscalationId == id);
        }
    }
}
