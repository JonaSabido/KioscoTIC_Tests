using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace ProyectoAplicacionesWeb.Models
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            AlumnosProyectos = new HashSet<AlumnosProyecto>();
        }

        public int IdProyecto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public string Video { get; set; }
        public bool? Estatus { get; set; }
        
        public int ClaveDivisionProyectos { get; set; }
        
        public int ClaveCarreraProyectos { get; set; }
        
        public int ClaveGradoProyectos { get; set; }
        
        public string ClaveGrupoProyectos { get; set; }

        [Display(Name = "Division")]
        public virtual Carrera ClaveCarreraProyectosNavigation { get; set; }
        [Display(Name = "Carrera")]
        public virtual Divisione ClaveDivisionProyectosNavigation { get; set; }
        [Display(Name = "Grado")]
        public virtual Grado ClaveGradoProyectosNavigation { get; set; }
        [Display(Name = "Grupo")]
        public virtual Grupo ClaveGrupoProyectosNavigation { get; set; }
        [Display(Name = "Imagen")]
        public virtual ICollection<AlumnosProyecto> AlumnosProyectos { get; set; }
    }
}
