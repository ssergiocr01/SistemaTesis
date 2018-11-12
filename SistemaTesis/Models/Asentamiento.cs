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

        [Required(ErrorMessage ="El campo {0} es requerido")]
        [MaxLength(50, ErrorMessage = "El campo {0} no debe ser mayor a {1} carácteres")]
        public string Nombre { get; set; }

        [DataType(DataType.MultilineText)]
        public string Direccion { get; set; }
        
        public string Coordenadas { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime Ocupacion { get; set; }

        [Display(Name ="Número de Viviendas")]
        public int NumViviendas { get; set; }

        public int ProvinciaID { get; set; }

        public int CantonID { get; set; }

        public int DistritoID { get; set; }

        public int PropietarioID { get; set; }    

        public Provincia Provincia { get; set; }

        public Canton Canton { get; set; }

        public Distrito Distrito { get; set; }

    }
}
