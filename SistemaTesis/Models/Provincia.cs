using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTesis.Models
{
    public class Provincia
    {
        public int ProvinciaID { get; set; }        

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(50, ErrorMessage = "El campo {0} no debe ser mayor a {1} carácteres")]
        public string Nombre { get; set; }

        public Boolean Estado { get; set; }

        public ICollection<Canton> Cantones { get; set; }
    }
}
