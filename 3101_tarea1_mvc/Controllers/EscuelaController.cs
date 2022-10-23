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
                        View(await _context.Escuelas.Select(x => new EscuelaModel
                        {
                            Id = x.Id,
                            Codigo = x.Codigo,
                            Nombre = x.Nombre!
                        }).ToListAsync()) :
                          Problem("Entity set 'UniversidadContext.Escuelas'  is null.");
        }

        // GET: Escuela/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EscuelaModel == null)
            {
                return NotFound();
            }

            var escuelaModel = await _context.Escuelas.Select(x => new EscuelaModel
            {
                Id = x.Id,
                Codigo = x.Codigo,
                Nombre = x.Nombre!
            }).FirstOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Create([Bind("Id,Codigo,Nombre")] EscuelaModel escuelaModel)
        {
            if (ModelState.IsValid)
            {
                var escuela = new Escuela
                {
                    Id = escuelaModel.Id,
                    Codigo = escuelaModel.Codigo,
                    Nombre = escuelaModel.Nombre
                };
                _context.Add(escuela);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(escuelaModel);
        }

        // GET: Escuela/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Escuelas == null)
            {
                return NotFound();
            }

            var escuela = await _context.Escuelas.FindAsync(id);
            if (escuela == null)
            {
                return NotFound();
            }
            var escuelaModel = new EscuelaModel
            {
                Id = escuela.Id,
                Codigo = escuela.Codigo,
                Nombre = escuela.Nombre!,
            };
            return View(escuelaModel);
        }

        // POST: Escuela/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,codigo,nombre")] EscuelaModel escuelaModel)
        {
            if (id != escuelaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Escuela escuela = new Escuela
                {
                    Id = escuelaModel.Id,
                    Codigo = escuelaModel.Codigo,
                    Nombre = escuelaModel.Nombre
                };
                try
                {
                    _context.Update(escuela);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscuelaModelExists(escuelaModel.Id))
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
            if (id == null || _context.Escuelas == null)
            {
                return NotFound();
            }

            var escuelaModel = await _context.Escuelas.Select(x => new EscuelaModel
            {
                Id = x.Id,
                Codigo = x.Codigo,
                Nombre = x.Nombre!
            }).FirstOrDefaultAsync(m => m.Id == id);
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
            if (_context.Escuelas == null)
            {
                return Problem("Entity set 'UniversidadContext.Escuelas'  is null.");
            }
            var escuela = await _context.Escuelas.FindAsync(id);
            if (escuela != null)
            {
                _context.Escuelas.Remove(escuela);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscuelaModelExists(int id)
        {
          return (_context.Escuelas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
