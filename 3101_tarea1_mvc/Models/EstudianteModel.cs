using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3101_tarea1_mvc.Models
{
    public class EstudianteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [RegularExpression(@"[0-9]{9}$")]
        [StringLength(9)]
        [Required]
        [Display(Name = "Cédula")]
        public string identificacion { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(50, MinimumLength = 2)]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Primer Apellido")]
        [StringLength(50, MinimumLength = 2)]
        public string primerApellido { get; set; }

        [Required]
        [Display(Name = "Segundo Apellido")]
        [StringLength(50, MinimumLength = 2)]
        public string segundoApellido { get; set; }

        [Required]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime fechaNacimiento { get; set; }

        [Required]
        [Display(Name = "Fecha de Ingreso")]
        [DataType(DataType.Date)]
        public DateTime? fechaIngreso { get; set; }
    }
}