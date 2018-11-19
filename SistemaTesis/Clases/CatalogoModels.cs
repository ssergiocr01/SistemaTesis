using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SistemaTesis.Data;
using SistemaTesis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTesis.Clases
{
    [Authorize(Roles = "Administrador")]
    public class CatalogoModels : ListObject
    {
        private string code = "", des = "";
        private Boolean estados;

        public CatalogoModels(ApplicationDbContext context)
        {
            this.context = context;
        }

        internal List<Amenaza> getAmenazas()
        {
            return context.Amenaza.Where(p => p.Estado == true).ToList();
        }

        public List<Amenaza> getAmenaza(int id)
        {
            return context.Amenaza.Where(p => p.AmenazaID == id).ToList();
        }

        public List<IdentityError> agregarAmenaza(int id, string descripcion, Boolean estado, int amenaza, double porcentaje, string funcion)
        {
            var catalogo = new CatalogoAmenaza
            {
                Descripcion = descripcion,
                Estado = estado,
                AmenazaID = amenaza,
                Porcentaje = porcentaje,
            };
            try
            {
                context.Add(catalogo);
                context.SaveChanges();
                code = "Save";
                des = "Save";
            }
            catch (Exception e)
            {
                code = "error";
                des = e.Message;
            }
            errorList.Add(new IdentityError
            {
                Code = code,
                Description = des,
            });
            return errorList;
        }

        public List<CatalogoAmenaza> getCatalogo(int id)
        {
            return context.CatalogoAmenaza.Where(c => c.CatalogoAmenazaID == id).ToList();
        }

        public List<object[]> filtrarCatalogo(int numPagina, string valor, string order, int funcion)
        {
            int cant, numRegistros = 0, inicio = 0, reg_por_pagina = 4;
            int can_paginas, pagina;
            string dataFilter = "", paginador = "", Estado = null;

            IEnumerable<CatalogoAmenaza> query;
            List<CatalogoAmenaza> catalogos = null;

            switch (order)
            {
                case "descripcion":
                    catalogos = context.CatalogoAmenaza.OrderBy(c => c.Descripcion).ToList();
                    break;
                case "estado":
                    catalogos = context.CatalogoAmenaza.OrderBy(c => c.Estado).ToList();
                    break;
                case "amenaza":
                    catalogos = context.CatalogoAmenaza.OrderBy(c => c.Amenaza.Descripcion).ToList();
                    break;
            }

            numRegistros = catalogos.Count;
            if ((numRegistros % reg_por_pagina) > 0)
            {
                numRegistros += 1;
            }
            inicio = (numPagina - 1) * reg_por_pagina;
            can_paginas = (numRegistros / reg_por_pagina);
            if (valor == "null")
            {
                query = catalogos.Skip(inicio).Take(reg_por_pagina);
            }
            else
            {
                query = catalogos.Where(c => c.Descripcion.StartsWith(valor)).Skip(inicio).Take(reg_por_pagina);
            }
            cant = query.Count();

            foreach (var item in query)
            {
                var amenaza = getAmenaza(item.AmenazaID);
                if (item.Estado == true)
                {
                    Estado = "<a data-toggle='modal' data-target='#ModalEstadoCatalogo' onclick='editarEstadoCatalogo(" + item.CatalogoAmenazaID + ',' + 0 + ")' class='btn btn-success'>Activo</a>";
                }
                else
                {
                    Estado = "<a data-toggle='modal' data-target='#ModalEstadoCatalogo' onclick='editarEstadoCatalogo(" + item.CatalogoAmenazaID + ',' + 0 + ")' class='btn btn-danger'>No activo</a>";
                }
                dataFilter += "<tr>" +
                        "<td>" + item.Descripcion + "</td>" +
                        "<td>" + Estado + "</td>" +
                        "<td>" + amenaza[0].Descripcion + "</td>" +
                        "<td>" + item.Porcentaje + "</td>" +
                        "<td>" +
                        dataBoton(item, funcion) +
                        "</td>" +
                    "</tr>";
            }
            if (valor == "null")
            {
                if (numPagina > 1)
                {
                    pagina = numPagina - 1;
                    paginador += "<a class='btn btn-default' onclick='filtrarCatalogo(" + 1 + ',' + '"' + order + '"' + ")'> << </a>" +
                    "<a class='btn btn-default' onclick='filtrarCatalogo(" + pagina + ',' + '"' + order + '"' + ")'> < </a>";
                }
                if (1 < can_paginas)
                {
                    paginador += "<strong class='btn btn-success'>" + numPagina + ".de." + can_paginas + "</strong>";
                }
                if (numPagina < can_paginas)
                {
                    pagina = numPagina + 1;
                    paginador += "<a class='btn btn-default' onclick='filtrarCatalogo(" + pagina + ',' + '"' + order + '"' + ")'>  > </a>" +
                                 "<a class='btn btn-default' onclick='filtrarCatalogo(" + can_paginas + ',' + '"' + order + '"' + ")'> >> </a>";
                }
            }
            object[] dataObj = { dataFilter, paginador };
            data.Add(dataObj);
            return data;
        }

        private string dataBoton(CatalogoAmenaza item, int funcion)
        {
            String data = "";
            if (funcion == 1)
            {
                data = "<a data-toggle='modal' data-target='#modalCatalogo' onclick='editarEstadoCatalogo(" + item.CatalogoAmenazaID + ',' + 1 + ")'  " +
                    "class='btn btn-warning'>Editar</a>";
            }
            else
            {
                data = "<td>Error</td>";
            }
            return data;
        }

        public List<IdentityError> editarCatalogo(int id, string descripcion, Boolean estado, int amenazaID, double porcentaje, int funcion)
        {
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
            var catalogo = new CatalogoAmenaza
            {
                CatalogoAmenazaID = id,
                Descripcion = descripcion,
                Estado = estados,
                AmenazaID = amenazaID,
                Porcentaje = porcentaje
            };
            try
            {
                context.Update(catalogo);
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
