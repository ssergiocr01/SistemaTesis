using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaTesis.Data;
using SistemaTesis.Models;

namespace SistemaTesis.Clases
{
    public class CantonModels
    {
        private ApplicationDbContext context;

        public CantonModels(ApplicationDbContext context)
        {
            this.context = context;
        }

        internal List<Provincia> getProvincias()
        {
            return context.Provincia.Where(p => p.Estado == true).ToList();
        }
    }
}
