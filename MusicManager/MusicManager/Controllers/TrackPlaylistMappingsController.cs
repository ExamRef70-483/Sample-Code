using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicManager.Models;

namespace MusicManager.Controllers
{
    public class TrackPlaylistMappingsController : Controller
    {
        private readonly MusicManagerContext _context;

        public TrackPlaylistMappingsController(MusicManagerContext context)
        {
            _context = context;
        }

        // GET: TrackPlaylistMappings
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrackPlaylistMapping.ToListAsync());
        }

        // GET: TrackPlaylistMappings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trackPlaylistMapping = await _context.TrackPlaylistMapping
                .SingleOrDefaultAsync(m => m.ID == id);
            if (trackPlaylistMapping == null)
            {
                return NotFound();
            }

            return View(trackPlaylistMapping);
        }

        // GET: TrackPlaylistMappings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrackPlaylistMappings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TrackID,PlaylistID")] TrackPlaylistMapping trackPlaylistMapping)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trackPlaylistMapping);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trackPlaylistMapping);
        }

        // GET: TrackPlaylistMappings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trackPlaylistMapping = await _context.TrackPlaylistMapping.SingleOrDefaultAsync(m => m.ID == id);
            if (trackPlaylistMapping == null)
            {
                return NotFound();
            }
            return View(trackPlaylistMapping);
        }

        // POST: TrackPlaylistMappings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TrackID,PlaylistID")] TrackPlaylistMapping trackPlaylistMapping)
        {
            if (id != trackPlaylistMapping.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trackPlaylistMapping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrackPlaylistMappingExists(trackPlaylistMapping.ID))
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
            return View(trackPlaylistMapping);
        }

        // GET: TrackPlaylistMappings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trackPlaylistMapping = await _context.TrackPlaylistMapping
                .SingleOrDefaultAsync(m => m.ID == id);
            if (trackPlaylistMapping == null)
            {
                return NotFound();
            }

            return View(trackPlaylistMapping);
        }

        // POST: TrackPlaylistMappings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trackPlaylistMapping = await _context.TrackPlaylistMapping.SingleOrDefaultAsync(m => m.ID == id);
            _context.TrackPlaylistMapping.Remove(trackPlaylistMapping);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrackPlaylistMappingExists(int id)
        {
            return _context.TrackPlaylistMapping.Any(e => e.ID == id);
        }
    }
}
