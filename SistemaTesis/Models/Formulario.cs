using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTesis.Models
{
    public class Formulario
    {
        public int FormularioID { get; set; }

        [Display(Name ="Fecha de llenado")]
        public DateTime FechaLlenado { get; set; }

        [Display(Name ="Asentamiento")]
        public int AsentamientoID { get; set; }

        [Display(Name = "Indicadores de tenencia de la tierra")]
        [Required(ErrorMessage ="El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage ="El campo {0} debe tener un máximo de {1} carácteres")]
        public string TenenciaIndicadores { get; set; }

        [Display(Name = "Indicadores de la cantidad de familias")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public string FamiliaIndicadores { get; set; }

        [Display(Name = "Indicadores de Educación Primaria")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public string EducacionPrimariaIndicadores { get; set; }

        [Display(Name = "Indicadores de Educación Secundaria")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public string EducacionSecundariaIndicadores { get; set; }

        [Display(Name = "Indicadores de Salud")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public string SaludIndicadores { get; set; }

        [Display(Name = "Indicadores de Alternativas de Cuido y desarrollo infantil (CECUDI, CEN-CINAI)")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public string CuidoIndicadores { get; set; }

        [Display(Name = "Indicadores de Asistencia social selectiva (IMAS)")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public string IMASIndicadores { get; set; }

        [Display(Name = "Indicadores de Espacios recreativos: parques y/o zonas verdes.")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public string RecreativoIndicadores { get; set; }

        [Display(Name = "Número de organizaciones con personería jurídica.")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public int ConPersoneria { get; set; }

        [Display(Name = "Número de organizaciones sin personería jurídica.")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public int SinPersoneria { get; set; }

        [Display(Name = "Indicador de acceso al agua")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public string AccesoAgua { get; set; }

        [Display(Name = "Indicador de acceso a electricidad")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public string AccesoElectricidad { get; set; }

        [Display(Name = "Indicador de disposición de aguas residuales")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public string AguasResiduales { get; set; }

        [Display(Name = "Indicador de recolección de basura")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public string RecoleccionBasura { get; set; }

        [Display(Name = "Número de hurtos.")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public int Hurtos { get; set; }

        [Display(Name = "Número de situaciones de violencia intrafamiliar.")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public int ViolenciaIntrafamiliar { get; set; }

        [Display(Name = "Número de personas en situación de calle o abandono.")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public int Abandono { get; set; }

        [Display(Name = "Número de personas con problemas de alcoholismo.")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public int Alcoholismo { get; set; }

        [Display(Name = "Número de personas con empleo parcial o total.")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public int Empleo { get; set; }

        [Display(Name = "Número de personas en edad productiva sin empleo.")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public int EdadProductiva { get; set; }

        [Display(Name = "Número de familias en empleo informal.")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public int EmpleoInformal { get; set; }

        [Display(Name = "Número de niños y niñas empleo infantil.")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public int EmpleoInfantil { get; set; }

        [Display(Name = "Número de mujeres y hombres solos jefes de hogar.")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public int JefesHogar { get; set; }

        [Display(Name = "Número de embarazos adolescentes.")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public int EmbarazosAdolescentes { get; set; }

        [Display(Name = "Número de familias con miembros costarricenses.")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public int MiembrosCostarricenses { get; set; }

        [Display(Name = "Número de familias con al menos un miembro extranjero con residencia.")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public int MiembroExtranjero { get; set; }

        [Display(Name = "Número de familias extranjeras con residencia permanente en todos sus miembros. ")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public int ResidenciaPermanente { get; set; }

        [Display(Name = "Número de familias con al menos un miembro en condición migratoria irregular. ")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public int CondicionIrregular { get; set; }

        [Display(Name = "Nombre del Evaluador. ")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public string NombreEvaluador { get; set; }

        [Display(Name = "Institución donde labora el evaluador. ")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public string Institucion { get; set; }

        [Display(Name = "Número de cédula del evaluador. ")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public string NumCedula { get; set; }

        [MaxLength(2000, ErrorMessage = "El campo {0} debe tener un máximo de {1} carácteres")]
        public string Observaciones { get; set; }

        [Display(Name ="Valor Final")]
        public double ValorFinal { get; set; }

        public Boolean Estado { get; set; }

        public virtual Asentamiento Asentamiento { get; set; }

        public ICollection<FormularioAmenaza> FormulariosAmenazas { get; set; }
    }
}
