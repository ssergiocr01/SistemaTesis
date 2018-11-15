using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTesis.Models
{
    public class Asentamiento
    {
        public int AsentamientoID { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(50, ErrorMessage = "El campo {0} no debe ser mayor a {1} carácteres")]
        public string Nombre { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Direccion { get; set; }

        public string Coordenadas { get; set; }

        [Display(Name = "Nombre del Propietario")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string NombrePropietario { get; set; }

        [Display(Name = "Apellidos del Propietario")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string ApellidosPropietario { get; set; }

        [Display(Name = "Tipo de Documento")]
        public int TipoDocumentoID { get; set; }

        [Display(Name = "Número de Documento")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int NumDocumento { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime Ocupacion { get; set; }

        [Display(Name = "Número de Viviendas")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int NumViviendas { get; set; }

        public Boolean Estado { get; set; }

        [Display(Name = "Provincia")]
        public int ProvinciaID { get; set; }

        [Display(Name = "Cantón")]
        public int CantonID { get; set; }

        [Display(Name = "Distrito")]
        public int DistritoID { get; set; }

        [Display(Name ="Propietario")]
        public string FullName { get { return string.Format("{0} {1}", NombrePropietario, ApellidosPropietario); }  }

        public TipoDocumento TipoDocumento { get; set; }

        public Provincia Provincia { get; set; }

        public Canton Canton { get; set; }

        public Distrito Distrito { get; set; }

    }
}
