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
    public class EstudianteController : Controller
    {
        private readonly UniversidadContext _context;

        public EstudianteController(UniversidadContext context)
        {
            _context = context;
        }

        // GET: Estudiante
        public async Task<IActionResult> Index()
        {
              return _context.EstudianteModel != null ? 
                          View(await _context.Estudiantes.Select(x => new EstudianteModel
                          {
                              Id = x.Id,
                              Identificacion = x.Identificacion,
                              Nombre = x.Nombre,
                              PrimerApellido = x.PrimerApellido,
                              SegundoApellido = x.SegundoApellido,
                              FechaNacimiento = x.FechaNacimiento,
                              FechaIngreso = x.FechaIngreso
                          }).ToListAsync()) :
                          Problem("Entity set 'UniversidadContext.Estudiantes'  is null.");
        }

        // GET: Estudiante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EstudianteModel == null)
            {
                return NotFound();
            }

            var estudianteModel = await _context.Estudiantes.Select(x => new EstudianteModel
            {
                Id = x.Id,
                Identificacion = x.Identificacion,
                Nombre = x.Nombre,
                PrimerApellido = x.PrimerApellido,
                SegundoApellido = x.SegundoApellido,
                FechaNacimiento = x.FechaNacimiento,
                FechaIngreso = x.FechaIngreso
            }).FirstOrDefaultAsync(m => m.Id == id);
            if (estudianteModel == null)
            {
                return NotFound();
            }

            return View(estudianteModel);
        }

        // GET: Estudiante/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudiante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Identificacion,Nombre,PrimerApellido,SegundoApellido,FechaNacimiento,FechaIngreso")] EstudianteModel estudianteModel)
        {
            if (ModelState.IsValid)
            {
                var estudiante = new Estudiante
                {
                    Identificacion = estudianteModel.Identificacion,
                    Nombre = estudianteModel.Nombre,
                    PrimerApellido = estudianteModel.PrimerApellido,
                    SegundoApellido = estudianteModel.SegundoApellido,
                    FechaNacimiento = estudianteModel.FechaNacimiento,
                    FechaIngreso = estudianteModel.FechaIngreso
                };
                _context.Add(estudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estudianteModel);
        }

        // GET: Estudiante/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            var estudianteModel = new EstudianteModel
            {
                Id = estudiante.Id,
                Identificacion = estudiante.Identificacion,
                Nombre = estudiante.Nombre,
                PrimerApellido = estudiante.PrimerApellido,
                SegundoApellido = estudiante.SegundoApellido,
                FechaNacimiento = estudiante.FechaNacimiento,
                FechaIngreso = estudiante.FechaIngreso
            };
            return View(estudianteModel);
        }

        // POST: Estudiante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Identificacion,Nombre,PrimerApellido,SegundoApellido,FechaNacimiento,FechaIngreso")] EstudianteModel estudianteModel)
        {
            if (id != estudianteModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var estudiante = new Estudiante
                    {
                        Id = estudianteModel.Id,
                        Identificacion = estudianteModel.Identificacion,
                        Nombre = estudianteModel.Nombre,
                        PrimerApellido = estudianteModel.PrimerApellido,
                        SegundoApellido = estudianteModel.SegundoApellido,
                        FechaNacimiento = estudianteModel.FechaNacimiento,
                        FechaIngreso = estudianteModel.FechaIngreso
                    };
                    _context.Update(estudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteModelExists(estudianteModel.Id))
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
            return View(estudianteModel);
        }

        // GET: Estudiante/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }

            var estudianteModel = await _context.Estudiantes.Select(x => new EstudianteModel
            {
                Id = x.Id,
                Identificacion = x.Identificacion,
                Nombre = x.Nombre,
                PrimerApellido = x.PrimerApellido,
                SegundoApellido = x.SegundoApellido,
                FechaNacimiento = x.FechaNacimiento,
                FechaIngreso = x.FechaIngreso
            }).FirstOrDefaultAsync(m => m.Id == id);
            if (estudianteModel == null)
            {
                return NotFound();
            }

            return View(estudianteModel);
        }

        // POST: Estudiante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Estudiantes == null)
            {
                return Problem("Entity set 'UniversidadContext.Estudiantes'  is null.");
            }
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteModelExists(long id)
        {
          return (_context.EstudianteModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
