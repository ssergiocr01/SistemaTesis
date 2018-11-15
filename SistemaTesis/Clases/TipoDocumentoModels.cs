using Microsoft.AspNetCore.Identity;
using SistemaTesis.Data;
using SistemaTesis.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaTesis.Clases
{
    public class TipoDocumentoModels
    {
        private ApplicationDbContext context;
        private Boolean estados;

        public TipoDocumentoModels(ApplicationDbContext context)
        {
            this.context = context;
            //filtrarProvincias(1, "Alajuela");
        }

        public List<IdentityError> guardarTipoDocumento(string descripcion, string estado)
        {
            var errorList = new List<IdentityError>();
            var tipoDocumento = new TipoDocumento
            {
                Descripcion = descripcion,
                Estado = Convert.ToBoolean(estado),
            };
            context.Add(tipoDocumento
);

            context.SaveChanges();
            errorList.Add(new IdentityError
            {
                Code = "Save",
                Description = "Save"
            });
            return errorList;
        }

        public List<object[]> filtrarTiposDocumentos(int numPagina, string valor, string order)
        {
            int count = 0, cant, numRegistros = 0, inicio = 0, reg_por_pagina = 7;
            int can_paginas, pagina;
            string dataFilter = "", paginador = "", Estado = null;
            List<object[]> data = new List<object[]>();
            IEnumerable<TipoDocumento> query;
            List<TipoDocumento> tiposDocumentos = null;
            switch (order)
            {
                case "descripcion":
                    tiposDocumentos = context.TipoDocumento.OrderBy(c => c.Descripcion).ToList();
                    break;
                case "estado":
                    tiposDocumentos = context.TipoDocumento.OrderBy(c => c.Estado).ToList();
                    break;
                default:
                    break;
            }

            numRegistros = tiposDocumentos.Count;
            if ((numRegistros % reg_por_pagina) > 0)
            {
                numRegistros += 1;
            }
            inicio = (numPagina - 1) * reg_por_pagina;
            can_paginas = (numRegistros / reg_por_pagina);
            if (valor == "null")
            {
                query = tiposDocumentos.Skip(inicio).Take(reg_por_pagina);
            }
            else
            {
                query = tiposDocumentos.Where(c => c.Descripcion.StartsWith(valor)).Skip(inicio).Take(reg_por_pagina);
            }
            cant = query.Count();

            foreach (var item in query)
            {
                if (item.Estado == true)
                {
                    Estado = "<a data-toggle='modal' data-target='#ModalEstadoTipoDocumento' onclick='editarEstadoTipoDocumento(" + item.TipoDocumentoID + ',' + 0 + ")' " +
                        "class='btn btn-success'>Activo</a>";
                }
                else
                {
                    Estado = "<a data-toggle='modal' data-target='#ModalEstadoTipoDocumento' onclick='editarEstadoTipoDocumento(" + item.TipoDocumentoID + ',' + 0 + ")' " +
                        "class='btn btn-danger'>No activo</a>";
                }
                dataFilter += "<tr>" +
                      "<td>" + item.Descripcion + "</td>" +
                      "<td>" + Estado + " </td>" +
                      "<td>" +
                      "<a data-toggle='modal' data-target='#modalTiposDocumentos' onclick='editarEstadoTipoDocumento(" + item.TipoDocumentoID + ',' + 1 + ")'" +
                      "class='btn btn-warning'>Editar</a> &nbsp;" +
                      "</td>" +
                  "</tr>";
            }
            if (valor == "null")
            {
                if (numPagina > 1)
                {
                    pagina = numPagina - 1;
                    paginador += "<a class='btn btn-default' onclick='filtrarTiposDocumentos(" + 1 + ',' + '"' + order + '"' + ")'> << </a>" +
                    "<a class='btn btn-default' onclick='filtrarTiposDocumentos(" + pagina + ',' + '"' + order + '"' + ")'> < </a>";
                }
                if (1 < can_paginas)
                {
                    paginador += "<strong class='btn btn-success'>" + numPagina + ".de." + can_paginas + "</strong>";
                }
                if (numPagina < can_paginas)
                {
                    pagina = numPagina + 1;
                    paginador += "<a class='btn btn-default' onclick='filtrarTiposDocumentos(" + pagina + ',' + '"' + order + '"' + ")'>  > </a> " +
                                 "<a class='btn btn-default' onclick='filtrarTiposDocumentos(" + can_paginas + ',' + '"' + order + '"' + ")'> >> </a>";
                }
            }
            object[] dataObj = { dataFilter, paginador };
            data.Add(dataObj);
            return data;
        }

        public List<TipoDocumento> getTiposDocumentos(int id)
        {
            return context.TipoDocumento.Where(t => t.TipoDocumentoID == id).ToList();
        }

        public List<IdentityError> editarTipoDocumento(int idTipoDocumento, string descripcion, Boolean estado, int funcion)
        {
            var errorList = new List<IdentityError>();
            string code = "", des = "";
            switch (funcion)
            {
                case 0:
                    if (estado)
                    {
                        estados = false;
                    }
                    else
                    {
                        estados = true;
                    }
                    break;
                case 1:
                    estados = estado;
                    break;
            }
            var tipoDocumento = new TipoDocumento()
            {
                TipoDocumentoID = idTipoDocumento,
                Descripcion = descripcion,
                Estado = estados
            };
            try
            {
                context.Update(tipoDocumento);
                context.SaveChanges();
                code = "Save";
                des = "Save";
            }
            catch (Exception ex)
            {
                code = "error";
                des = ex.Message;
            }
            errorList.Add(new IdentityError
            {
                Code = code,
                Description = des
            });

            return errorList;
        }
    }
}
