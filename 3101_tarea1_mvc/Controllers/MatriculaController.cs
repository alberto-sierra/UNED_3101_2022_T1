using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _3101_tarea1_mvc.Data;
using _3101_tarea1_mvc.Models;
using _3101_tarea1_mvc.Entities;

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
              return _context.Matriculas != null ? 
                          View(await _context.Matriculas
                          .Include(x => x.IdEstudianteNavigation)
                          .Include(x => x.MatriculaDetalles)
                          .OrderByDescending(x => x.Fecha)
                          .Select(x => new MatriculaModel
                          {
                              Id = x.Id,
                              IdEstudiante = x.IdEstudiante,
                              Fecha = x.Fecha,
                              NombreEstudiante = $"{x.IdEstudianteNavigation.Nombre}" +
                                $"{x.IdEstudianteNavigation.PrimerApellido}" +
                                $"{x.IdEstudianteNavigation.SegundoApellido}",
                          })
                          .ToListAsync()) :
                          Problem("Entity set 'UniversidadContext.Matriculas'  is null.");
        }

        // GET: Matricula/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Matriculas == null)
            {
                return NotFound();
            }

            var matriculaModel = await _context.Matriculas
                .Include(x => x.IdEstudianteNavigation)
                .Include(x => x.MatriculaDetalles)
                .Select(x => new MatriculaModel
            {
                Id = x.Id,
                IdEstudiante = x.IdEstudiante,
                Fecha = x.Fecha
            })
            .FirstOrDefaultAsync(m => m.Id == id);
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
                var matricula = new Matricula
                {
                    Id = matriculaModel.Id,
                    IdEstudiante = matriculaModel.IdEstudiante,
                    Fecha = matriculaModel.Fecha
                };
                _context.Add(matricula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(matriculaModel);
        }

        // GET: Matricula/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Matriculas == null)
            {
                return NotFound();
            }

            var matriculaModel = await _context.Matriculas.Select(x => new MatriculaModel
            {
                Id = x.Id,
                IdEstudiante = x.IdEstudiante,
                Fecha = x.Fecha
            }).FirstOrDefaultAsync(m => m.Id == id);

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
            if (_context.Matriculas == null)
            {
                return Problem("Entity set 'UniversidadContext.Matriculas'  is null.");
            }
            var matricula = await _context.Matriculas.FindAsync(id);
            if (matricula != null)
            {
                _context.Matriculas.Remove(matricula);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatriculaModelExists(int id)
        {
          return (_context.Matriculas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
