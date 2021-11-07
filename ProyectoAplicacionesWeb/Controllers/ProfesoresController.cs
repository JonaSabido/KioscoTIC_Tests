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
    public class ProfesoresController : Controller
    {
        private readonly Kiosco_UTM_FINALContext _context;

        public ProfesoresController(Kiosco_UTM_FINALContext context)
        {
            _context = context;
        }

        // GET: Profesores
        public async Task<IActionResult> Index()
        {
            var kiosco_UTM_FINALContext = _context.Profesores.Include(p => p.ClaveDivisionMaestrosNavigation);
            return View(await kiosco_UTM_FINALContext.ToListAsync());
        }

        // GET: Profesores/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesore = await _context.Profesores
                .Include(p => p.ClaveDivisionMaestrosNavigation)
                .FirstOrDefaultAsync(m => m.MatriculaMaestros == id);
            if (profesore == null)
            {
                return NotFound();
            }

            return View(profesore);
        }

        // GET: Profesores/Create
        public IActionResult Create()
        {
            ViewData["ClaveDivisionMaestros"] = new SelectList(_context.Divisiones, "CodigoDivisiones", "DescripcionDivision");
            return View();
        }

        // POST: Profesores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MatriculaMaestros,Nombre,ApellidoP,ApellidoM,Estatus,ClaveDivisionMaestros")] Profesore profesore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClaveDivisionMaestros"] = new SelectList(_context.Divisiones, "CodigoDivisiones", "DescripcionDivision", profesore.ClaveDivisionMaestros);
            return View(profesore);
        }

        // GET: Profesores/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesore = await _context.Profesores.FindAsync(id);
            if (profesore == null)
            {
                return NotFound();
            }
            ViewData["ClaveDivisionMaestros"] = new SelectList(_context.Divisiones, "CodigoDivisiones", "DescripcionDivision", profesore.ClaveDivisionMaestros);
            return View(profesore);
        }

        // POST: Profesores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MatriculaMaestros,Nombre,ApellidoP,ApellidoM,Estatus,ClaveDivisionMaestros")] Profesore profesore)
        {
            if (id != profesore.MatriculaMaestros)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesoreExists(profesore.MatriculaMaestros))
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
            ViewData["ClaveDivisionMaestros"] = new SelectList(_context.Divisiones, "CodigoDivisiones", "DescripcionDivision", profesore.ClaveDivisionMaestros);
            return View(profesore);
        }

        // GET: Profesores/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesore = await _context.Profesores
                .Include(p => p.ClaveDivisionMaestrosNavigation)
                .FirstOrDefaultAsync(m => m.MatriculaMaestros == id);
            if (profesore == null)
            {
                return NotFound();
            }

            return View(profesore);
        }

        // POST: Profesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var profesore = await _context.Profesores.FindAsync(id);
            _context.Profesores.Remove(profesore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesoreExists(string id)
        {
            return _context.Profesores.Any(e => e.MatriculaMaestros == id);
        }
    }
}
