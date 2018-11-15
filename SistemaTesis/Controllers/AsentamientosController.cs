using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaTesis.Data;

namespace SistemaTesis.Controllers
{
    public class AsentamientosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AsentamientosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Asentamientos
        public async Task<IActionResult> Index()
        {            
            return View();
        }

        
    }
}
