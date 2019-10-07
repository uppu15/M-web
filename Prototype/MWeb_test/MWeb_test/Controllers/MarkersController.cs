using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MWeb_test.Models;

namespace MWeb_test.Controllers
{
    public class MarkersController : Controller
    {
        private readonly Mweb_DataTableFirstContext _context;

        public MarkersController(Mweb_DataTableFirstContext context)
        {
            _context = context;
        }

        // GET: Markers
        public async Task<IActionResult> Index()
        {
            var mweb_DataTableFirstContext = _context.Markers.Include(m => m.User);
            return View(await mweb_DataTableFirstContext.ToListAsync());
        }

        // GET: Markers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var markers = await _context.Markers
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.MarkerId == id);
            if (markers == null)
            {
                return NotFound();
            }

            return View(markers);
        }

        // GET: Markers/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Userss, "UserId", "UserEmail");
            return View();
        }

        // POST: Markers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MarkerId,UserId,MarkerLat,MarkerLng,Photo,PhotoPath")] Markers markers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(markers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Userss, "UserId", "UserEmail", markers.UserId);
            return View(markers);
        }

        // GET: Markers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var markers = await _context.Markers.FindAsync(id);
            if (markers == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Userss, "UserId", "UserEmail", markers.UserId);
            return View(markers);
        }

        // POST: Markers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MarkerId,UserId,MarkerLat,MarkerLng,Photo,PhotoPath")] Markers markers)
        {
            if (id != markers.MarkerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(markers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkersExists(markers.MarkerId))
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
            ViewData["UserId"] = new SelectList(_context.Userss, "UserId", "UserEmail", markers.UserId);
            return View(markers);
        }

        // GET: Markers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var markers = await _context.Markers
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.MarkerId == id);
            if (markers == null)
            {
                return NotFound();
            }

            return View(markers);
        }

        // POST: Markers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var markers = await _context.Markers.FindAsync(id);
            _context.Markers.Remove(markers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkersExists(int id)
        {
            return _context.Markers.Any(e => e.MarkerId == id);
        }
    }
}
