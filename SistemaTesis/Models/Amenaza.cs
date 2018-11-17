using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTesis.Models
{
    public class Amenaza
    {
        public int AmenazaID { get; set; }

        [Required(ErrorMessage ="El campo {0} es requerido")]
        public string Descripcion { get; set; }
        
        public double Porcentaje { get; set; }

        public Boolean Estado { get; set; }
    }
}
