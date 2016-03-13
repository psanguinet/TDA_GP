using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class HistoriaMedicaLogic:IHistoriaMedicaLogic
    {
        public IEnumerable<Modelo.Models.HistoriaMedica> ListadoHistoriaMedica(Modelo.Models.Paciente paciente, string searchText)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Modelo.Models.HistoriaMedica> ListadoHistoriaMedica(Modelo.Models.Doctor doctor, string searchText)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.Collect();
        }
    }
}
