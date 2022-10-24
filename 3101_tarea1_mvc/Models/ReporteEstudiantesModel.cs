using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3101_tarea1_mvc.Models
{
    public class ReporteEstudiantesModel
    {
        [NotMapped]
        public IList<string> ReporteData { get; set; }
    }
}