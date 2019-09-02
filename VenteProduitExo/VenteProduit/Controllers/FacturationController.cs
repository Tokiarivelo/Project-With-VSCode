using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VenteProduit.Context;
using VenteProduit.Models;

namespace VenteProduit.Controllers
{
    public class FacturationController : Controller
    {
        private readonly VenteProduitContext _context;

        public FacturationController(VenteProduitContext context)
        {
            _context = context;
        }

        // GET: Facturation
        public async Task<IActionResult> Index()
        {
            var venteProduitContext = _context.Facturation.Include(f => f.Achat);
            return View(await venteProduitContext.ToListAsync());
        }

        // GET: Facturation/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturation = await _context.Facturation
                .Include(f => f.Achat)
                .FirstOrDefaultAsync(m => m.FacturationId == id);
            if (facturation == null)
            {
                return NotFound();
            }

            return View(facturation);
        }

        // GET: Facturation/Create
        public IActionResult Create()
        {
            ViewData["AchatId"] = new SelectList(_context.Achat, "AchatId", "AchatId");
            return View();
        }

        // POST: Facturation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FacturationId,AchatId,PrixTotal")] Facturation facturation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facturation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AchatId"] = new SelectList(_context.Achat, "AchatId", "AchatId", facturation.AchatId);
            return View(facturation);
        }

        // GET: Facturation/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturation = await _context.Facturation.FindAsync(id);
            if (facturation == null)
            {
                return NotFound();
            }
            ViewData["AchatId"] = new SelectList(_context.Achat, "AchatId", "AchatId", facturation.AchatId);
            return View(facturation);
        }

        // POST: Facturation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("FacturationId,AchatId,PrixTotal")] Facturation facturation)
        {
            if (id != facturation.FacturationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facturation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturationExists(facturation.FacturationId))
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
            ViewData["AchatId"] = new SelectList(_context.Achat, "AchatId", "AchatId", facturation.AchatId);
            return View(facturation);
        }

        // GET: Facturation/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturation = await _context.Facturation
                .Include(f => f.Achat)
                .FirstOrDefaultAsync(m => m.FacturationId == id);
            if (facturation == null)
            {
                return NotFound();
            }

            return View(facturation);
        }

        // POST: Facturation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var facturation = await _context.Facturation.FindAsync(id);
            _context.Facturation.Remove(facturation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturationExists(long id)
        {
            return _context.Facturation.Any(e => e.FacturationId == id);
        }
    }
}
