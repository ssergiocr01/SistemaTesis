using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTesis.Models
{
    public class CatalogoAmenaza
    {
        public int CatalogoAmenazaID { get; set; }

        [Display(Name ="Opción")]
        [Required(ErrorMessage ="El campo {0} es requerido")]
        public string Descripcion { get; set; }

        public double Porcentaje { get; set; }

        public Boolean Estado { get; set; }

        public int AmenazaID { get; set; }

        public Amenaza Amenaza { get; set; }
    }
}
