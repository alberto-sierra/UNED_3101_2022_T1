using System;
using System.Collections.Generic;

namespace _3101_tarea1_mvc.Entities
{
    public partial class Carrera
    {
        public Carrera()
        {
            Cursos = new HashSet<Curso>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public int IdEscuela { get; set; }
        public string Nombre { get; set; }

        public virtual Escuela? IdEscuelaNavigation { get; set; }
        public virtual ICollection<Curso>? Cursos { get; set; }
    }
}
