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
            List<SelectListItem> DropDownEscuela = _context.Escuelas.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nombre
            }).ToList();

            var carreraModel = await _context.Carreras
                .Include(x => x.IdEscuelaNavigation)
                .Select(x => new CarreraModel
                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    Nombre = x.Nombre!,
                    NombreEscuela = x.IdEscuelaNavigation.Nombre,
                    ListaEscuela = DropDownEscuela
                }).ToListAsync();

            return View(carreraModel);

        }

        // GET: Carrera/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carreras == null)
            {
                return NotFound();
            }

            var carreraModel = await _context.Carreras.Include(x => x.IdEscuelaNavigation).Select(x => new CarreraModel
            {
                Id = x.Id,
                Codigo = x.Codigo,
                Nombre = x.Nombre!,
                IdEscuela = x.Id,
            }).FirstOrDefaultAsync(m => m.Id == id);
            if (carreraModel == null)
            {
                return NotFound();
            }

            return View(carreraModel);
        }

        // GET: Carrera/Create
        public IActionResult Create()
        {
            List<SelectListItem> DropDownEscuela = _context.Escuelas.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nombre
            }).ToList();

            var carreraModel = new CarreraModel
            {
                ListaEscuela = DropDownEscuela
            };

            return View(carreraModel);
        }

        // POST: Carrera/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Nombre,IdEscuela")] CarreraModel carreraModel)
        {
            ModelState.Remove("ListaEscuela");
            ModelState.Remove("NombreEscuela");
            if (ModelState.IsValid)
            {
                var carrera = new Carrera
                {
                    Codigo = carreraModel.Codigo,
                    Nombre = carreraModel.Nombre,
                    IdEscuela = carreraModel.IdEscuela
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

            List<SelectListItem> DropDownEscuela = _context.Escuelas.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nombre
            }).ToList();

            var carreraModel = new CarreraModel
            {
                Id = carrera.Id,
                Codigo = carrera.Codigo,
                Nombre = carrera.Nombre,
                IdEscuela = carrera.IdEscuela,
                ListaEscuela = DropDownEscuela
            };
            return View(carreraModel);
        }

        // POST: Carrera/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Nombre,IdEscuela")] CarreraModel carreraModel)
        {
            if (id != carreraModel.Id)
            {
                return NotFound();
            }

            ModelState.Remove("ListaEscuela");
            ModelState.Remove("NombreEscuela");
            if (ModelState.IsValid)
            {
                Carrera carrera = new Carrera
                {
                    Id = carreraModel.Id,
                    Codigo = carreraModel.Codigo,
                    Nombre = carreraModel.Nombre,
                    IdEscuela = carreraModel.IdEscuela,
                };
                try
                {
                    _context.Update(carrera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarreraModelExists(carreraModel.Id))
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

            List<SelectListItem> DropDownEscuela = _context.Escuelas.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nombre
            }).ToList();
            carreraModel.ListaEscuela = DropDownEscuela;
            return View(carreraModel);
        }

        // GET: Carrera/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carreras == null)
            {
                return NotFound();
            }

            var carreraModel = await _context.Carreras.Select(x => new CarreraModel
            {
                Id = x.Id,
                Codigo = x.Codigo,
                Nombre = x.Nombre,
                IdEscuela = x.IdEscuela
            }).FirstOrDefaultAsync(m => m.Id == id);
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
