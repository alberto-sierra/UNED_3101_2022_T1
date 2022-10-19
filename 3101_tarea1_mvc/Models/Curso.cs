using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace _3101_tarea1_mvc.Models
{
    public class Curso
    {
        public Curso()
        {
        }

        public int id { get; set; }

        [RegularExpression(@"[0-9]{5}$")]
        [Required]
        [Display(Name = "Código")]
        public string codigo { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [ForeignKey("Carrera.codig")]
        [Required]
        [Display(Name = "Carrera")]
        public string carrera { get; set; }

        [ForeignKey("EstadoDescripcion")]
        [Required]
        [Display(Name = "Estado")]
        public int estado { get; set; }

        [Required]
        [Display(Name = "Precio")]
        [Column(TypeName = "money")]
        public double precio { get; set; }

        public virtual EstadoDescripcion EstadoDescripcion { get; set; }
        public virtual Carrera Carrera { get; set; }
    }
}

