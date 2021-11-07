using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Referencias
using Microsoft.EntityFrameworkCore;
using ProyectoAplicacionesWeb.Models;

namespace ProyectoAplicacionesWeb.Controllers
{
    public class SesionController : Controller
    {
        //Referenciar al contexto

        private readonly Kiosco_UTM_FINALContext _context;

        public SesionController(Kiosco_UTM_FINALContext context)
        {
            _context = context;
        }

        //Acceso al modelo Usuario
        public Usuario Cuenta { set; get; }
        public IActionResult Login()
        {
            return View();
        }




    }
}
