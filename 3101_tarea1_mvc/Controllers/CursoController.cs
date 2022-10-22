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
    public class CursoController : Controller
    {
        private readonly UniversidadContext _context;

        public CursoController(UniversidadContext context)
        {
            _context = context;
        }

        // GET: Curso
        public async Task<IActionResult> Index()
        {
              return _context.CursoModel != null ? 
                          View(await _context.CursoModel.ToListAsync()) :
                          Problem("Entity set 'UniversidadContext.CursoModel'  is null.");
        }

        // GET: Curso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CursoModel == null)
            {
                return NotFound();
            }

            var cursoModel = await _context.CursoModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (cursoModel == null)
            {
                return NotFound();
            }

            return View(cursoModel);
        }

        // GET: Curso/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Curso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,codigo,nombre,descripcion,precio")] CursoModel cursoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cursoModel);
        }

        // GET: Curso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CursoModel == null)
            {
                return NotFound();
            }

            var cursoModel = await _context.CursoModel.FindAsync(id);
            if (cursoModel == null)
            {
                return NotFound();
            }
            return View(cursoModel);
        }

        // POST: Curso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,codigo,nombre,descripcion,precio")] CursoModel cursoModel)
        {
            if (id != cursoModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoModelExists(cursoModel.id))
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
            return View(cursoModel);
        }

        // GET: Curso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CursoModel == null)
            {
                return NotFound();
            }

            var cursoModel = await _context.CursoModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (cursoModel == null)
            {
                return NotFound();
            }

            return View(cursoModel);
        }

        // POST: Curso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CursoModel == null)
            {
                return Problem("Entity set 'UniversidadContext.CursoModel'  is null.");
            }
            var cursoModel = await _context.CursoModel.FindAsync(id);
            if (cursoModel != null)
            {
                _context.CursoModel.Remove(cursoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoModelExists(int id)
        {
          return (_context.CursoModel?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
