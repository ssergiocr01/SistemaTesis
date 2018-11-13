using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaTesis.Models
{
    public class Distrito
    {
        public int DistritoID { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(50, ErrorMessage = "El campo {0} no debe ser mayor a {1} carácteres")]
        public string Nombre { get; set; }

        public Boolean Estado { get; set; }

        [Display(Name = "Provincia")]
        public int ProvinciaID { get; set; }

        [Display(Name = "Canton")]
        public int CantonID { get; set; }

        public Provincia Provincia { get; set; }

        public Canton Canton { get; set; }

        public ICollection<Asentamiento> Asentamientos { get; set; }

    }
}
