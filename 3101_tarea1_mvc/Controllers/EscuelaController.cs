using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _3101_tarea1_mvc.Data;
using _3101_tarea1_mvc.Models;

namespace _3101_tarea1_mvc.Controllers
{
    public class EscuelaController : Controller
    {
        private readonly UniversidadContext _context;

        public EscuelaController(UniversidadContext context)
        {
            _context = context;
        }

        // GET: Escuela
        public async Task<IActionResult> Index()
        {
              return _context.EscuelaModel != null ? 
                          View(await _context.EscuelaModel.ToListAsync()) :
                          Problem("Entity set 'UniversidadContext.EscuelaModel'  is null.");
        }

        // GET: Escuela/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EscuelaModel == null)
            {
                return NotFound();
            }

            var escuelaModel = await _context.EscuelaModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (escuelaModel == null)
            {
                return NotFound();
            }

            return View(escuelaModel);
        }

        // GET: Escuela/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Escuela/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,codigo,nombre")] EscuelaModel escuelaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escuelaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(escuelaModel);
        }

        // GET: Escuela/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EscuelaModel == null)
            {
                return NotFound();
            }

            var escuelaModel = await _context.EscuelaModel.FindAsync(id);
            if (escuelaModel == null)
            {
                return NotFound();
            }
            return View(escuelaModel);
        }

        // POST: Escuela/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,codigo,nombre")] EscuelaModel escuelaModel)
        {
            if (id != escuelaModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escuelaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscuelaModelExists(escuelaModel.id))
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
            return View(escuelaModel);
        }

        // GET: Escuela/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EscuelaModel == null)
            {
                return NotFound();
            }

            var escuelaModel = await _context.EscuelaModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (escuelaModel == null)
            {
                return NotFound();
            }

            return View(escuelaModel);
        }

        // POST: Escuela/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EscuelaModel == null)
            {
                return Problem("Entity set 'UniversidadContext.EscuelaModel'  is null.");
            }
            var escuelaModel = await _context.EscuelaModel.FindAsync(id);
            if (escuelaModel != null)
            {
                _context.EscuelaModel.Remove(escuelaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscuelaModelExists(int id)
        {
          return (_context.EscuelaModel?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
