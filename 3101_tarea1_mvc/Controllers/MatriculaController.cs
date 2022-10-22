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
    public class MatriculaController : Controller
    {
        private readonly UniversidadContext _context;

        public MatriculaController(UniversidadContext context)
        {
            _context = context;
        }

        // GET: Matricula
        public async Task<IActionResult> Index()
        {
              return _context.MatriculaModel != null ? 
                          View(await _context.MatriculaModel.ToListAsync()) :
                          Problem("Entity set 'UniversidadContext.MatriculaModel'  is null.");
        }

        // GET: Matricula/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MatriculaModel == null)
            {
                return NotFound();
            }

            var matriculaModel = await _context.MatriculaModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (matriculaModel == null)
            {
                return NotFound();
            }

            return View(matriculaModel);
        }

        // GET: Matricula/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Matricula/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,fecha")] MatriculaModel matriculaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matriculaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(matriculaModel);
        }

        // GET: Matricula/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MatriculaModel == null)
            {
                return NotFound();
            }

            var matriculaModel = await _context.MatriculaModel.FindAsync(id);
            if (matriculaModel == null)
            {
                return NotFound();
            }
            return View(matriculaModel);
        }

        // POST: Matricula/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,fecha")] MatriculaModel matriculaModel)
        {
            if (id != matriculaModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matriculaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatriculaModelExists(matriculaModel.id))
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
            return View(matriculaModel);
        }

        // GET: Matricula/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MatriculaModel == null)
            {
                return NotFound();
            }

            var matriculaModel = await _context.MatriculaModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (matriculaModel == null)
            {
                return NotFound();
            }

            return View(matriculaModel);
        }

        // POST: Matricula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MatriculaModel == null)
            {
                return Problem("Entity set 'UniversidadContext.MatriculaModel'  is null.");
            }
            var matriculaModel = await _context.MatriculaModel.FindAsync(id);
            if (matriculaModel != null)
            {
                _context.MatriculaModel.Remove(matriculaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatriculaModelExists(int id)
        {
          return (_context.MatriculaModel?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
