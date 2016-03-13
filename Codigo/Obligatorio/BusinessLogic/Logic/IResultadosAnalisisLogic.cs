using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public interface IResultadosAnalisisLogic : IDisposable
    {
        IEnumerable<ResultadoAnalisis> ListadoResultadoAnalisis(Paciente paciente);
        IEnumerable<ResultadoAnalisis> ListadoResultadoAnalisis(Doctor doctor);
        ResultadoAnalisis GetResultadoAnalisis(int id);
        void Save(ResultadoAnalisis resultadoAnalisis);
        void Delete(int id);
        void Edit(ResultadoAnalisis resultadoAnalisis);
    }
}
