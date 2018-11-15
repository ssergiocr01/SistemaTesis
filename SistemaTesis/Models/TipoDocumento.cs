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

        public Boolean Estado { get; set; }

        public ICollection<TipoDocumento> TiposDocumentos { get; set; }
    }
}
