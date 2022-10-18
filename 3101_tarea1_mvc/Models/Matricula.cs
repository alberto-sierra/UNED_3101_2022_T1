using System;
namespace _3101_tarea1_mvc.Models
{
    public class Matricula
    {
        public Matricula()
        {
        }

        public int id { get; set; }
        public string idEstudiante { get; set; }
        public DateTime fecha { get; set; }
        public string periodo { get; set; }
        public int estado { get; set; }
        public double total { get; set; }

    }
}

