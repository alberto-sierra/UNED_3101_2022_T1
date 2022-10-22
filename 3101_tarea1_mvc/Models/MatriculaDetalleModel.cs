using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace _3101_tarea1_mvc.Models
{
    public class MatriculaDetalleModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [ForeignKey("matricula")]
        public int idMatricula { get; set; }

        [ForeignKey("curso")]
        public int idCurso { get; set; }
    }
}

