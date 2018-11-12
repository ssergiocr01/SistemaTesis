using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTesis.Models
{
    public class Persona
    {
        public int PersonaID { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(50, ErrorMessage = "El campo {0} no debe ser mayor a {1} carácteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="El campo {0} es requerido")]
        [MaxLength(50, ErrorMessage = "El campo {0} no debe ser mayor a {1} carácteres")]
        public string Apellidos { get; set; }

        [Display(Name ="Número de Documento")]
        public string NumDocumento { get; set; }

        public int TipoDocumentoID { get; set; }

        public TipoDocumento TipoDocumento { get; set; }
    }
}
