using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoAplicacionesWeb.Models;
using System.IO;

namespace ProyectoAplicacionesWeb.Controllers
{
    public class ProyectoesController : Controller
    {
        private readonly Kiosco_UTM_FINALContext _context;

        public ProyectoesController(Kiosco_UTM_FINALContext context)
        {
            _context = context;
        }

        // GET: Proyectoes
        public async Task<IActionResult> Index()
        {
            var kiosco_UTM_FINALContext = _context.Proyectos.Include(p => p.ClaveCarreraProyectosNavigation).Include(p => p.ClaveDivisionProyectosNavigation).Include(p => p.ClaveGradoProyectosNavigation).Include(p => p.ClaveGrupoProyectosNavigation);
            return View(await kiosco_UTM_FINALContext.ToListAsync());
        }

        // GET: Proyectoes/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Proyectoes/Create
        public IActionResult Create()
        {
            ViewData["ClaveCarreraProyectos"] = new SelectList(_context.Carreras, "CodigoCarrera", "NombreCarrera");
            ViewData["ClaveDivisionProyectos"] = new SelectList(_context.Divisiones, "CodigoDivisiones", "DescripcionDivision");
            ViewData["ClaveGradoProyectos"] = new SelectList(_context.Grados, "Grado1", "Grado1");
            ViewData["ClaveGrupoProyectos"] = new SelectList(_context.Grupos, "Grupo1", "Grupo1");
            return View();
        }

        // POST: Proyectoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile archivo,  Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                if (archivo != null)
                {
                    proyecto.Imagen = SubirImagen("imagenes", archivo);


                    _context.Add(proyecto);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    proyecto.Imagen = "stock.jpg";
                    _context.Add(proyecto);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            
            ViewData["ClaveCarreraProyectos"] = new SelectList(_context.Carreras, "CodigoCarrera", "NombreCarrera", proyecto.ClaveCarreraProyectos);
            ViewData["ClaveDivisionProyectos"] = new SelectList(_context.Divisiones, "CodigoDivisiones", "DescripcionDivision", proyecto.ClaveDivisionProyectos);
            ViewData["ClaveGradoProyectos"] = new SelectList(_context.Grados, "Grado1", "Grado1", proyecto.ClaveGradoProyectos);
            ViewData["ClaveGrupoProyectos"] = new SelectList(_context.Grupos, "Grupo1", "Grupo1", proyecto.ClaveGrupoProyectos);
            return View(proyecto);
        }

        private string SubirImagen(string rutacarpeta, IFormFile ArchivoSubir)
        {
            
                string carpeta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", rutacarpeta);
                string Nombrearchivo = Guid.NewGuid().ToString() + "_" + ArchivoSubir.FileName;
                string RutaarchivoUnico = Path.Combine(carpeta, Nombrearchivo);
                using (var InfoArchivo = new FileStream(RutaarchivoUnico, FileMode.Create))
                    ArchivoSubir.CopyTo(InfoArchivo);
                return Nombrearchivo;
            
            
           
        }
        // GET: Proyectoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto == null)
            {
                return NotFound();
            }
            ViewData["ClaveCarreraProyectos"] = new SelectList(_context.Carreras, "CodigoCarrera", "NombreCarrera", proyecto.ClaveCarreraProyectos);
            ViewData["ClaveDivisionProyectos"] = new SelectList(_context.Divisiones, "CodigoDivisiones", "DescripcionDivision", proyecto.ClaveDivisionProyectos);
            ViewData["ClaveGradoProyectos"] = new SelectList(_context.Grados, "Grado1", "Grado1", proyecto.ClaveGradoProyectos);
            ViewData["ClaveGrupoProyectos"] = new SelectList(_context.Grupos, "Grupo1", "Grupo1", proyecto.ClaveGrupoProyectos);
            return View(proyecto);
        }

        // POST: Proyectoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormFile archivo, Proyecto proyecto)
        {
            if (id != proyecto.IdProyecto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (archivo != null)
                    {
                        proyecto.Imagen = SubirImagen("imagenes", archivo);
                        _context.Update(proyecto);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        proyecto.Imagen = "stock.jpg";
                        _context.Update(proyecto);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                   

                    if (!ProyectoExists(proyecto.IdProyecto))
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
            ViewData["ClaveCarreraProyectos"] = new SelectList(_context.Carreras, "CodigoCarrera", "NombreCarrera", proyecto.ClaveCarreraProyectos);
            ViewData["ClaveDivisionProyectos"] = new SelectList(_context.Divisiones, "CodigoDivisiones", "DescripcionDivision", proyecto.ClaveDivisionProyectos);
            ViewData["ClaveGradoProyectos"] = new SelectList(_context.Grados, "Grado1", "Grado1", proyecto.ClaveGradoProyectos);
            ViewData["ClaveGrupoProyectos"] = new SelectList(_context.Grupos, "Grupo1", "Grupo1", proyecto.ClaveGrupoProyectos);
            return View(proyecto);
        }

        // GET: Proyectoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Proyectoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);
            _context.Proyectos.Remove(proyecto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProyectoExists(int id)
        {
            return _context.Proyectos.Any(e => e.IdProyecto == id);
        }
    }
}
