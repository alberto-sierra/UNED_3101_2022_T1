using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace _3101_tarea1_mvc.Models
{
    public class EscuelaModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(5, MinimumLength = 2)]
        [Required]
        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } 
    }
}

