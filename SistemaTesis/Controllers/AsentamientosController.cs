using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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

        public List<IdentityError> agregarAsentamiento(int id, string nombre, int provincia, int canton, int distrito, string direccion, string coordenadas,
            string nombrePropietario, string apellidosPropietario, int tipoDocumento, string numDocumento, string ocupacion, int numViviendas,
            Boolean estado, string funcion)
        {
            return asentamientoModels.agregarAsentamiento(id, nombre, provincia, canton, distrito, direccion, coordenadas, nombrePropietario,
                apellidosPropietario, tipoDocumento, numDocumento, ocupacion, numViviendas, estado, funcion);
        }

        public List<object[]> filtrarAsentamiento(int numPagina, string valor, string order, int funcion)
        {
            return asentamientoModels.filtrarAsentamiento(numPagina, valor, order, funcion);
        }

        public List<Asentamiento> getAsentamientos(int cantonID)
        {
            return asentamientoModels.getAsentamientos(cantonID);
        }

        public List<IdentityError> editarAsentamiento(int id, string nombre, int provincia, int canton, int distrito, string direccion, string coordenadas,
            string nombrePropietario, string apellidosPropietario, int tipoDocumento, string numDocumento, string ocupacion, int numViviendas,
            Boolean estado, int funcion)
        {
            return asentamientoModels.editarAsentamiento(id, nombre, provincia, canton, distrito, direccion, coordenadas, nombrePropietario, apellidosPropietario,
                tipoDocumento, numDocumento, ocupacion, numViviendas, estado, funcion);
        }
    }
}
