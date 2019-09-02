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
    public class VenteController : Controller
    {
        private readonly VenteProduitContext _context;

        public VenteController(VenteProduitContext context)
        {
            _context = context;
        }

        // GET: Vente
        public async Task<IActionResult> Index()
        {
            var venteProduitContext = _context.Vente.Include(v => v.Achats).Include(v => v.Produit);
            return View(await venteProduitContext.ToListAsync());
        }

        // GET: Vente/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vente = await _context.Vente
                .Include(v => v.Achats)
                .Include(v => v.Produit)
                .FirstOrDefaultAsync(m => m.VenteId == id);
            if (vente == null)
            {
                return NotFound();
            }

            return View(vente);
        }

        // GET: Vente/Create
        public IActionResult Create()
        {
            ViewData["AchatId"] = new SelectList(_context.Achat, "AchatId", "AchatId");
            ViewData["ProduitId"] = new SelectList(_context.Produit, "ProduitId", "ProduitName");
            return View();
        }

        // POST: Vente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VenteId,ProduitId,AchatId,Quantite")] Vente vente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AchatId"] = new SelectList(_context.Achat, "AchatId", "AchatId", vente.AchatId);
            ViewData["ProduitId"] = new SelectList(_context.Produit, "ProduitId", "ProduitName", vente.ProduitId);
            return View(vente);
        }

        // GET: Vente/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vente = await _context.Vente.FindAsync(id);
            if (vente == null)
            {
                return NotFound();
            }
            ViewData["AchatId"] = new SelectList(_context.Achat, "AchatId", "AchatId", vente.AchatId);
            ViewData["ProduitId"] = new SelectList(_context.Produit, "ProduitId", "ProduitName", vente.ProduitId);
            return View(vente);
        }

        // POST: Vente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("VenteId,ProduitId,AchatId,Quantite")] Vente vente)
        {
            if (id != vente.VenteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VenteExists(vente.VenteId))
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
            ViewData["AchatId"] = new SelectList(_context.Achat, "AchatId", "AchatId", vente.AchatId);
            ViewData["ProduitId"] = new SelectList(_context.Produit, "ProduitId", "ProduitName", vente.ProduitId);
            return View(vente);
        }

        // GET: Vente/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vente = await _context.Vente
                .Include(v => v.Achats)
                .Include(v => v.Produit)
                .FirstOrDefaultAsync(m => m.VenteId == id);
            if (vente == null)
            {
                return NotFound();
            }

            return View(vente);
        }

        // POST: Vente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var vente = await _context.Vente.FindAsync(id);
            _context.Vente.Remove(vente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VenteExists(long id)
        {
            return _context.Vente.Any(e => e.VenteId == id);
        }
    }
}
