using System;
using System.Collections.Generic;

namespace _3101_tarea1_mvc.Entities
{
    public partial class Curso
    {
        public Curso()
        {
            MatriculaDetalles = new HashSet<MatriculaDetalle>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int? IdCarrera { get; set; }
        public decimal Precio { get; set; }

        public virtual Carrera? IdCarreraNavigation { get; set; }
        public virtual ICollection<MatriculaDetalle> MatriculaDetalles { get; set; }
    }
}
