using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace _3101_tarea1_mvc.Models
{
    public class EstadoDescripcionModel
    {
        [Key]
        public byte id { get; set; }

        [StringLength(25, MinimumLength = 5)]
        [Required]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }
    }
}

