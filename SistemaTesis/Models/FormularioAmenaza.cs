using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTesis.Models
{
    public class FormularioAmenaza
    {
        public int FormularioAmenazaID { get; set; }

        public int FormularioID { get; set; }

        public int CatalogoAmenazaID { get; set; }

        public Formulario Formulario { get; set; }

        public CatalogoAmenaza CatalogoAmenaza { get; set; }
    }
}
