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

        public List<Canton> getCanton(int id)
        {
            return context.Canton.Where(c => c.CantonID == id).ToList();
        }

        public List<Distrito> getDistrito(int id)
        {
            return context.Distrito.Where(d => d.DistritoID == id).ToList();
        }
    }
}
