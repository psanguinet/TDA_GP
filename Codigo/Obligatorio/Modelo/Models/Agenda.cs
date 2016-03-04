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
        public virtual Paciente Paciente { get; set; }
        public virtual Doctor Doctor { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La hora es requerida.")]
        public String Hora { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

    }
}
