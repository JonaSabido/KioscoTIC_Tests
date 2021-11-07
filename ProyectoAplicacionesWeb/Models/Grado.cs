using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProyectoAplicacionesWeb.Models
{
    public partial class Grado
    {
        public Grado()
        {
            Alumnos = new HashSet<Alumno>();
            Proyectos = new HashSet<Proyecto>();
        }
        [Display(Name = "Grado")]
        public int Grado1 { get; set; }
        public string Ciclo { get; set; }

        public virtual ICollection<Alumno> Alumnos { get; set; }
        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
