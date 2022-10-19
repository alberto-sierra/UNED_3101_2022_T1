using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _3101_tarea1_mvc.Models;

namespace _3101_tarea1_mvc.Controllers
{
    public class MatriculaController : Controller
    {
        private readonly EstudianteContext _context;

        public MatriculaController(EstudianteContext context)
        {
            _context = context;
        }

        // GET: Matricula
        public async Task<IActionResult> Index()
        {
              return _context.Matricula != null ? 
                          View(await _context.Matricula.ToListAsync()) :
                          Problem("Entity set 'EstudianteContext.Matricula'  is null.");
        }

        // GET: Matricula/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Matricula == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matricula
                .FirstOrDefaultAsync(m => m.id == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
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
        public async Task<IActionResult> Create([Bind("id,idEstudiante,fecha,periodo,estado,total")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matricula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(matricula);
        }

        // GET: Matricula/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Matricula == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matricula.FindAsync(id);
            if (matricula == null)
            {
                return NotFound();
            }
            return View(matricula);
        }

        // POST: Matricula/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,idEstudiante,fecha,periodo,estado,total")] Matricula matricula)
        {
            if (id != matricula.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matricula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatriculaExists(matricula.id))
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
            return View(matricula);
        }

        // GET: Matricula/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Matricula == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matricula
                .FirstOrDefaultAsync(m => m.id == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // POST: Matricula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Matricula == null)
            {
                return Problem("Entity set 'EstudianteContext.Matricula'  is null.");
            }
            var matricula = await _context.Matricula.FindAsync(id);
            if (matricula != null)
            {
                _context.Matricula.Remove(matricula);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatriculaExists(int id)
        {
          return (_context.Matricula?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
