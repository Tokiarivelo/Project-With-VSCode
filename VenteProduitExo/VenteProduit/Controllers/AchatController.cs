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
    public class AchatController : Controller
    {
        private readonly VenteProduitContext _context;

        public AchatController(VenteProduitContext context)
        {
            _context = context;
        }

        // GET: Achat
        public async Task<IActionResult> Index()
        {
            var venteProduitContext = _context.Achat.Include(a => a.Clients);
            return View(await venteProduitContext.ToListAsync());
        }

        // GET: Achat/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var achat = await _context.Achat
                .Include(a => a.Clients)
                .FirstOrDefaultAsync(m => m.AchatId == id);
            if (achat == null)
            {
                return NotFound();
            }

            return View(achat);
        }

        // GET: Achat/Create
        public IActionResult Create()
        {
            ViewData["ClientID"] = new SelectList(_context.Client, "ClientId", "ClientName");
            return View();
        }

        // POST: Achat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AchatId,ClientID,DateAchat")] Achat achat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(achat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientID"] = new SelectList(_context.Client, "ClientId", "ClientName", achat.ClientID);
            return View(achat);
        }

        // GET: Achat/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var achat = await _context.Achat.FindAsync(id);
            if (achat == null)
            {
                return NotFound();
            }
            ViewData["ClientID"] = new SelectList(_context.Client, "ClientId", "ClientName", achat.ClientID);
            return View(achat);
        }

        // POST: Achat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("AchatId,ClientID,DateAchat")] Achat achat)
        {
            if (id != achat.AchatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(achat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AchatExists(achat.AchatId))
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
            ViewData["ClientID"] = new SelectList(_context.Client, "ClientId", "ClientName", achat.ClientID);
            return View(achat);
        }

        // GET: Achat/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var achat = await _context.Achat
                .Include(a => a.Clients)
                .FirstOrDefaultAsync(m => m.AchatId == id);
            if (achat == null)
            {
                return NotFound();
            }

            return View(achat);
        }

        // POST: Achat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var achat = await _context.Achat.FindAsync(id);
            _context.Achat.Remove(achat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AchatExists(long id)
        {
            return _context.Achat.Any(e => e.AchatId == id);
        }
    }
}
