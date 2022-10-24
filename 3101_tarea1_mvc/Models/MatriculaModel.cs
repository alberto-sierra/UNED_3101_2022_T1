using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using _3101_tarea1_mvc.Entities;

namespace _3101_tarea1_mvc.Models
{
    public class MatriculaModel
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Identificación del Estudiante")]
        public long IdEstudiante { get; set; }

        [Required]
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Display(Name = "Nombre del Estudiante")]
        public string NombreEstudiante { get; set; }

        [Display(Name = "Identificación del Estudiante")]
        public string IdEstudianteValue { get; set; }

        [Display(Name = "Total")]
        [Column(TypeName = "money")]
        public decimal Total { get; set; }

        public Estudiante? IdEstudianteNavigation { get; set; }
        public ICollection<MatriculaDetalle>? MatriculaDetalles { get; set; }

    }
}

