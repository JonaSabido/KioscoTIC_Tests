using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProyectoAplicacionesWeb.Models
{
    public partial class Grupo
    {
        public Grupo()
        {
            Alumnos = new HashSet<Alumno>();
            Proyectos = new HashSet<Proyecto>();
        }
        [Display(Name = "Grupo")]
        public string Grupo1 { get; set; }

        public virtual ICollection<Alumno> Alumnos { get; set; }
        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
