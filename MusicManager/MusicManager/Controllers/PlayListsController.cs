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
    public class PlayListsController : Controller
    {
        private readonly MusicManagerContext _context;

        public PlayListsController(MusicManagerContext context)
        {
            _context = context;
        }

        // GET: PlayLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlayList.ToListAsync());
        }

        public async Task<IActionResult> ViewPlaylist()
        {
            return View();
        }

        // GET: PlayLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playList = await _context.PlayList
                .SingleOrDefaultAsync(m => m.ID == id);
            if (playList == null)
            {
                return NotFound();
            }

            return View(playList);
        }

        // GET: PlayLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlayLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] PlayList playList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playList);
        }

        // GET: PlayLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playList = await _context.PlayList.SingleOrDefaultAsync(m => m.ID == id);
            if (playList == null)
            {
                return NotFound();
            }
            return View(playList);
        }

        // POST: PlayLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] PlayList playList)
        {
            if (id != playList.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayListExists(playList.ID))
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
            return View(playList);
        }

        // GET: PlayLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playList = await _context.PlayList
                .SingleOrDefaultAsync(m => m.ID == id);
            if (playList == null)
            {
                return NotFound();
            }

            return View(playList);
        }

        // POST: PlayLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playList = await _context.PlayList.SingleOrDefaultAsync(m => m.ID == id);
            _context.PlayList.Remove(playList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayListExists(int id)
        {
            return _context.PlayList.Any(e => e.ID == id);
        }
    }
}
