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
    }
}
