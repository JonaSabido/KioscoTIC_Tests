using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProyectoAplicacionesWeb.Models
{
    public partial class Carrera
    {
        public Carrera()
        {
            Alumnos = new HashSet<Alumno>();
            Proyectos = new HashSet<Proyecto>();
        }

        public int CodigoCarrera { get; set; }
        [Display(Name = "Carrera")]
        public string NombreCarrera { get; set; }
        [Display(Name = "Division")]
        public int ClaveDivision { get; set; }
        [Display(Name = "Division")]

        public virtual Divisione ClaveDivisionNavigation { get; set; }
        public virtual ICollection<Alumno> Alumnos { get; set; }
        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
