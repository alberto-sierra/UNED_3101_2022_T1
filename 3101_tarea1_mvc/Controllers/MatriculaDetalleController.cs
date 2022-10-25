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
    public class MatriculaDetalleController : Controller
    {
        private readonly UniversidadContext _context;

        public MatriculaDetalleController(UniversidadContext context)
        {
            _context = context;
        }

        // GET: MatriculaDetalle/Create/5
        public IActionResult Create(int id)
        {
            var matriculaDetalleModel = new MatriculaDetalleModel
            {
                IdMatricula = id
            };
            return View(matriculaDetalleModel);
        }

        // POST: MatriculaDetalle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int idMatricula, string CodigoCurso)
        {

                var curso = _context.Cursos
                    .Where(x => x.Codigo == CodigoCurso)
                    .FirstOrDefault();

                var matricula = _context.Matriculas
                    .Where(x => x.Id == idMatricula)
                    .FirstOrDefault();

                if (curso == null)
                {
                    ViewBag.mensaje = "Curso no encontrado.";
                    return View();
                }

                var matriculaDetalle = new MatriculaDetalle
                {
                    IdCurso = curso.Id,
                    IdMatricula = idMatricula
                };

                _context.Add(matriculaDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index),"Matricula");
                return View();
        }

    }
}
