using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaTesis.Clases;
using SistemaTesis.Data;
using SistemaTesis.Models;

namespace SistemaTesis.Controllers
{
    //[Authorize(Roles = "Administrador")]
    public class AsentamientosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private AsentamientoModels asentamientoModels;

        public AsentamientosController(ApplicationDbContext context)
        {
            _context = context;
            asentamientoModels = new AsentamientoModels(_context);
        }

        // GET: Asentamientos
        public async Task<IActionResult> Index()
        {            
            return View();
        }

        public List<Provincia> getProvincias()
        {
            return asentamientoModels.getProvincias();
        }

        public List<TipoDocumento> getTiposDocumentos()
        {
            return asentamientoModels.getTiposDocumentos();
        }

        public List<Canton> getCantones(int provinciaID)
        {
            return asentamientoModels.getCantones(provinciaID);
        }

        public List<Distrito> getDistritos(int cantonID)
        {
            return asentamientoModels.getDistritos(cantonID);
        }


    }
}
