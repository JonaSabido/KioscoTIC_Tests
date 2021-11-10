using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoAplicacionesWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using KioscoTIC.Views.Shared;
using Microsoft.AspNetCore.Http;
using System.IO;


namespace KioscoTIC.Controllers
{
    public class KioscoTIC : Controller
    {
        private readonly Kiosco_UTM_FINALContext _context;

        public KioscoTIC(Kiosco_UTM_FINALContext context)
        {
            _context = context;
        }

      

        public async Task<IActionResult> Index()
        {
            var kiosco_UTM_FINALContext = _context.Proyectos.Include(p => p.ClaveCarreraProyectosNavigation).Include(p => p.ClaveDivisionProyectosNavigation).Include(p => p.ClaveGradoProyectosNavigation).Include(p => p.ClaveGrupoProyectosNavigation);
            return View(await kiosco_UTM_FINALContext.ToListAsync());
        }


        public async Task<IActionResult> Proyectos()
        {
            var kiosco_UTM_FINALContext = _context.Proyectos.Include(p => p.ClaveCarreraProyectosNavigation).Include(p => p.ClaveDivisionProyectosNavigation).Include(p => p.ClaveGradoProyectosNavigation).Include(p => p.ClaveGrupoProyectosNavigation);
            return View(await kiosco_UTM_FINALContext.ToListAsync());
        }
        public async Task<IActionResult> VerProyecto2(int? id)
        {
            var kiosco_UTM_FINALContext = _context.Proyectos.Include(p => p.ClaveCarreraProyectosNavigation).Include(p => p.ClaveDivisionProyectosNavigation).Include(p => p.ClaveGradoProyectosNavigation).Include(p => p.ClaveGrupoProyectosNavigation);
            return View(await kiosco_UTM_FINALContext.ToListAsync());
        }

        public async Task<IActionResult> VerProyecto(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyectos
                .Include(p => p.ClaveCarreraProyectosNavigation)
                .Include(p => p.ClaveDivisionProyectosNavigation)
                .Include(p => p.ClaveGradoProyectosNavigation)
                .Include(p => p.ClaveGrupoProyectosNavigation)
                .FirstOrDefaultAsync(m => m.IdProyecto == id);

            if (proyecto == null)
            {
                return NotFound();
            }

            return View(proyecto);
            
        }
        public IActionResult Divisiones()
        {
            return View();
        }
        public async Task<IActionResult> DivisionTIC()
        {
            var kiosco_UTM_FINALContext = _context.Profesores.Include(p => p.ClaveDivisionMaestrosNavigation);
            return View(await kiosco_UTM_FINALContext.ToListAsync());
            
        }
        public async Task<IActionResult> DivisionIND()
        {
            var kiosco_UTM_FINALContext = _context.Profesores.Include(p => p.ClaveDivisionMaestrosNavigation);
            return View(await kiosco_UTM_FINALContext.ToListAsync());
        }
        public async Task<IActionResult> DivisionMISE()
        {
            var kiosco_UTM_FINALContext = _context.Profesores.Include(p => p.ClaveDivisionMaestrosNavigation);
            return View(await kiosco_UTM_FINALContext.ToListAsync());
        }

        public IActionResult AcercaDe()
        {
            return View();
        }
        public IActionResult Registro()
        {
            return View();
        }
        public IActionResult admin()
        {
            return View();
        }

        public IActionResult prueba()
        {
            return View();
        }

        //Acceso al modelo Usuario
        public Usuario Cuenta { set; get; }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Onpost(string Cor, string Contra)
        {
            //Comprobar cuenta existente
            Cuenta = _context.Usuarios.Where(p => p.Correo == Cor && p.Contraseña == Contra).FirstOrDefault<Usuario>();

            //
            if(Cuenta != null)
            {
                //Se crea sesion y asigna nombre, en este caso correo
                HttpContext.Session.SetString("Sesion1", Cuenta.Correo);
                return RedirectToAction("Index", "Usuarios1");

            }

            
            return RedirectToAction("Login2", "KioscoTIC");
            


        }
        public bool LoginSession(string Cor, string Contra)
        {
            var Cuenta = _context.Usuarios.Where(p => p.Correo == Cor && p.Contraseña == Contra).FirstOrDefault<Usuario>();

            if (Cuenta != null && Cuenta.Estatus == true)
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }

        public ActionResult LogOut()
        {
            
            HttpContext.Session.Remove("Sesion1");
            return RedirectToAction("Login", "KioscoTIC");
        }

        public ActionResult Login2()
        {
            return View();
        }


    }
}
