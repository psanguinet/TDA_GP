using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public interface IHistoriaMedicaLogic : IDisposable
    {
        IEnumerable<HistoriaMedica> ListadoHistoriaMedica(Paciente paciente, string searchText);
        IEnumerable<HistoriaMedica> ListadoHistoriaMedica(Doctor doctor, string searchText);
    }
}
