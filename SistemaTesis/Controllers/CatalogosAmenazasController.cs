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
    public class CatalogosAmenazasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private CatalogoModels catalogoModels;

        public CatalogosAmenazasController(ApplicationDbContext context)
        {
            _context = context;
            catalogoModels = new CatalogoModels(_context);
        }

        // GET: CatalogosAmenazas
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public List<Amenaza> getAmenazas()
        {
            return catalogoModels.getAmenazas();
        }

        public List<IdentityError> agregarCatalogo(int id, string descripcion, Boolean estado, int amenaza, double porcentaje, string funcion)
        {
            return catalogoModels.agregarAmenaza(id, descripcion, estado, amenaza, porcentaje, funcion);
        }

        public List<object[]> filtrarCatalogo(int numPagina, string valor, string order, int funcion)
        {
            return catalogoModels.filtrarCatalogo(numPagina, valor, order, funcion);
        }

        public List<CatalogoAmenaza> getCatalogos(int id)
        {
            return catalogoModels.getCatalogo(id);
        }

        public List<IdentityError> editarCatalogo(int id, string descripcion, Boolean estado, int amenaza, double porcentaje, int funcion)
        {
            return catalogoModels.editarCatalogo(id, descripcion, estado, amenaza, porcentaje, funcion);
        }


    }
}
