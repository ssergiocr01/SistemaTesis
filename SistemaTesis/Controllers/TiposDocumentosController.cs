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
    [Authorize(Roles = "Administrador")]
    public class TiposDocumentosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private TipoDocumentoModels tipoDocumentoModels;

        public TiposDocumentosController(ApplicationDbContext context)
        {
            _context = context;
            tipoDocumentoModels = new TipoDocumentoModels(_context);
        }

        // GET: TiposDocumentos
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public List<object[]> filtrarTiposDocumentos(int numPagina, string valor, string order)
        {
            return tipoDocumentoModels.filtrarTiposDocumentos(numPagina, valor, order);
        }

        public List<IdentityError> guardarTipoDocumento(string descripcion, string estado)
        {
            return tipoDocumentoModels.guardarTipoDocumento(descripcion, estado);
        }

        public List<TipoDocumento> getTiposDocumentos(int id)
        {
            return tipoDocumentoModels.getTiposDocumentos(id);
        }

        public List<IdentityError> editarTipoDocumento(int id, string descripcion, Boolean estado, int funcion)
        {
            return tipoDocumentoModels.editarTipoDocumento(id, descripcion, estado, funcion);
        }
    }
}
