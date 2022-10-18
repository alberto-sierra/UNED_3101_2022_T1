using System;
using System.ComponentModel.DataAnnotations;

namespace _3101_tarea1_mvc.Models
{
    public class Estudiante
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        [DataType(DataType.Date)]
        public DateTime fechaNacimiento { get; set; }
        [DataType(DataType.Date)]
        public DateTime fechaIngreso { get; set; }
    }
}

