using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProyectoAplicacionesWeb.Models
{
    public partial class Profesore
    {
        public string MatriculaMaestros { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public bool? Estatus { get; set; }
        [Display(Name = "Division")]
        public int ClaveDivisionMaestros { get; set; }
        [Display(Name = "Division")]
        public virtual Divisione ClaveDivisionMaestrosNavigation { get; set; }
    }
}
