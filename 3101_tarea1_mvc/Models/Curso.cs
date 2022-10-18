using System;
namespace _3101_tarea1_mvc.Models
{
    public class Curso
    {
        public Curso()
        {
        }

        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string carrera { get; set; }
        public int estado { get; set; }
        public double precio { get; set; }
    }
}

