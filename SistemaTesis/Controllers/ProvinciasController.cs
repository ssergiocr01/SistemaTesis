using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaTesis.Clases;
using SistemaTesis.Data;
using SistemaTesis.Models;

namespace SistemaTesis.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ProvinciasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ProvinciaModels provinciaModels;

        public ProvinciasController(ApplicationDbContext context)
        {
            _context = context;
            provinciaModels = new ProvinciaModels(_context);
        }

        // GET: Provincias
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public List<object[]> filtrarProvincias(int numPagina, string valor, string order)
        {
            return provinciaModels.filtrarProvincias(numPagina, valor, order);
        }

        public List<IdentityError> guardarProvincia(string nombre, string estado)
        {
            return provinciaModels.guardarProvincia(nombre, estado);
        }

        public List<Provincia> getProvincias(int id)
        {
            return provinciaModels.getProvincias(id);
        }

        public List<IdentityError> editarProvincia(int id, string nombre, Boolean estado, int funcion)
        {
            return provinciaModels.editarProvincia(id, nombre, estado, funcion);
        }
    }
}
