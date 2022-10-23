using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _3101_tarea1_mvc.Models
{
    public class CursoModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [RegularExpression(@"[0-9]{5}$")]
        [Required]
        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Carrera")]
        public int IdCarrera { get; set; }

        [Display(Name = "Carrera")]
        public string NombreCarrera { get; set; }

        [Required]
        [Display(Name = "Precio")]
        [Column(TypeName = "money")]
        public decimal Precio { get; set; }

        [NotMapped]
        public List<SelectListItem> ListaCarrera { get; set; }
    }
}

