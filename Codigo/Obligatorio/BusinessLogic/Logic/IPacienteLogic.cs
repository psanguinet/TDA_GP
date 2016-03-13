using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public interface IPacienteLogic : IDisposable
    {
        IEnumerable<Paciente> ListPacientes();
        Paciente GetPaciente(int id);

        Paciente GetPacienteByUserName(string userName);
        void Save(Paciente paciente);
        void Delete(int id);
        void Edit(Paciente paciente);
        bool UserExist(User user);
    }
}
