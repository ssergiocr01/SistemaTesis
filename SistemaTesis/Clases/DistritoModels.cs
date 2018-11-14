using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using SistemaTesis.Data;
using SistemaTesis.Models;

namespace SistemaTesis.Clases
{
    public class DistritoModels : ListObject
    {

        private string code = "", des = "";
        private Boolean estados;

        public DistritoModels(ApplicationDbContext context)
        {
            this.context = context;
        }

        internal List<Provincia> getProvincias()
        {
            return context.Provincia.Where(p => p.Estado == true).ToList();
        }

        internal List<Canton> getCantones(int provinciaID)
        {
            return context.Canton.Where(c => c.Estado == true && c.ProvinciaID == provinciaID).ToList();
        }

        public List<Provincia> getProvincia(int id)
        {
            return context.Provincia.Where(p => p.ProvinciaID == id).ToList();
        }

        public List<Canton> getCanton(int id)
        {
            return context.Canton.Where(c => c.CantonID == id).ToList();
        }

        public List<Distrito> getDistritos(int id)
        {
            return context.Distrito.Where(d => d.DistritoID == id).ToList();
        }

        public List<IdentityError> agregarDistrito(int id, string nombre, Boolean estado, int provincia, int canton, string funcion)
        {
            var distrito = new Distrito
            {
                Nombre = nombre,
                Estado = estado,
                ProvinciaID = provincia,
                CantonID = canton,
            };
            try
            {
                context.Add(distrito);
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

        public List<object[]> filtrarDistrito(int numPagina, string valor, string order, int funcion)
        {
            int cant, numRegistros = 0, inicio = 0, reg_por_pagina = 10;
            int can_paginas, pagina;
            string dataFilter = "", paginador = "", Estado = null;

            IEnumerable<Distrito> query;
            List<Distrito> distritos = null;

            switch (order)
            {
                case "nombre":
                    distritos = context.Distrito.OrderBy(c => c.Nombre).ToList();
                    break;
                case "estado":
                    distritos = context.Distrito.OrderBy(c => c.Estado).ToList();
                    break;
                case "provincia":
                    distritos = context.Distrito.OrderBy(c => c.Provincia.Nombre).ToList();
                    break;
                case "canton":
                    distritos = context.Distrito.OrderBy(c => c.Canton.Nombre).ToList();
                    break;
            }

            numRegistros = distritos.Count;
            if ((numRegistros % reg_por_pagina) > 0)
            {
                numRegistros += 1;
            }
            inicio = (numPagina - 1) * reg_por_pagina;
            can_paginas = (numRegistros / reg_por_pagina);
            if (valor == "null")
            {
                query = distritos.Skip(inicio).Take(reg_por_pagina);
            }
            else
            {
                query = distritos.Where(c => c.Nombre.StartsWith(valor)).Skip(inicio).Take(reg_por_pagina);
            }
            cant = query.Count();

            foreach (var item in query)
            {
                var provincia = getProvincia(item.ProvinciaID);
                var canton = getCanton(item.CantonID);
                if (item.Estado == true)
                {
                    Estado = "<a data-toggle='modal' data-target='#ModalEstadoDistrito' onclick='editarEstadoDistrito(" + item.DistritoID + ',' + 0 + ")' class='btn btn-success'>Activo</a>";
                }
                else
                {
                    Estado = "<a data-toggle='modal' data-target='#ModalEstadoDistrito' onclick='editarEstadoDistrito(" + item.DistritoID + ',' + 0 + ")' class='btn btn-danger'>No activo</a>";
                }
                dataFilter += "<tr>" +
                        "<td>" + item.Nombre + "</td>" +
                        "<td>" + Estado + "</td>" +
                        "<td>" + provincia[0].Nombre + "</td>" +
                        "<td>" + canton[0].Nombre + "</td>" +
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
                    paginador += "<a class='btn btn-default' onclick='filtrarDistrito(" + 1 + ',' + '"' + order + '"' + ")'> << </a>" +
                    "<a class='btn btn-default' onclick='filtrarDistrito(" + pagina + ',' + '"' + order + '"' + ")'> < </a>";
                }
                if (1 < can_paginas)
                {
                    paginador += "<strong class='btn btn-success'>" + numPagina + ".de." + can_paginas + "</strong>";
                }
                if (numPagina < can_paginas)
                {
                    pagina = numPagina + 1;
                    paginador += "<a class='btn btn-default' onclick='filtrarDistrito(" + pagina + ',' + '"' + order + '"' + ")'>  > </a>" +
                                 "<a class='btn btn-default' onclick='filtrarDistrito(" + can_paginas + ',' + '"' + order + '"' + ")'> >> </a>";
                }
            }            
            object[] dataObj = { dataFilter, paginador };
            data.Add(dataObj);
            return data;
        }

        private string dataBoton(Distrito item, int funcion)
        {
            String data = "";
            if (funcion == 1)
            {
                data = "<a data-toggle='modal' data-target='#modalDistritos' onclick='editarEstadoDistrito(" + item.DistritoID + ',' + 1 + ")'  " +
                    "class='btn btn-warning'>Editar</a>";
            }
            else
            {
                data = "<td>Error</td>";
            }
            return data;
        }

        public List<IdentityError> editarDistrito(int id, string nombre, Boolean estado, int provinciaID, int cantonID, int funcion)
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
            var distrito = new Distrito
            {
                DistritoID = id,
                Nombre = nombre,
                Estado = estados,
                ProvinciaID = provinciaID,
                CantonID = cantonID,
            };
            try
            {
                context.Update(distrito);
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
