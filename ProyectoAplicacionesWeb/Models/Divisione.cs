using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProyectoAplicacionesWeb.Models
{
    public partial class Divisione
    {
        public Divisione()
        {
            Alumnos = new HashSet<Alumno>();
            Carreras = new HashSet<Carrera>();
            Profesores = new HashSet<Profesore>();
            Proyectos = new HashSet<Proyecto>();
        }

        public int CodigoDivisiones { get; set; }
        [Display (Name ="Division")]
        public string NombreDivision { get; set; }
        [Display(Name = "Descripción")]
        public string DescripcionDivision { get; set; }

        public virtual ICollection<Alumno> Alumnos { get; set; }
        public virtual ICollection<Carrera> Carreras { get; set; }
        public virtual ICollection<Profesore> Profesores { get; set; }
        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
