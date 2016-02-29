using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Models
{
    public class LiquidacionDeSueldo
    {
        [Key]
        public int LiquidacionID { get; set; }

        [Required(ErrorMessage = "La fecha es requerida.")]
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public DateTime FechaRealizacion { get; set; }

        public virtual Doctor Doctor { get; set; }

        [Required(ErrorMessage = "El mes es requerido.")]
        public int Mes { get; set; }

        [Required(ErrorMessage = "El año es requerido.")]
        [Display(Name = "Año")]
        public int Anio { get; set; }

        [Required(ErrorMessage = "El importe es requerido.")]
        public int Importe { get; set; }
    }
}
