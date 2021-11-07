using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProyectoAplicacionesWeb.Models;

#nullable disable

namespace ProyectoAplicacionesWeb.Models
{
    public partial class Kiosco_UTM_FINALContext : DbContext
    {
        public Kiosco_UTM_FINALContext()
        {
        }

        public Kiosco_UTM_FINALContext(DbContextOptions<Kiosco_UTM_FINALContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; }
        public virtual DbSet<AlumnosProyecto> AlumnosProyectos { get; set; }
        public virtual DbSet<Carrera> Carreras { get; set; }
        public virtual DbSet<Divisione> Divisiones { get; set; }
        public virtual DbSet<Grado> Grados { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<Profesore> Profesores { get; set; }
        public virtual DbSet<Proyecto> Proyectos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-7V5NLUB; Initial Catalog=Kiosco_UTM_FINAL; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.MatriculaAlumno)
                    .HasName("pk_Matricula_Alumno");

                entity.Property(e => e.MatriculaAlumno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Matricula_Alumno");

                entity.Property(e => e.ApellidoM)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoP)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ClaveCarreraAlumno).HasColumnName("Clave_Carrera_Alumno");

                entity.Property(e => e.ClaveDivisionAlumno).HasColumnName("Clave_Division_Alumno");

                entity.Property(e => e.ClaveGradoAlumnos).HasColumnName("clave_Grado_Alumnos");

                entity.Property(e => e.ClaveGrupoAlumnos)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("clave_Grupo_Alumnos");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClaveCarreraAlumnoNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.ClaveCarreraAlumno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Clave_Carrera_Alumno");

                entity.HasOne(d => d.ClaveDivisionAlumnoNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.ClaveDivisionAlumno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Clave_Division_Alumno");

                entity.HasOne(d => d.ClaveGradoAlumnosNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.ClaveGradoAlumnos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clave_Grado_Alumnos");

                entity.HasOne(d => d.ClaveGrupoAlumnosNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.ClaveGrupoAlumnos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clave_Grupo_Alumnos");
            });

            modelBuilder.Entity<AlumnosProyecto>(entity =>
            {
                entity.HasKey(e => e.IdAlumnosProyecto)
                    .HasName("PK_id_equipos_proyecto");

                entity.ToTable("Alumnos_Proyecto");

                entity.Property(e => e.IdAlumnosProyecto).HasColumnName("id_Alumnos_Proyecto");

                entity.Property(e => e.IdProyectoProyecto).HasColumnName("Id_Proyecto_Proyecto");

                entity.Property(e => e.MatriculaAlumnoProyecto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Matricula_Alumno_Proyecto");

                entity.HasOne(d => d.IdProyectoProyectoNavigation)
                    .WithMany(p => p.AlumnosProyectos)
                    .HasForeignKey(d => d.IdProyectoProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Id_Proyecto_Proyecto");

                entity.HasOne(d => d.MatriculaAlumnoProyectoNavigation)
                    .WithMany(p => p.AlumnosProyectos)
                    .HasForeignKey(d => d.MatriculaAlumnoProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matricula_Alumno_Proyecto");
            });

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.CodigoCarrera)
                    .HasName("pk_id_Carrera");

                entity.Property(e => e.CodigoCarrera).HasColumnName("Codigo_Carrera");

                entity.Property(e => e.ClaveDivision).HasColumnName("Clave_division");

                entity.Property(e => e.NombreCarrera)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Carrera");

                entity.HasOne(d => d.ClaveDivisionNavigation)
                    .WithMany(p => p.Carreras)
                    .HasForeignKey(d => d.ClaveDivision)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Clave_division");
            });

            modelBuilder.Entity<Divisione>(entity =>
            {
                entity.HasKey(e => e.CodigoDivisiones)
                    .HasName("pk_id_divisiones");

                entity.Property(e => e.CodigoDivisiones).HasColumnName("Codigo_Divisiones");

                entity.Property(e => e.DescripcionDivision)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Descripcion_division");

                entity.Property(e => e.NombreDivision)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Division");
            });

            modelBuilder.Entity<Grado>(entity =>
            {
                entity.HasKey(e => e.Grado1)
                    .HasName("pk_grado");

                entity.ToTable("Grado");

                entity.Property(e => e.Grado1)
                    .ValueGeneratedNever()
                    .HasColumnName("Grado");

                entity.Property(e => e.Ciclo)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(e => e.Grupo1)
                    .HasName("pk_Grupo");

                entity.ToTable("Grupo");

                entity.Property(e => e.Grupo1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Grupo");
            });

            modelBuilder.Entity<Profesore>(entity =>
            {
                entity.HasKey(e => e.MatriculaMaestros)
                    .HasName("pk_id_Profesores");

                entity.Property(e => e.MatriculaMaestros)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Matricula_Maestros");

                entity.Property(e => e.ApellidoM)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoP)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ClaveDivisionMaestros).HasColumnName("clave_division_maestros");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClaveDivisionMaestrosNavigation)
                    .WithMany(p => p.Profesores)
                    .HasForeignKey(d => d.ClaveDivisionMaestros)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clave_division_maestros");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.HasKey(e => e.IdProyecto)
                    .HasName("pk_Id_Proyecto");

                entity.Property(e => e.IdProyecto).HasColumnName("Id_Proyecto");

                entity.Property(e => e.ClaveCarreraProyectos).HasColumnName("Clave_Carrera_Proyectos");

                entity.Property(e => e.ClaveDivisionProyectos).HasColumnName("Clave_Division_Proyectos");

                entity.Property(e => e.ClaveGradoProyectos).HasColumnName("Clave_Grado_Proyectos");

                entity.Property(e => e.ClaveGrupoProyectos)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Clave_Grupo_Proyectos");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("imagen");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Video)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.ClaveCarreraProyectosNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.ClaveCarreraProyectos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clave_Carrera_Proyectos");

                entity.HasOne(d => d.ClaveDivisionProyectosNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.ClaveDivisionProyectos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clave_Division_Proyectos");

                entity.HasOne(d => d.ClaveGradoProyectosNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.ClaveGradoProyectos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clave_Grado_Proyectos");

                entity.HasOne(d => d.ClaveGrupoProyectosNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.ClaveGrupoProyectos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clave_Grupo_Proyectos");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Correo)
                    .HasName("pk_correo_Usuario");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoM)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoP)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
