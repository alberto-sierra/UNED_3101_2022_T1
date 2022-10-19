using System;
using System.ComponentModel.DataAnnotations;

namespace _3101_tarea1_mvc.Models
{
    public class Estudiante
    {
        [RegularExpression(@"[0-9]{9}$")]
        [Required]
        [Display(Name = "Cédula")]
        public string id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Primer Apellido")]
        public string primerApellido { get; set; }

        [Required]
        [Display(Name = "Segundo Apellido")]
        public string segundoApellido { get; set; }

        [Required]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime fechaNacimiento { get; set; }

        [Required]
        [Display(Name = "Fecha de Ingreso")]
        [DataType(DataType.Date)]
        public DateTime fechaIngreso { get; set; }
    }
}

