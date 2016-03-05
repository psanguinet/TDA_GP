using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Models
{
    public class Agenda
    {
        [Key]
        public int AgendaID { get; set; }

        [Required(ErrorMessage = "El paciente es requerido.")]
        public virtual Paciente Paciente { get; set; }

        [Required(ErrorMessage = "El medico es requerido.")]
        public virtual Doctor Doctor { get; set; }

        [Required(ErrorMessage = "La fecha es requerida.")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La hora es requerida.")]
        public String Hora { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

    }
}
