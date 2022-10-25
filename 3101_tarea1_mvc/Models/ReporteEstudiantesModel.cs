using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _3101_tarea1_mvc.Models
{
    public class ReporteEstudiantesModel
    {
        [Display(Name = "Curso")]
        public int Id { get; set; }

        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [Display(Name = "Curso")]
        public string NombreCurso { get; set; }

        [Display(Name = "Estudiante")]
        public string NombreCompleto { get; set; }

        [NotMapped]
        public List<SelectListItem> ListaCurso { get; set; }
    }
}