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
    public class CarreraController : Controller
    {
        private readonly UniversidadContext _context;

        public CarreraController(UniversidadContext context)
        {
            _context = context;
        }

        // GET: Carrera
        public async Task<IActionResult> Index()
        {
              return _context.CarreraModel != null ? 
                          View(await _context.Carreras.Select(x => new CarreraModel
                          {
                              id = x.Id,
                              codigo = x.Codigo,
                              nombre = x.Nombre!,
                              idEscuela = x.IdEscuela
                          }).ToListAsync()) :
                          Problem("Entity set 'UniversidadContext.Carreras'  is null.");
        }

        // GET: Carrera/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarreraModel == null)
            {
                return NotFound();
            }

            var carreraModel = await _context.Carreras.Select(x => new CarreraModel
            {
                id = x.Id,
                codigo = x.Codigo,
                nombre = x.Nombre!,
                idEscuela = x.IdEscuela
            }).FirstOrDefaultAsync(m => m.id == id);
            if (carreraModel == null)
            {
                return NotFound();
            }

            return View(carreraModel);
        }

        // GET: Carrera/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carrera/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,codigo,nombre")] CarreraModel carreraModel)
        {
            if (ModelState.IsValid)
            {
                var carrera = new Carrera
                {
                    Id = carreraModel.id,
                    Codigo = carreraModel.codigo,
                    Nombre = carreraModel.nombre,
                    IdEscuela = carreraModel.idEscuela
                };
                _context.Add(carrera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carreraModel);
        }

        // GET: Carrera/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarreraModel == null)
            {
                return NotFound();
            }

            var carrera = await _context.Carreras.FindAsync(id);
            if (carrera == null)
            {
                return NotFound();
            }
            var carreraModel = new CarreraModel
            {
                id = carrera.Id,
                codigo = carrera.Codigo,
                nombre = carrera.Nombre,
                idEscuela = carrera.IdEscuela
            };
            return View(carreraModel);
        }

        // POST: Carrera/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,codigo,nombre")] CarreraModel carreraModel)
        {
            if (id != carreraModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Carrera carrera = new Carrera
                {
                    Id = carreraModel.id,
                    Codigo = carreraModel.codigo,
                    Nombre = carreraModel.nombre,
                    IdEscuela = carreraModel.idEscuela
                };
                try
                {
                    _context.Update(carrera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarreraModelExists(carreraModel.id))
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
            return View(carreraModel);
        }

        // GET: Carrera/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarreraModel == null)
            {
                return NotFound();
            }

            var carreraModel = await _context.Carreras.Select(x => new CarreraModel
            {
                id = x.Id,
                codigo = x.Codigo,
                nombre = x.Nombre,
                idEscuela = x.IdEscuela
            }).FirstOrDefaultAsync(m => m.id == id);
            if (carreraModel == null)
            {
                return NotFound();
            }

            return View(carreraModel);
        }

        // POST: Carrera/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Carreras == null)
            {
                return Problem("Entity set 'UniversidadContext.Carreras'  is null.");
            }
            var carrera = await _context.Carreras.FindAsync(id);
            if (carrera != null)
            {
                _context.Carreras.Remove(carrera);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarreraModelExists(int id)
        {
          return (_context.Carreras?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
