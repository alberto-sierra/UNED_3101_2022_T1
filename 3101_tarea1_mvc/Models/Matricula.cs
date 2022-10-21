using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace _3101_tarea1_mvc.Models
{
    public class Matricula
    {
        public Matricula()
        {
        }

        public int id { get; set; }

        [RegularExpression(@"[0-9]{9}$")]
        [Required]
        [Display(Name = "Cédula")]
        public string idEstudiante { get; set; }

        [Required]
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public DateTime fecha { get; set; }

        [RegularExpression(@"[0-9]{4}-0[1-6]{1}$")]
        [Required]
        [Display(Name = "Periodo")]
        public string periodo { get; set; }

        [ForeignKey("estado_descripcion")]
        [Display(Name = "Estado")]
        [Column(TypeName = "tinyint")]
        public byte estado { get; set; }

        [Required]
        [Display(Name = "Total")]
        [Column(TypeName = "money")]
        public double total { get; set; }

    }
}

