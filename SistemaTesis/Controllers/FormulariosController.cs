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
    public class FormulariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormulariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Formularios
        public async Task<IActionResult> Index()
        {            
            return View();
        }

        // GET: Formularios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulario = await _context.Formulario
                .Include(f => f.Asentamiento)
                .SingleOrDefaultAsync(m => m.FormularioID == id);
            if (formulario == null)
            {
                return NotFound();
            }

            return View(formulario);
        }

        // GET: Formularios/Create
        public IActionResult Create()
        {
            ViewData["AsentamientoID"] = new SelectList(_context.Asentamiento, "AsentamientoID", "Nombre");
            return View();
        }

        // POST: Formularios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormularioID,FechaLlenado,AsentamientoID,TenenciaIndicadores,FamiliaIndicadores,EducacionPrimariaIndicadores,EducacionSecundariaIndicadores,SaludIndicadores,CuidoIndicadores,IMASIndicadores,RecreativoIndicadores,ConPersoneria,SinPersoneria,AccesoAgua,AccesoElectricidad,AguasResiduales,RecoleccionBasura,Hurtos,ViolenciaIntrafamiliar,Abandono,Alcoholismo,Empleo,EdadProductiva,EmpleoInformal,EmpleoInfantil,JefesHogar,EmbarazosAdolescentes,MiembrosCostarricenses,MiembroExtranjero,ResidenciaPermanente,CondicionIrregular,NombreEvaluador,Institucion,NumCedula,Observaciones,ValorFinal")] Formulario formulario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formulario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AsentamientoID"] = new SelectList(_context.Asentamiento, "AsentamientoID", "Nombre", formulario.AsentamientoID);
            return View(formulario);
        }

        // GET: Formularios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulario = await _context.Formulario.SingleOrDefaultAsync(m => m.FormularioID == id);
            if (formulario == null)
            {
                return NotFound();
            }
            ViewData["AsentamientoID"] = new SelectList(_context.Asentamiento, "AsentamientoID", "Nombre", formulario.AsentamientoID);
            return View(formulario);
        }

        // POST: Formularios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FormularioID,FechaLlenado,AsentamientoID,TenenciaIndicadores,FamiliaIndicadores,EducacionPrimariaIndicadores,EducacionSecundariaIndicadores,SaludIndicadores,CuidoIndicadores,IMASIndicadores,RecreativoIndicadores,ConPersoneria,SinPersoneria,AccesoAgua,AccesoElectricidad,AguasResiduales,RecoleccionBasura,Hurtos,ViolenciaIntrafamiliar,Abandono,Alcoholismo,Empleo,EdadProductiva,EmpleoInformal,EmpleoInfantil,JefesHogar,EmbarazosAdolescentes,MiembrosCostarricenses,MiembroExtranjero,ResidenciaPermanente,CondicionIrregular,NombreEvaluador,Institucion,NumCedula,Observaciones,ValorFinal")] Formulario formulario)
        {
            if (id != formulario.FormularioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formulario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormularioExists(formulario.FormularioID))
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
            ViewData["AsentamientoID"] = new SelectList(_context.Asentamiento, "AsentamientoID", "Nombre", formulario.AsentamientoID);
            return View(formulario);
        }

        // GET: Formularios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulario = await _context.Formulario
                .Include(f => f.Asentamiento)
                .SingleOrDefaultAsync(m => m.FormularioID == id);
            if (formulario == null)
            {
                return NotFound();
            }

            return View(formulario);
        }

        // POST: Formularios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formulario = await _context.Formulario.SingleOrDefaultAsync(m => m.FormularioID == id);
            _context.Formulario.Remove(formulario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormularioExists(int id)
        {
            return _context.Formulario.Any(e => e.FormularioID == id);
        }
    }
}
