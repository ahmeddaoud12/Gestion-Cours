using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionCours.Data;
using GestionCours.Models.GestionViewModel;

namespace GestionCours.Controllers
{
    public class CoursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cours
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cours.ToListAsync());
        }

        // GET: Cours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cours = await _context.Cours
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cours == null)
            {
                return NotFound();
            }

            return View(cours);
        }

        // GET: Cours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TitleCours,Description,LinkDownload,Date_Creation")] Cours cours)
        {
            if (ModelState.IsValid)
            {
                cours.Date_Creation = DateTime.Now;
                _context.Add(cours);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cours);
        }

        // GET: Cours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cours = await _context.Cours.SingleOrDefaultAsync(m => m.Id == id);
            if (cours == null)
            {
                return NotFound();
            }
            return View(cours);
        }

        // POST: Cours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TitleCours,Description,LinkDownload,Date_Creation")] Cours cours)
        {
            if (id != cours.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cours);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoursExists(cours.Id))
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
            return View(cours);
        }

        // GET: Cours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cours = await _context.Cours
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cours == null)
            {
                return NotFound();
            }

            return View(cours);
        }

        // POST: Cours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cours = await _context.Cours.SingleOrDefaultAsync(m => m.Id == id);
            _context.Cours.Remove(cours);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoursExists(int id)
        {
            return _context.Cours.Any(e => e.Id == id);
        }
    }
}
