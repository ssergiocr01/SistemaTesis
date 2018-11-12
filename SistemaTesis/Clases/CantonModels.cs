using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SistemaTesis.Data;
using SistemaTesis.Models;

namespace SistemaTesis.Clases
{
    public class CantonModels : ListObject
    {
        private ApplicationDbContext context;
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

        public List<object[]> filtrarCanton(int numPagina, string valor, string order)
        {
            int cant, numRegistros = 0, inicio = 0, reg_por_pagina = 5;
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
                    cantones = context.Canton.OrderBy(c => c.Provincia).ToList();
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


    }
}
