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
    public class AlumnoesController : Controller
    {
        private readonly Kiosco_UTM_FINALContext _context;

        public AlumnoesController(Kiosco_UTM_FINALContext context)
        {
            _context = context;
        }

        // GET: Alumnoes
        public async Task<IActionResult> Index()
        {
            var kiosco_UTM_FINALContext = _context.Alumnos.Include(a => a.ClaveCarreraAlumnoNavigation).Include(a => a.ClaveDivisionAlumnoNavigation).Include(a => a.ClaveGradoAlumnosNavigation).Include(a => a.ClaveGrupoAlumnosNavigation);
            return View(await kiosco_UTM_FINALContext.ToListAsync());
        }

        // GET: Alumnoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos
                .Include(a => a.ClaveCarreraAlumnoNavigation)
                .Include(a => a.ClaveDivisionAlumnoNavigation)
                .Include(a => a.ClaveGradoAlumnosNavigation)
                .Include(a => a.ClaveGrupoAlumnosNavigation)
                .FirstOrDefaultAsync(m => m.MatriculaAlumno == id);
            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        // GET: Alumnoes/Create
        public IActionResult Create()
        {
            ViewData["ClaveCarreraAlumno"] = new SelectList(_context.Carreras, "CodigoCarrera", "NombreCarrera");
            ViewData["ClaveDivisionAlumno"] = new SelectList(_context.Divisiones, "CodigoDivisiones", "DescripcionDivision");
            ViewData["ClaveGradoAlumnos"] = new SelectList(_context.Grados, "Grado1", "Grado1");
            ViewData["ClaveGrupoAlumnos"] = new SelectList(_context.Grupos, "Grupo1", "Grupo1");
            return View();
        }

        // POST: Alumnoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MatriculaAlumno,Nombre,ApellidoP,ApellidoM,Estatus,ClaveGradoAlumnos,ClaveGrupoAlumnos,ClaveDivisionAlumno,ClaveCarreraAlumno")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClaveCarreraAlumno"] = new SelectList(_context.Carreras, "CodigoCarrera", "NombreCarrera", alumno.ClaveCarreraAlumno);
            ViewData["ClaveDivisionAlumno"] = new SelectList(_context.Divisiones, "CodigoDivisiones", "DescripcionDivision", alumno.ClaveDivisionAlumno);
            ViewData["ClaveGradoAlumnos"] = new SelectList(_context.Grados, "Grado1", "Grado1", alumno.ClaveGradoAlumnos);
            ViewData["ClaveGrupoAlumnos"] = new SelectList(_context.Grupos, "Grupo1", "Grupo1", alumno.ClaveGrupoAlumnos);
            return View(alumno);
        }

        // GET: Alumnoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }
            ViewData["ClaveCarreraAlumno"] = new SelectList(_context.Carreras, "CodigoCarrera", "NombreCarrera", alumno.ClaveCarreraAlumno);
            ViewData["ClaveDivisionAlumno"] = new SelectList(_context.Divisiones, "CodigoDivisiones", "DescripcionDivision", alumno.ClaveDivisionAlumno);
            ViewData["ClaveGradoAlumnos"] = new SelectList(_context.Grados, "Grado1", "Grado1", alumno.ClaveGradoAlumnos);
            ViewData["ClaveGrupoAlumnos"] = new SelectList(_context.Grupos, "Grupo1", "Grupo1", alumno.ClaveGrupoAlumnos);
            return View(alumno);
        }

        // POST: Alumnoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MatriculaAlumno,Nombre,ApellidoP,ApellidoM,Estatus,ClaveGradoAlumnos,ClaveGrupoAlumnos,ClaveDivisionAlumno,ClaveCarreraAlumno")] Alumno alumno)
        {
            if (id != alumno.MatriculaAlumno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnoExists(alumno.MatriculaAlumno))
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
            ViewData["ClaveCarreraAlumno"] = new SelectList(_context.Carreras, "CodigoCarrera", "NombreCarrera", alumno.ClaveCarreraAlumno);
            ViewData["ClaveDivisionAlumno"] = new SelectList(_context.Divisiones, "CodigoDivisiones", "DescripcionDivision", alumno.ClaveDivisionAlumno);
            ViewData["ClaveGradoAlumnos"] = new SelectList(_context.Grados, "Grado1", "Grado1", alumno.ClaveGradoAlumnos);
            ViewData["ClaveGrupoAlumnos"] = new SelectList(_context.Grupos, "Grupo1", "Grupo1", alumno.ClaveGrupoAlumnos);
            return View(alumno);
        }

        // GET: Alumnoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos
                .Include(a => a.ClaveCarreraAlumnoNavigation)
                .Include(a => a.ClaveDivisionAlumnoNavigation)
                .Include(a => a.ClaveGradoAlumnosNavigation)
                .Include(a => a.ClaveGrupoAlumnosNavigation)
                .FirstOrDefaultAsync(m => m.MatriculaAlumno == id);
            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        // POST: Alumnoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);
            _context.Alumnos.Remove(alumno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnoExists(string id)
        {
            return _context.Alumnos.Any(e => e.MatriculaAlumno == id);
        }
    }
}
