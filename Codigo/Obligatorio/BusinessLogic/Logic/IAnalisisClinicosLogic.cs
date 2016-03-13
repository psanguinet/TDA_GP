using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public interface IAnalisisClinicosLogic : IDisposable
    {
        IEnumerable<AnalisisClinico> ListadoInformesAnalisisClinicos(Paciente paciente);
        IEnumerable<AnalisisClinico> ListadoInformesAnalisisClinicos(Doctor doctor);
        AnalisisClinico GetAnalisisClinico(int id);
        void Save(AnalisisClinico analisisClinico);
        void Delete(int id);
        void Edit(AnalisisClinico analisisClinico);
    }
}
