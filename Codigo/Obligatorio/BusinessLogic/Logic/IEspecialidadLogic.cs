using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Models;

namespace BusinessLogic.Logic
{
    public interface IEspecialidadLogic : IDisposable
    {
        IEnumerable<Especialidad> ListEspecialidades();
        Especialidad GetEspecialidad(int id);
        Especialidad GetEspecialidadByName(string especialidadName);
        void Save(Especialidad especialidad);
        void Delete(int id);
        void Edit(Especialidad especialidad);
        //void DeleteUltimasEspecialidades(int id);
        
    }
}
