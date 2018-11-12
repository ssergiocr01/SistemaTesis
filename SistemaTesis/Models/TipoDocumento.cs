using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTesis.Models
{
    public class TipoDocumento
    {
        public int TipoDocumentoID { get; set; }

        public string Descripcion { get; set; }

        public ICollection<Persona> Personas { get; set; }
    }
}
