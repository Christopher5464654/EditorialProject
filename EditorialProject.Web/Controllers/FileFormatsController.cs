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
    public class FileFormatsController : Controller
    {
        private readonly DataContext _context;

        public FileFormatsController(DataContext context)
        {
            _context = context;
        }

        // GET: FileFormats
        public async Task<IActionResult> Index()
        {
            return View(await _context.FileFormats.ToListAsync());
        }

        // GET: FileFormats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileFormat = await _context.FileFormats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fileFormat == null)
            {
                return NotFound();
            }

            return View(fileFormat);
        }

        // GET: FileFormats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FileFormats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] FileFormat fileFormat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fileFormat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fileFormat);
        }

        // GET: FileFormats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileFormat = await _context.FileFormats.FindAsync(id);
            if (fileFormat == null)
            {
                return NotFound();
            }
            return View(fileFormat);
        }

        // POST: FileFormats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] FileFormat fileFormat)
        {
            if (id != fileFormat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fileFormat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FileFormatExists(fileFormat.Id))
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
            return View(fileFormat);
        }

        // GET: FileFormats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileFormat = await _context.FileFormats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fileFormat == null)
            {
                return NotFound();
            }

            return View(fileFormat);
        }

        // POST: FileFormats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fileFormat = await _context.FileFormats.FindAsync(id);
            _context.FileFormats.Remove(fileFormat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FileFormatExists(int id)
        {
            return _context.FileFormats.Any(e => e.Id == id);
        }
    }
}
