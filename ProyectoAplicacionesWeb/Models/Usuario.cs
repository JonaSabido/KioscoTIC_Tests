using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoAplicacionesWeb.Models
{
    public partial class Usuario
    {
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public bool? Estatus { get; set; }
        public string Contraseña { get; set; }
    }
}
