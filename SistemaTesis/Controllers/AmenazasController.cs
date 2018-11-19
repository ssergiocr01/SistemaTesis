using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaTesis.Clases;
using SistemaTesis.Data;
using SistemaTesis.Models;

namespace SistemaTesis.Controllers
{
    public class AmenazasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private AmenazaModels amenazaModels;

        public AmenazasController(ApplicationDbContext context)
        {
            _context = context;
            amenazaModels = new AmenazaModels(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<object[]> filtrarAmenazas(int numPagina, string valor, string order)
        {
            return amenazaModels.filtrarAmenazas(numPagina, valor, order);
        }
        public List<Amenaza> getAmenazas(int id)
        {
            return amenazaModels.getAmenazas(id);
        }
        public List<IdentityError> editarAmenaza(int id, string descripcion, double porcentaje, Boolean estado, int funcion)
        {
            return amenazaModels.editarAmenaza(id, descripcion, porcentaje, estado, funcion);
        }

        public List<IdentityError> guardarAmenaza(string descripcion, double porcentaje, string estado)
        {
            return amenazaModels.guardarAmenaza(descripcion, porcentaje, estado);
        }
    }
}
