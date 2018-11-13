using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using SistemaTesis.Data;
using SistemaTesis.Models;

namespace SistemaTesis.Clases
{
    public class CantonModels : ListObject
    {
        private string code = "", des = "";
        private Boolean estados;

        public CantonModels(ApplicationDbContext context)
        {
            this.context = context;
        }

        internal List<Provincia> getProvincias()
        {
            return context.Provincia.Where(p => p.Estado == true).ToList();
        }

        public List<Provincia> getProvincia(int id)
        {
            return context.Provincia.Where(p => p.ProvinciaID == id).ToList();
        }

        public List<IdentityError> agregarCanton(int id, string nombre, Boolean estado, int provincia, string funcion)
        {
            var canton = new Canton
            {
                Nombre = nombre,
                Estado = estado,
                ProvinciaID = provincia,
            };
            try
            {
                context.Add(canton);
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

        public List<Canton> getCantones(int id)
        {
            return context.Canton.Where(c => c.CantonID == id).ToList();
        }

        public List<object[]> filtrarCanton(int numPagina, string valor, string order, int funcion)
        {
            int cant, numRegistros = 0, inicio = 0, reg_por_pagina = 7;
            int can_paginas, pagina;
            string dataFilter = "", paginador = "", Estado = null;

            IEnumerable<Canton> query;
            List<Canton> cantones = null;

            switch (order)
            {
                case "nombre":
                    cantones = context.Canton.OrderBy(c => c.Nombre).ToList();
                    break;
                case "estado":
                    cantones = context.Canton.OrderBy(c => c.Estado).ToList();
                    break;
                case "provincia":
                    cantones = context.Canton.OrderBy(c => c.Provincia.Nombre).ToList();
                    break;
            }

            numRegistros = cantones.Count;
            if ((numRegistros % reg_por_pagina) > 0)
            {
                numRegistros += 1;
            }
            inicio = (numPagina - 1) * reg_por_pagina;
            can_paginas = (numRegistros / reg_por_pagina);
            if (valor == "null")
            {
                query = cantones.Skip(inicio).Take(reg_por_pagina);
            }
            else
            {
                query = cantones.Where(c => c.Nombre.StartsWith(valor)).Skip(inicio).Take(reg_por_pagina);
            }
            cant = query.Count();

            foreach (var item in query)
            {
                var provincia = getProvincia(item.ProvinciaID);
                if (item.Estado == true)
                {
                    Estado = "<a data-toggle='modal' data-target='#ModalEstadoCanton' onclick='editarEstadoCanton(" + item.CantonID + ',' + 0 + ")' class='btn btn-success'>Activo</a>";
                }
                else
                {
                    Estado = "<a data-toggle='modal' data-target='#ModalEstadoCanton' onclick='editarEstadoCanton(" + item.CantonID + ',' + 0 + ")' class='btn btn-danger'>No activo</a>";
                }
                dataFilter += "<tr>" +
                        "<td>" + item.Nombre + "</td>" +
                        "<td>" + Estado + "</td>" +
                        "<td>" + provincia[0].Nombre + "</td>" +
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
                    paginador += "<a class='btn btn-default' onclick='filtrarCanton(" + 1 + ',' + '"' + order + '"' + ")'> << </a>" +
                    "<a class='btn btn-default' onclick='filtrarCanton(" + pagina + ',' + '"' + order + '"' + ")'> < </a>";
                }
                if (1 < can_paginas)
                {
                    paginador += "<strong class='btn btn-success'>" + numPagina + ".de." + can_paginas + "</strong>";
                }
                if (numPagina < can_paginas)
                {
                    pagina = numPagina + 1;
                    paginador += "<a class='btn btn-default' onclick='filtrarCanton(" + pagina + ',' + '"' + order + '"' + ")'>  > </a>" +
                                 "<a class='btn btn-default' onclick='filtrarCanton(" + can_paginas + ',' + '"' + order + '"' + ")'> >> </a>";
                }
            }
            object[] dataObj = { dataFilter, paginador };
            data.Add(dataObj);
            return data;
        }

        private string dataBoton(Canton item, int funcion)
        {
            String data = "";
            if (funcion == 1)
            {
                data = "<a data-toggle='modal' data-target='#modalCantones' onclick='editarEstadoCanton(" + item.CantonID + ',' + 1 + ")'  " +
                    "class='btn btn-warning'>Editar</a>" ;               
            }
            else
            {
                data = "<td>Error</td>";
            }
            return data;
        }

        public List<IdentityError> editarCanton(int id, string nombre, Boolean estado, int provinciaID, int funcion)
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
            var canton = new Canton
            {
                CantonID = id,
                Nombre = nombre,
                Estado = estados,
                ProvinciaID = provinciaID,
            };
            try
            {
                context.Update(canton);
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
