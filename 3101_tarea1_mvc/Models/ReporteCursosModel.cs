using System;
using System.ComponentModel.DataAnnotations;

namespace _3101_tarea1_mvc.Models
{
    public class ReporteCursosModel
    {
        [Display(Name = "Codigo")]
        public string Codigo { get; set; }

        [Display(Name = "Curso")]
        public string NombreCurso { get; set; }

        [Display(Name = "Estudiante")]
        public string NombreCompleto { get; set; }
    }
}

