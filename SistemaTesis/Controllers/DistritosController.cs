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
    public class DistritosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private DistritoModels distritoModels;

        public DistritosController(ApplicationDbContext context)
        {
            _context = context;
            distritoModels = new DistritoModels(_context);
        }

        // GET: Cantones
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public List<Provincia> getProvincias()
        {
            return distritoModels.getProvincias();
        }

        public List<Canton> getCantones(int provinciaID)
        {
            return distritoModels.getCantones(provinciaID);
        }

        public List<IdentityError> agregarDistrito(int id, string nombre, Boolean estado, int provincia, int canton, string funcion)
        {
            return distritoModels.agregarDistrito(id, nombre, estado, provincia, canton, funcion);
        }

        public List<object[]> filtrarDistrito(int numPagina, string valor, string order, int funcion)
        {
            return distritoModels.filtrarDistrito(numPagina, valor, order, funcion);
        }

        public List<Distrito> getDistritos(int cantonID)
        {
            return distritoModels.getDistritos(cantonID);
        }

        public List<IdentityError> editarDistrito(int id, string nombre, Boolean estado, int provincia, int canton, int funcion)
        {
            return distritoModels.editarDistrito(id, nombre, estado, provincia, canton, funcion);
        }

    }
}
