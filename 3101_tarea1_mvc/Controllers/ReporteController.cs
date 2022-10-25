using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3101_tarea1_mvc.Data;
using _3101_tarea1_mvc.Entities;
using _3101_tarea1_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _3101_tarea1_mvc.Controllers
{
    public class ReporteController : Controller
    {
        private readonly UniversidadContext _context;

        public ReporteController(UniversidadContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var matriculaDetalleModel = await _context.MatriculaDetalles
                .Include(x => x.IdCursoNavigation)
                .Select(x => new MatriculaDetalle
                {
                    Id = x.Id,
                    IdCurso = (int)x.IdCurso,
                    IdMatricula = (int)x.IdMatricula,
                    IdCursoNavigation = x.IdCursoNavigation
                })
                .ToListAsync();

            if (matriculaDetalleModel == null)
            {
                return NotFound();
            }

            decimal totalIngreso = 0;
            foreach (var item in matriculaDetalleModel)
            {
                totalIngreso += item.IdCursoNavigation.Precio;
            }

            var control = new List<decimal>();
            foreach (var item in matriculaDetalleModel)
            {
                if (!control.Contains(item.IdCurso))
                {
                    control.Add(item.IdCurso);
                };
            }

            decimal pctCursos = _context.Cursos
                .Count();


            var reporteModel = new ReporteModel
            {
                Ingreso = totalIngreso,
                CursosMatriculados = control.Count,
                PctCursosMatriculados = control.Count / pctCursos
            };

            decimal pct = control.Count/pctCursos;

            return View(reporteModel);
        }

        // GET: ReporteEstudiantes
        public async Task<IActionResult> ReporteEstudiantes()
        {

            List<SelectListItem> dropDownCurso = await _context.Cursos.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nombre
            }).ToListAsync();

            var reporteModel = new ReporteEstudiantesModel
            {
                ListaCurso = dropDownCurso
            };

            if (reporteModel == null)
            {
                return NotFound();
            }

            return View(reporteModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReporteEstudiantesResult(int? Id)
        {
            if (Id == null)
            {
                ViewBag.mensaje = "Curso no encontrado.";
                return View();
            }

            var reporteModel = await _context.MatriculaDetalles
               .Include(x => x.IdMatriculaNavigation)
               .Include(x => x.IdMatriculaNavigation.IdEstudianteNavigation)
               .Include(x => x.IdCursoNavigation)
               .Where(x => x.IdCursoNavigation.Id == Id)
               .Select(x => new ReporteEstudiantesModel
               {
                   NombreCompleto = $"{x.IdMatriculaNavigation.IdEstudianteNavigation.Nombre} {x.IdMatriculaNavigation.IdEstudianteNavigation.PrimerApellido} {x.IdMatriculaNavigation.IdEstudianteNavigation.SegundoApellido}",
                   Codigo = x.IdCursoNavigation.Codigo,
                   NombreCurso = x.IdCursoNavigation.Nombre
               })
               .ToListAsync();

            if (reporteModel == null)
            {
                return NotFound();
            }

            return View(reporteModel);

        }

        // GET: ReporteCursos
        public async Task<IActionResult> ReporteCursos()
        {
            var reporteModel = await _context.MatriculaDetalles
               .Include(x => x.IdMatriculaNavigation)
               .Include(x => x.IdMatriculaNavigation.IdEstudianteNavigation)
               .Include(x => x.IdCursoNavigation)
               .Select(x => new ReporteCursosModel
               {
                   NombreCompleto = $"{x.IdMatriculaNavigation.IdEstudianteNavigation.Nombre} {x.IdMatriculaNavigation.IdEstudianteNavigation.PrimerApellido} {x.IdMatriculaNavigation.IdEstudianteNavigation.SegundoApellido}",
                   NombreCurso = x.IdCursoNavigation.Nombre
               })
               .ToListAsync();

            if (reporteModel == null)
            {
                return NotFound();
            }

            return View(reporteModel);

        }

        // GET: TotalIngresos
        public async Task<IActionResult> TotalIngresos()
        {
            var reporteModel = await _context.MatriculaDetalles
               .Include(x => x.IdMatriculaNavigation)
               .Include(x => x.IdMatriculaNavigation.IdEstudianteNavigation)
               .Include(x => x.IdCursoNavigation)
               .Select(x => new ReporteCursosModel
               {
                   NombreCompleto = $"{x.IdMatriculaNavigation.IdEstudianteNavigation.Nombre} {x.IdMatriculaNavigation.IdEstudianteNavigation.PrimerApellido} {x.IdMatriculaNavigation.IdEstudianteNavigation.SegundoApellido}",
                   NombreCurso = x.IdCursoNavigation.Nombre
               })
               .ToListAsync();

            if (reporteModel == null)
            {
                return NotFound();
            }

            return View(reporteModel);

        }
    }
}