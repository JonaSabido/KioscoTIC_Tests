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
    public class DivisionesController : Controller
    {
        private readonly Kiosco_UTM_FINALContext _context;

        public DivisionesController(Kiosco_UTM_FINALContext context)
        {
            _context = context;
        }

        // GET: Divisiones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Divisiones.ToListAsync());
        }

        // GET: Divisiones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divisione = await _context.Divisiones
                .FirstOrDefaultAsync(m => m.CodigoDivisiones == id);
            if (divisione == null)
            {
                return NotFound();
            }

            return View(divisione);
        }

        // GET: Divisiones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Divisiones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoDivisiones,NombreDivision,DescripcionDivision")] Divisione divisione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(divisione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(divisione);
        }

        // GET: Divisiones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divisione = await _context.Divisiones.FindAsync(id);
            if (divisione == null)
            {
                return NotFound();
            }
            return View(divisione);
        }

        // POST: Divisiones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoDivisiones,NombreDivision,DescripcionDivision")] Divisione divisione)
        {
            if (id != divisione.CodigoDivisiones)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(divisione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DivisioneExists(divisione.CodigoDivisiones))
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
            return View(divisione);
        }

        // GET: Divisiones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divisione = await _context.Divisiones
                .FirstOrDefaultAsync(m => m.CodigoDivisiones == id);
            if (divisione == null)
            {
                return NotFound();
            }

            return View(divisione);
        }

        // POST: Divisiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var divisione = await _context.Divisiones.FindAsync(id);
            _context.Divisiones.Remove(divisione);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DivisioneExists(int id)
        {
            return _context.Divisiones.Any(e => e.CodigoDivisiones == id);
        }
    }
}
