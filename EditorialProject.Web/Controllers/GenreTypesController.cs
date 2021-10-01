using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EditorialProject.Web.Data;
using EditorialProject.Web.Data.Entities;

namespace EditorialProject.Web.Controllers
{
    public class GenreTypesController : Controller
    {
        private readonly DataContext _context;

        public GenreTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: GenreTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.GenreTypes.ToListAsync());
        }

        // GET: GenreTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genreType = await _context.GenreTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genreType == null)
            {
                return NotFound();
            }

            return View(genreType);
        }

        // GET: GenreTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GenreTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] GenreType genreType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genreType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genreType);
        }

        // GET: GenreTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genreType = await _context.GenreTypes.FindAsync(id);
            if (genreType == null)
            {
                return NotFound();
            }
            return View(genreType);
        }

        // POST: GenreTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] GenreType genreType)
        {
            if (id != genreType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genreType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenreTypeExists(genreType.Id))
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
            return View(genreType);
        }

        // GET: GenreTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genreType = await _context.GenreTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genreType == null)
            {
                return NotFound();
            }

            return View(genreType);
        }

        // POST: GenreTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genreType = await _context.GenreTypes.FindAsync(id);
            _context.GenreTypes.Remove(genreType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenreTypeExists(int id)
        {
            return _context.GenreTypes.Any(e => e.Id == id);
        }
    }
}
