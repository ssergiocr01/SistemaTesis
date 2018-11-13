using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaTesis.Clases;
using SistemaTesis.Data;
using SistemaTesis.Models;

namespace SistemaTesis.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class DistritosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private DistritoModels distritoModels;

        public DistritosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Distritos
        public async Task<IActionResult> Index()
        {            
            return View();
        }

        public List<Provincia> getProvincias()
        {
            return distritoModels.getProvincias();
        }

    }
}
