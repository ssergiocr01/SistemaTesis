using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTesis.Models
{
    public class Evaluador : Persona
    {
        public int InstitucionID { get; set; }

        public Institucion Institucion { get; set; }
    }
}
