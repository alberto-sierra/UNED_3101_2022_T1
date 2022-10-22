using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using _3101_tarea1_mvc.Entities;
using _3101_tarea1_mvc.Models;

namespace _3101_tarea1_mvc.Data
{
    public partial class UniversidadContext : DbContext
    {
        public UniversidadContext()
        {
        }

        public UniversidadContext(DbContextOptions<UniversidadContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carrera> Carreras { get; set; } = null!;
        public virtual DbSet<Curso> Cursos { get; set; } = null!;
        public virtual DbSet<Escuela> Escuelas { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<Matricula> Matriculas { get; set; } = null!;
        public virtual DbSet<MatriculaDetalle> MatriculaDetalles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.ToTable("carrera");

                entity.HasIndex(e => e.Codigo, "UQ__carrera__40F9A2062ACECE8E")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.IdEscuela).HasColumnName("idEscuela");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdEscuelaNavigation)
                    .WithMany(p => p.Carreras)
                    .HasForeignKey(d => d.IdEscuela)
                    .HasConstraintName("FK__carrera__idEscue__5070F446");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.ToTable("curso");

                entity.HasIndex(e => e.Codigo, "UQ__curso__40F9A20602E4122C")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasColumnType("money")
                    .HasColumnName("precio");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdCarrera)
                    .HasConstraintName("FK__curso__idCarrera__5441852A");
            });

            modelBuilder.Entity<Escuela>(entity =>
            {
                entity.ToTable("escuela");

                entity.HasIndex(e => e.Codigo, "UQ__escuela__40F9A2060E4A132E")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.ToTable("estudiante");

                entity.HasIndex(e => e.Identificacion, "UQ__estudian__C196DEC7C57CE9EE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaIngreso");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaNacimiento");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("identificacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("primerApellido");

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("segundoApellido");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.ToTable("matricula");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdEstudiante).HasColumnName("idEstudiante");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.IdEstudiante)
                    .HasConstraintName("FK__matricula__idEst__571DF1D5");
            });

            modelBuilder.Entity<MatriculaDetalle>(entity =>
            {
                entity.ToTable("matricula_detalle");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdMatricula).HasColumnName("idMatricula");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.MatriculaDetalles)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__matricula__idCur__5AEE82B9");

                entity.HasOne(d => d.IdMatriculaNavigation)
                    .WithMany(p => p.MatriculaDetalles)
                    .HasForeignKey(d => d.IdMatricula)
                    .HasConstraintName("FK__matricula__idMat__59FA5E80");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<_3101_tarea1_mvc.Models.CarreraModel>? CarreraModel { get; set; }

        public DbSet<_3101_tarea1_mvc.Models.EstudianteModel>? EstudianteModel { get; set; }

        public DbSet<_3101_tarea1_mvc.Models.CursoModel>? CursoModel { get; set; }

        public DbSet<_3101_tarea1_mvc.Models.MatriculaModel>? MatriculaModel { get; set; }

        public DbSet<_3101_tarea1_mvc.Models.EscuelaModel>? EscuelaModel { get; set; }
    }
}