using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTesis.Models
{
    public class Institucion
    {
        public int InstitucionID { get; set; }

        public string Nombre { get; set; }

        public ICollection<Persona> Personas { get; set; }
    }
}
