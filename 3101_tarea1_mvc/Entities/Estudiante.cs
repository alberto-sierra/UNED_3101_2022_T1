using System;
using System.Collections.Generic;

namespace _3101_tarea1_mvc.Entities
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Matriculas = new HashSet<Matricula>();
        }

        public long Id { get; set; }
        public string Identificacion { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string PrimerApellido { get; set; } = null!;
        public string SegundoApellido { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }

        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
