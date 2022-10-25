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
            List<SelectListItem> DropDownCarrera = _context.Carreras.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nombre
            }).ToList();

            return _context.Cursos != null ? 
                          View(await _context.Cursos.Include(x => x.IdCarreraNavigation).Select(x => new CursoModel
                          {
                              Id = x.Id,
                              Codigo = x.Codigo,
                              Nombre = x.Nombre!,
                              Descripcion = x.Descripcion,
                              IdCarrera = x.IdCarrera,
                              Precio = x.Precio,
                              NombreCarrera = x.IdCarreraNavigation.Nombre,
                              ListaCarrera = DropDownCarrera
                          }).ToListAsync()) :
                          Problem("Entity set 'UniversidadContext.Cursos'  is null.");
        }

        // GET: Curso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            List<SelectListItem> DropDownCarrera = _context.Carreras.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nombre
            }).ToList();

            var cursoModel = await _context.Cursos.Include(x => x.IdCarreraNavigation).Select(x => new CursoModel
            {
                Id = x.Id,
                Codigo = x.Codigo,
                Nombre = x.Nombre!,
                Descripcion = x.Descripcion!,
                IdCarrera = x.IdCarrera,
                Precio = x.Precio,
                NombreCarrera = x.IdCarreraNavigation.Nombre,
                ListaCarrera = DropDownCarrera
            }).FirstOrDefaultAsync(m => m.Id == id);

            if (cursoModel == null)
            {
                return NotFound();
            }

            if (cursoModel.Descripcion == null)
            {
                cursoModel.Descripcion = "";
            }

            return View(cursoModel);
        }

        // GET: Curso/Create
        public IActionResult Create()
        {
            List<SelectListItem> DropDownCarrera = _context.Carreras.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nombre
            }).ToList();

            var cursoModel = new CursoModel
            {
                ListaCarrera = DropDownCarrera
            };
            return View(cursoModel);
        }

        // POST: Curso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Nombre,Descripcion,IdCarrera,Precio")] CursoModel cursoModel)
        {
            ModelState.Remove("NombreCarrera");
            ModelState.Remove("ListaCarrera");
            if (ModelState.IsValid)
            {
                var curso = new Curso
                {
                    Codigo = cursoModel.Codigo,
                    Nombre = cursoModel.Nombre!,
                    Descripcion = cursoModel.Descripcion,
                    IdCarrera = cursoModel.IdCarrera,
                    Precio = cursoModel.Precio
                };
                if (curso.Descripcion == null)
                {
                    curso.Descripcion = "";
                }
                _context.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cursoModel);
        }

        // GET: Curso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos.FindAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            List<SelectListItem> DropDownCarrera = _context.Carreras.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nombre
            }).ToList();

            var cursoModel = new CursoModel
            {
                Id = curso.Id,
                Codigo = curso.Codigo,
                Nombre = curso.Nombre,
                Descripcion = curso.Descripcion!,
                IdCarrera = curso.IdCarrera,
                Precio = curso.Precio,
                ListaCarrera = DropDownCarrera
            };

            if (cursoModel.Descripcion == null)
            {
                cursoModel.Descripcion = "";
            }
            return View(cursoModel);
        }

        // POST: Curso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Nombre,Descripcion,IdCarrera,Precio")] CursoModel cursoModel)
        {
            if (id != cursoModel.Id)
            {
                return NotFound();
            }

            ModelState.Remove("NombreCarrera");
            ModelState.Remove("ListaCarrera");

            if (ModelState.IsValid)
            {
                var curso = new Curso
                {
                    Id = cursoModel.Id,
                    Codigo = cursoModel.Codigo,
                    Nombre = cursoModel.Nombre!,
                    Descripcion = cursoModel.Descripcion,
                    IdCarrera = cursoModel.IdCarrera,
                    Precio = cursoModel.Precio
                };
                if (curso.Descripcion == null)
                {
                    curso.Descripcion = "";
                }
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoModelExists(cursoModel.Id))
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
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var cursoModel = await _context.Cursos.Select(x => new CursoModel
            {
                Id = x.Id,
                Codigo = x.Codigo,
                Nombre = x.Nombre!,
                Descripcion = x.Descripcion!,
                IdCarrera = x.IdCarrera,
                Precio = x.Precio
            }).FirstOrDefaultAsync(m => m.Id == id);
            if (cursoModel == null)
            {
                return NotFound();
            }
            if (cursoModel.Descripcion == null)
            {
                cursoModel.Descripcion = "";
            }

            return View(cursoModel);
        }

        // POST: Curso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cursos == null)
            {
                return Problem("Entity set 'UniversidadContext.Curso'  is null.");
            }
            var curso = await _context.Cursos.FindAsync(id);
            if (curso != null)
            {
                _context.Cursos.Remove(curso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoModelExists(int id)
        {
          return (_context.Cursos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
