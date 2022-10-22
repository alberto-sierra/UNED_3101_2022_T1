using System;
using System.Collections.Generic;

namespace _3101_tarea1_mvc.Entities
{
    public partial class MatriculaDetalle
    {
        public int Id { get; set; }
        public int? IdMatricula { get; set; }
        public int? IdCurso { get; set; }

        public virtual Curso? IdCursoNavigation { get; set; }
        public virtual Matricula? IdMatriculaNavigation { get; set; }
    }
}
