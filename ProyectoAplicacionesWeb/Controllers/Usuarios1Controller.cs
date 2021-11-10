using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoAplicacionesWeb.Models;

namespace ProyectoAplicacionesWeb.Controllers
{
    public class Usuarios1Controller : Controller
    {
        private readonly Kiosco_UTM_FINALContext _context;

        public Usuarios1Controller(Kiosco_UTM_FINALContext context)
        {
            _context = context;
        }

        // GET: Usuarios1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuarios1/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Correo == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Correo,Nombre,ApellidoP,ApellidoM,Estatus,Contraseña")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (FindCorreoValido(usuario.Correo))
                {
                    _context.Add(usuario);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(usuario);
        }
        public bool FindCorreoValido(string Correo)
        {
            bool banderaarroba = false;
            bool banderatexto = false;

            if (Correo != null)
            {
                char[] arreglo = Correo.ToCharArray();
                for (int i = 0; i < Correo.Length; i++)
                {
                    if (banderaarroba == false)
                    {
                        if (arreglo[i] == '@')
                        {
                            banderaarroba = true;
                        }
                    }
                    else
                    {
                        banderatexto = true;
                    }
                }

                if (banderaarroba == true && banderatexto == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // GET: Usuarios1/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Correo,Nombre,ApellidoP,ApellidoM,Estatus,Contraseña")] Usuario usuario)
        {
            if (id != usuario.Correo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Correo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios1/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Correo == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(string id)
        {
            return _context.Usuarios.Any(e => e.Correo == id);
        }
    }
}
