using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Models
{
    public class InformesDeConsulta
    {
        [Key]
        public int InformesDeConsultaID { get; set; }

        [Required(ErrorMessage = "El motivo es requerido.")]
        public string Motivo { get; set; }

        [Required(ErrorMessage = "El detalle es requerido.")]
        public string Detalle { get; set; }

        [Required(ErrorMessage = "La fecha es requerida.")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Paciente Paciente { get; set; }
    }
}
