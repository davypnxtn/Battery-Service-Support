using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Data;
using Model;

namespace Battery_Service_Support.Controllers
{
    public class RelatiesController : Controller
    {
        private readonly DataContext _context;

        public RelatiesController(DataContext context)
        {
            _context = context;
        }

        // GET: Relaties
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Relaties.Include(r => r.Gemeente);
            return View(await dataContext.ToListAsync());
        }

        // GET: Relaties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatie = await _context.Relaties
                .Include(r => r.Gemeente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relatie == null)
            {
                return NotFound();
            }

            return View(relatie);
        }

        // GET: Relaties/Create
        public IActionResult Create()
        {
            ViewData["GemeenteId"] = new SelectList(_context.Gemeentes, "Id", "Naam");
            return View();
        }

        // POST: Relaties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,XjoRelatieCode,Naam,Roepnaam,Adres,ModDatum,GemeenteId")] Relatie relatie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relatie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GemeenteId"] = new SelectList(_context.Gemeentes, "Id", "Naam", relatie.GemeenteId);
            return View(relatie);
        }

        // GET: Relaties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatie = await _context.Relaties.FindAsync(id);
            if (relatie == null)
            {
                return NotFound();
            }
            ViewData["GemeenteId"] = new SelectList(_context.Gemeentes, "Id", "Naam", relatie.GemeenteId);
            return View(relatie);
        }

        // POST: Relaties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,XjoRelatieCode,Naam,Roepnaam,Adres,ModDatum,GemeenteId")] Relatie relatie)
        {
            if (id != relatie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relatie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelatieExists(relatie.Id))
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
            ViewData["GemeenteId"] = new SelectList(_context.Gemeentes, "Id", "Naam", relatie.GemeenteId);
            return View(relatie);
        }

        // GET: Relaties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatie = await _context.Relaties
                .Include(r => r.Gemeente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relatie == null)
            {
                return NotFound();
            }

            return View(relatie);
        }

        // POST: Relaties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var relatie = await _context.Relaties.FindAsync(id);
            _context.Relaties.Remove(relatie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelatieExists(int id)
        {
            return _context.Relaties.Any(e => e.Id == id);
        }
    }
}
