using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace _3101_tarea1_mvc.Models
{
    public class ReporteModel
    {
        [Display(Name = "Ingresos")]
        public decimal Ingreso { get; set; }

        [Display(Name = "Cursos matriculados")]
        public int CursosMatriculados { get; set; }

        [Display(Name = "Porcentaje de cursos matriculados")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = true)]
        public decimal PctCursosMatriculados { get; set; }
    }
}

