using Microsoft.AspNetCore.Identity;
using SistemaTesis.Data;
using SistemaTesis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTesis.Clases
{
    public class AsentamientoModels : ListObject
    {
        private string code = "", des = "";
        private Boolean estados;

        public AsentamientoModels(ApplicationDbContext context)
        {
            this.context = context;
        }

        internal List<Provincia> getProvincias()
        {
            return context.Provincia.Where(p => p.Estado == true).ToList();
        }

        internal List<TipoDocumento> getTiposDocumentos()
        {
            return context.TipoDocumento.Where(t => t.Estado == true).ToList();
        }

        internal List<Canton> getCantones(int provinciaID)
        {
            return context.Canton.Where(c => c.Estado == true && c.ProvinciaID == provinciaID).ToList();
        }

        internal List<Distrito> getDistritos(int cantonID)
        {
            return context.Distrito.Where(d => d.Estado == true && d.CantonID == cantonID).ToList();
        }

        public List<Provincia> getProvincia(int id)
        {
            return context.Provincia.Where(p => p.ProvinciaID == id).ToList();
        }

        public List<TipoDocumento> getTipoDocumento(int id)
        {
            return context.TipoDocumento.Where(t => t.TipoDocumentoID == id).ToList();
        }

        public List<Canton> getCanton(int id)
        {
            return context.Canton.Where(c => c.CantonID == id).ToList();
        }

        public List<Distrito> getDistrito(int id)
        {
            return context.Distrito.Where(d => d.DistritoID == id).ToList();
        }

        public List<IdentityError> agregarAsentamiento(int id, string nombre, int provincia, int canton,
            int distrito, string direccion, string coordenadas, string nombrePropietario, string apellidosPropietario,
            int tipoDocumento, string numDocumento, string ocupacion, int numViviendas, Boolean estado, string funcion)
        {
            var asentamiento = new Asentamiento
            {
                Nombre = nombre,
                ProvinciaID = provincia,
                CantonID = canton,
                DistritoID = distrito,
                Direccion = direccion,
                Coordenadas = coordenadas,
                NombrePropietario = nombrePropietario,
                ApellidosPropietario = apellidosPropietario,
                TipoDocumentoID = tipoDocumento,
                NumDocumento = numDocumento,
                Ocupacion = DateTime.Parse(ocupacion),
                NumViviendas = numViviendas,
                Estado = estado
            };
            try
            {
                context.Add(asentamiento);
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

        public List<object[]> filtrarAsentamiento(int numPagina, string valor, string order, int funcion)
        {
            int cant, numRegistros = 0, inicio = 0, reg_por_pagina = 12;
            int can_paginas, pagina;
            string dataFilter = "", paginador = "", Estado = null;

            IEnumerable<Asentamiento> query;
            List<Asentamiento> asentamientos = null;

            switch (order)
            {
                case "nombre":
                    asentamientos = context.Asentamiento.OrderBy(a => a.Nombre).ToList();
                    break;
                case "estado":
                    asentamientos = context.Asentamiento.OrderBy(a => a.Estado).ToList();
                    break;
                case "provincia":
                    asentamientos = context.Asentamiento.OrderBy(a => a.Provincia.Nombre).ToList();
                    break;
                case "canton":
                    asentamientos = context.Asentamiento.OrderBy(a => a.Canton.Nombre).ToList();
                    break;
                case "distrito":
                    asentamientos = context.Asentamiento.OrderBy(a => a.Distrito.Nombre).ToList();
                    break;
                case "ocupacion":
                    asentamientos = context.Asentamiento.OrderBy(a => a.Ocupacion).ToList();
                    break;
                case "numViviendas":
                    asentamientos = context.Asentamiento.OrderBy(a => a.NumViviendas).ToList();
                    break;
            }

            numRegistros = asentamientos.Count;
            if ((numRegistros % reg_por_pagina) > 0)
            {
                numRegistros += 1;
            }
            inicio = (numPagina - 1) * reg_por_pagina;
            can_paginas = (numRegistros / reg_por_pagina);
            if (valor == "null")
            {
                query = asentamientos.Skip(inicio).Take(reg_por_pagina);
            }
            else
            {
                query = asentamientos.Where(c => c.Nombre.StartsWith(valor)).Skip(inicio).Take(reg_por_pagina);
            }
            cant = query.Count();

            foreach (var item in query)
            {
                var provincia = getProvincia(item.ProvinciaID);
                var canton = getCanton(item.CantonID);
                var distrito = getDistrito(item.DistritoID);
                var tipoDocumento = getTipoDocumento(item.TipoDocumentoID);
                if (item.Estado == true)
                {
                    Estado = "<a data-toggle='modal' data-target='#ModalEstadoAsentamiento' onclick='editarEstadoAsentamiento(" + item.AsentamientoID + ',' + 0 + ")' class='btn btn-success'>Activo</a>";
                }
                else
                {
                    Estado = "<a data-toggle='modal' data-target='#ModalEstadoAsentamiento' onclick='editarEstadoAsentamiento(" + item.AsentamientoID + ',' + 0 + ")' class='btn btn-danger'>No activo</a>";
                }
                var FullName = item.NombrePropietario + " " + item.ApellidosPropietario;
                dataFilter += "<tr>" +
                        "<td>" + item.Nombre + "</td>" +                        
                        "<td>" + provincia[0].Nombre + "</td>" +
                        "<td>" + canton[0].Nombre + "</td>" +
                        "<td>" + distrito[0].Nombre + "</td>" +
                        "<td>" + item.Direccion + "</td>" +
                        "<td>" + item.Coordenadas + "</td>" +
                        "<td>" + item.NombrePropietario + "</td>" +
                        "<td>" + item.ApellidosPropietario + "</td>" +
                        "<td>" + tipoDocumento[0].Descripcion + "</td>" +
                        "<td>" + item.NumDocumento + "</td>" +
                        "<td>" + item.Ocupacion + "</td>" +
                        "<td>" + item.NumViviendas + "</td>" +
                        "<td>" + Estado + "</td>" +
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
                    paginador += "<a class='btn btn-default' onclick='filtrarAsentamiento(" + 1 + ',' + '"' + order + '"' + ")'> << </a>" +
                    "<a class='btn btn-default' onclick='filtrarAsentamiento(" + pagina + ',' + '"' + order + '"' + ")'> < </a>";
                }
                if (1 < can_paginas)
                {
                    paginador += "<strong class='btn btn-success'>" + numPagina + ".de." + can_paginas + "</strong>";
                }
                if (numPagina < can_paginas)
                {
                    pagina = numPagina + 1;
                    paginador += "<a class='btn btn-default' onclick='filtrarAsentamiento(" + pagina + ',' + '"' + order + '"' + ")'>  > </a>" +
                                 "<a class='btn btn-default' onclick='filtrarAsentamiento(" + can_paginas + ',' + '"' + order + '"' + ")'> >> </a>";
                }
            }
            object[] dataObj = { dataFilter, paginador };
            data.Add(dataObj);
            return data;
        }

        private string dataBoton(Asentamiento item, int funcion)
        {
            String data = "";
            if (funcion == 1)
            {
                data = "<a data-toggle='modal' data-target='#modalAsentamientos' onclick='editarEstadoAsentamiento(" + item.AsentamientoID + ',' + 1 + ")'  " +
                    "class='btn btn-warning'>Editar</a>";
            }
            else
            {
                data = "<td>Error</td>";
            }
            return data;
        }

        public List<Asentamiento> getAsentamientos(int id)
        {
            return context.Asentamiento.Where(a => a.AsentamientoID == id).ToList();
        }

        public List<IdentityError> editarAsentamiento(int id, string nombre, int provincia, int canton,
            int distrito, string direccion, string coordenadas, string nombrePropietario, string apellidosPropietario,
            int tipoDocumento, string numDocumento, string ocupacion, int numViviendas, Boolean estado, int funcion)
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
            var asentamiento = new Asentamiento
            {
                Nombre = nombre,
                ProvinciaID = provincia,
                CantonID = canton,
                DistritoID = distrito,
                Direccion = direccion,
                Coordenadas = coordenadas,
                NombrePropietario = nombrePropietario,
                ApellidosPropietario = apellidosPropietario,
                TipoDocumentoID = tipoDocumento,
                NumDocumento = numDocumento,
                Ocupacion = DateTime.Parse(ocupacion),
                NumViviendas = numViviendas,
                Estado = estado
            };
            try
            {
                context.Update(asentamiento);
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
