using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Models
{
    public class HistoriaMedica
    {
        [Key]
        public int HistoriaMedicaID { get; set; }
        public virtual ICollection<AnalisisClinico> ListAnalisisClinicos { get; set; }
        public virtual ICollection<InformesDeConsulta> ListInformesDeConsulta { get; set; }
    }
}
