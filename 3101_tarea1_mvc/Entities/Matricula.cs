using System;
using System.Collections.Generic;

namespace _3101_tarea1_mvc.Entities
{
    public partial class Matricula
    {
        public Matricula()
        {
            MatriculaDetalles = new HashSet<MatriculaDetalle>();
        }

        public int Id { get; set; }
        public long? IdEstudiante { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Estudiante? IdEstudianteNavigation { get; set; }
        public virtual ICollection<MatriculaDetalle> MatriculaDetalles { get; set; }
    }
}
