using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaTesis.Data;
using SistemaTesis.Models;

namespace SistemaTesis.Controllers
{
    public class FormulariosAmenazasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormulariosAmenazasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FormulariosAmenazas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FormularioAmenaza.Include(f => f.CatalogoAmenaza).Include(f => f.Formulario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FormulariosAmenazas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formularioAmenaza = await _context.FormularioAmenaza
                .Include(f => f.CatalogoAmenaza)
                .Include(f => f.Formulario)
                .SingleOrDefaultAsync(m => m.FormularioAmenazaID == id);
            if (formularioAmenaza == null)
            {
                return NotFound();
            }

            return View(formularioAmenaza);
        }

        // GET: FormulariosAmenazas/Create
        public IActionResult Create()
        {
            ViewData["CatalogoAmenazaID"] = new SelectList(_context.CatalogoAmenaza, "CatalogoAmenazaID", "Descripcion");
            ViewData["FormularioID"] = new SelectList(_context.Formulario, "FormularioID", "CuidoIndicadores");
            return View();
        }

        // POST: FormulariosAmenazas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormularioAmenazaID,FormularioID,CatalogoAmenazaID")] FormularioAmenaza formularioAmenaza)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formularioAmenaza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatalogoAmenazaID"] = new SelectList(_context.CatalogoAmenaza, "CatalogoAmenazaID", "Descripcion", formularioAmenaza.CatalogoAmenazaID);
            ViewData["FormularioID"] = new SelectList(_context.Formulario, "FormularioID", "CuidoIndicadores", formularioAmenaza.FormularioID);
            return View(formularioAmenaza);
        }

        // GET: FormulariosAmenazas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formularioAmenaza = await _context.FormularioAmenaza.SingleOrDefaultAsync(m => m.FormularioAmenazaID == id);
            if (formularioAmenaza == null)
            {
                return NotFound();
            }
            ViewData["CatalogoAmenazaID"] = new SelectList(_context.CatalogoAmenaza, "CatalogoAmenazaID", "Descripcion", formularioAmenaza.CatalogoAmenazaID);
            ViewData["FormularioID"] = new SelectList(_context.Formulario, "FormularioID", "CuidoIndicadores", formularioAmenaza.FormularioID);
            return View(formularioAmenaza);
        }

        // POST: FormulariosAmenazas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FormularioAmenazaID,FormularioID,CatalogoAmenazaID")] FormularioAmenaza formularioAmenaza)
        {
            if (id != formularioAmenaza.FormularioAmenazaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formularioAmenaza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormularioAmenazaExists(formularioAmenaza.FormularioAmenazaID))
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
            ViewData["CatalogoAmenazaID"] = new SelectList(_context.CatalogoAmenaza, "CatalogoAmenazaID", "Descripcion", formularioAmenaza.CatalogoAmenazaID);
            ViewData["FormularioID"] = new SelectList(_context.Formulario, "FormularioID", "CuidoIndicadores", formularioAmenaza.FormularioID);
            return View(formularioAmenaza);
        }

        // GET: FormulariosAmenazas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formularioAmenaza = await _context.FormularioAmenaza
                .Include(f => f.CatalogoAmenaza)
                .Include(f => f.Formulario)
                .SingleOrDefaultAsync(m => m.FormularioAmenazaID == id);
            if (formularioAmenaza == null)
            {
                return NotFound();
            }

            return View(formularioAmenaza);
        }

        // POST: FormulariosAmenazas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formularioAmenaza = await _context.FormularioAmenaza.SingleOrDefaultAsync(m => m.FormularioAmenazaID == id);
            _context.FormularioAmenaza.Remove(formularioAmenaza);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormularioAmenazaExists(int id)
        {
            return _context.FormularioAmenaza.Any(e => e.FormularioAmenazaID == id);
        }
    }
}
