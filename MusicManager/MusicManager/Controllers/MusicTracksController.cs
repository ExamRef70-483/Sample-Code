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
    public class MusicTracksController : Controller
    {
        private readonly MusicManagerContext _context;

        public MusicTracksController(MusicManagerContext context)
        {
            _context = context;
        }

        // GET: MusicTracks
        public async Task<IActionResult> Index()
        {
            return View(await _context.MusicTrack.ToListAsync());
        }

        // GET: MusicTracks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicTrack = await _context.MusicTrack
                .SingleOrDefaultAsync(m => m.ID == id);
            if (musicTrack == null)
            {
                return NotFound();
            }

            return View(musicTrack);
        }

        // GET: MusicTracks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MusicTracks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ArtistID,Title,Length")] MusicTrack musicTrack)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musicTrack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(musicTrack);
        }

        // GET: MusicTracks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicTrack = await _context.MusicTrack.SingleOrDefaultAsync(m => m.ID == id);
            if (musicTrack == null)
            {
                return NotFound();
            }
            return View(musicTrack);
        }

        // POST: MusicTracks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ArtistID,Title,Length")] MusicTrack musicTrack)
        {
            if (id != musicTrack.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musicTrack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicTrackExists(musicTrack.ID))
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
            return View(musicTrack);
        }

        // GET: MusicTracks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicTrack = await _context.MusicTrack
                .SingleOrDefaultAsync(m => m.ID == id);
            if (musicTrack == null)
            {
                return NotFound();
            }

            return View(musicTrack);
        }

        // POST: MusicTracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var musicTrack = await _context.MusicTrack.SingleOrDefaultAsync(m => m.ID == id);
            _context.MusicTrack.Remove(musicTrack);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicTrackExists(int id)
        {
            return _context.MusicTrack.Any(e => e.ID == id);
        }
    }
}
