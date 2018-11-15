using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTesis.Models
{
    public class Canton
    {
        public int CantonID { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(50, ErrorMessage = "El campo {0} no debe ser mayor a {1} carácteres")]
        
        public string Nombre { get; set; }        

        public Boolean Estado { get; set; }

        [Display(Name = "Provincia")]
        public int ProvinciaID { get; set; }

        public Provincia Provincia { get; set; }

        public ICollection<Distrito> Distritos { get; set; }

        public ICollection<Asentamiento> Asentamientos { get; set; }
    }
}
