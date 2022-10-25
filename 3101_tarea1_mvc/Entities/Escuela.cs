using System;
using System.Collections.Generic;

namespace _3101_tarea1_mvc.Entities
{
    public partial class Escuela
    {
        public Escuela()
        {
            Carreras = new HashSet<Carrera>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Carrera> Carreras { get; set; }
    }
}
