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
    public class UserSettingsController : Controller
    {
        private readonly Mweb_DataTableFirstContext _context;

        public UserSettingsController(Mweb_DataTableFirstContext context)
        {
            _context = context;
        }

        // GET: UserSettings
        public async Task<IActionResult> Index()
        {
            var mweb_DataTableFirstContext = _context.UserSettings.Include(u => u.User);
            return View(await mweb_DataTableFirstContext.ToListAsync());
        }

        // GET: UserSettings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSettings = await _context.UserSettings
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.SettingId == id);
            if (userSettings == null)
            {
                return NotFound();
            }

            return View(userSettings);
        }

        // GET: UserSettings/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Userss, "UserId", "UserEmail");
            return View();
        }

        // POST: UserSettings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SettingId,UserId,CenterLat,CenterLng,CenterZoom,MapType,PinRadius,Gps")] UserSettings userSettings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userSettings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Userss, "UserId", "UserEmail", userSettings.UserId);
            return View(userSettings);
        }

        // GET: UserSettings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSettings = await _context.UserSettings.FindAsync(id);
            if (userSettings == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Userss, "UserId", "UserEmail", userSettings.UserId);
            return View(userSettings);
        }

        // POST: UserSettings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SettingId,UserId,CenterLat,CenterLng,CenterZoom,MapType,PinRadius,Gps")] UserSettings userSettings)
        {
            if (id != userSettings.SettingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userSettings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserSettingsExists(userSettings.SettingId))
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
            ViewData["UserId"] = new SelectList(_context.Userss, "UserId", "UserEmail", userSettings.UserId);
            return View(userSettings);
        }

        // GET: UserSettings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSettings = await _context.UserSettings
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.SettingId == id);
            if (userSettings == null)
            {
                return NotFound();
            }

            return View(userSettings);
        }

        // POST: UserSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userSettings = await _context.UserSettings.FindAsync(id);
            _context.UserSettings.Remove(userSettings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserSettingsExists(int id)
        {
            return _context.UserSettings.Any(e => e.SettingId == id);
        }
    }
}
