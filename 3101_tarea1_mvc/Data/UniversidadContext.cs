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

                entity.HasIndex(e => e.Codigo, "UQ__carrera__40F9A2065EB0CC33")
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__carrera__idEscue__5629CD9C");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.ToTable("curso");

                entity.HasIndex(e => e.Codigo, "UQ__curso__40F9A2069B023ABE")
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__curso__idCarrera__59FA5E80");
            });

            modelBuilder.Entity<Escuela>(entity =>
            {
                entity.ToTable("escuela");

                entity.HasIndex(e => e.Codigo, "UQ__escuela__40F9A20664C56C43")
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

                entity.HasIndex(e => e.Identificacion, "UQ__estudian__C196DEC7122B3D51")
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__matricula__idEst__5CD6CB2B");
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__matricula__idCur__60A75C0F");

                entity.HasOne(d => d.IdMatriculaNavigation)
                    .WithMany(p => p.MatriculaDetalles)
                    .HasForeignKey(d => d.IdMatricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__matricula__idMat__5FB337D6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
