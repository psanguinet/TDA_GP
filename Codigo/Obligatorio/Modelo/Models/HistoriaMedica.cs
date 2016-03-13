using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Models
{
    public class HistoriaMedica
    {
        public int Numero { get; set; }
        public EnumTipoDeInforme TipoDeInforme { get; set; }
        public string TipoDeInformeNombre { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    public enum EnumTipoDeInforme
    {
        InformesDeConsultas = 0,
        AnalisisCinico = 1,
    }
}
