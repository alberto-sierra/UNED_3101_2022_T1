using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3101_tarea1_mvc.Models
{
    public class EstudianteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [RegularExpression(@"[0-9]{9}$")]
        [StringLength(9)]
        [Required]
        [Display(Name = "Identificación")]
        public string Identificacion { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(50, MinimumLength = 2)]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Primer Apellido")]
        [StringLength(50, MinimumLength = 2)]
        public string PrimerApellido { get; set; }

        [Required]
        [Display(Name = "Segundo Apellido")]
        [StringLength(50, MinimumLength = 2)]
        public string SegundoApellido { get; set; }

        [Required]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [Display(Name = "Fecha de Ingreso")]
        [DataType(DataType.Date)]
        public DateTime? FechaIngreso { get; set; }
    }
}