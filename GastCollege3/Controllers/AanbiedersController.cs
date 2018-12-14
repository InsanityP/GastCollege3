using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GastCollege3.Data;
using GastCollege3.Models;

namespace GastCollege3.Controllers
{
    public class AanbiedersController : Controller
    {
        private readonly E_ventContext _context;

        public AanbiedersController(E_ventContext context)
        {
            _context = context;
        }

        // GET: Aanbieders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aanbieder.ToListAsync());
        }

        // GET: Aanbieders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aanbieder = await _context.Aanbieder
                .FirstOrDefaultAsync(m => m.AanbiederId == id);
            if (aanbieder == null)
            {
                return NotFound();
            }

            return View(aanbieder);
        }

        // GET: Aanbieders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aanbieders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AanbiederId,Name")] Aanbieder aanbieder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aanbieder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aanbieder);
        }

        // GET: Aanbieders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aanbieder = await _context.Aanbieder.FindAsync(id);
            if (aanbieder == null)
            {
                return NotFound();
            }
            return View(aanbieder);
        }

        // POST: Aanbieders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AanbiederId,Name")] Aanbieder aanbieder)
        {
            if (id != aanbieder.AanbiederId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aanbieder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AanbiederExists(aanbieder.AanbiederId))
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
            return View(aanbieder);
        }

        // GET: Aanbieders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aanbieder = await _context.Aanbieder
                .FirstOrDefaultAsync(m => m.AanbiederId == id);
            if (aanbieder == null)
            {
                return NotFound();
            }

            return View(aanbieder);
        }

        // POST: Aanbieders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aanbieder = await _context.Aanbieder.FindAsync(id);
            _context.Aanbieder.Remove(aanbieder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AanbiederExists(int id)
        {
            return _context.Aanbieder.Any(e => e.AanbiederId == id);
        }
    }
}
