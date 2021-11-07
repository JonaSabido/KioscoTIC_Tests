using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoAplicacionesWeb.Models
{
    public partial class AlumnosProyecto
    {
        public int IdAlumnosProyecto { get; set; }
        public string MatriculaAlumnoProyecto { get; set; }
        public int IdProyectoProyecto { get; set; }

        public virtual Proyecto IdProyectoProyectoNavigation { get; set; }
        public virtual Alumno MatriculaAlumnoProyectoNavigation { get; set; }
    }
}
