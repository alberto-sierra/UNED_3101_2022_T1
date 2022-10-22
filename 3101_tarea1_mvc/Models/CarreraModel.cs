using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using _3101_tarea1_mvc.Entities;

namespace _3101_tarea1_mvc.Models
{
    public class CarreraModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(5)]
        [Required]
        [Display(Name = "Código")]
        public string codigo { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Escuela")]
        public int idEscuela { get; set; }

        public virtual Escuela? IdEscuelaNavigation { get; set; }
    }
}

