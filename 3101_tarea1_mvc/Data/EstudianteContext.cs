using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _3101_tarea1_mvc.Models;

    public class EstudianteContext : DbContext
    {
        public EstudianteContext (DbContextOptions<EstudianteContext> options)
            : base(options)
        {
        }

        public DbSet<_3101_tarea1_mvc.Models.Estudiante> Estudiante { get; set; } = default!;

        public DbSet<_3101_tarea1_mvc.Models.Curso>? Curso { get; set; }

        public DbSet<_3101_tarea1_mvc.Models.Matricula>? Matricula { get; set; }
    }
