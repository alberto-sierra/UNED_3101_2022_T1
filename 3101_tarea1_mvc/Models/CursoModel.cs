using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace _3101_tarea1_mvc.Models
{
    public class CursoModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [Required]
        [Display(Name = "Precio")]
        [Column(TypeName = "money")]
        public double precio { get; set; }
    }
}

