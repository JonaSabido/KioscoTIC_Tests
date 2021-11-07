using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProyectoAplicacionesWeb.Models
{
    public partial class Alumno
    {
        public Alumno()
        {
            AlumnosProyectos = new HashSet<AlumnosProyecto>();
        }

        public string MatriculaAlumno { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public bool? Estatus { get; set; }

        [Display(Name = "Grado")]
        public int ClaveGradoAlumnos { get; set; }
        [Display(Name = "Grupo")]
        public string ClaveGrupoAlumnos { get; set; }
        [Display(Name = "Division")]
        public int ClaveDivisionAlumno { get; set; }
        [Display(Name = "Carrera")]
        public int ClaveCarreraAlumno { get; set; }
       


        public virtual Carrera ClaveCarreraAlumnoNavigation { get; set; }
        public virtual Divisione ClaveDivisionAlumnoNavigation { get; set; }
        public virtual Grado ClaveGradoAlumnosNavigation { get; set; }
        public virtual Grupo ClaveGrupoAlumnosNavigation { get; set; }
        public virtual ICollection<AlumnosProyecto> AlumnosProyectos { get; set; }
    }
}
