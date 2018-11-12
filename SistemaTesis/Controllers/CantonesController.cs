using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaTesis.Data;
using SistemaTesis.Models;
using SistemaTesis.Clases;
using Microsoft.AspNetCore.Identity;

namespace SistemaTesis.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class CantonesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private CantonModels cantonModels;

        public CantonesController(ApplicationDbContext context)
        {
            _context = context;
            cantonModels = new CantonModels(_context);
        }

        // GET: Cantones
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Canton.Include(c => c.Provincia);
            return View(await applicationDbContext.ToListAsync());
        }

        public List<Provincia> getProvincias()
        {
            return cantonModels.getProvincias();
        }

        public List<IdentityError> agregarCanton(int id, string nombre, Boolean estado, int provincia, string funcion)
        {
            return cantonModels.agregarCanton(id, nombre, estado, provincia, funcion);
        }

        public List<object[]> filtrarCanton(int numPagina, string valor, string order)
        {
            return cantonModels.filtrarCanton(numPagina, valor, order);
        }
    }
}
