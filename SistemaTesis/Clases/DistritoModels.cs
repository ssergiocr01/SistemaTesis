using System;
using System.Collections.Generic;
using System.Linq;
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

        internal List<Distrito> getCantones()
        {
            return context.Distrito.Where(d => d.Canton.ProvinciaID == d.Provincia.ProvinciaID).ToList();
        }
    }
}
