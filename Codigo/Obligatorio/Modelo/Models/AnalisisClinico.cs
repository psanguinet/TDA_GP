using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Models
{
    public class AnalisisClinico
    {
        [Key]
        public int AnalisisClinicoID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public string Detalle { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual ICollection<ResultadoAnalisis> ListResultadoAnalisis { get; set; }
    }
}
