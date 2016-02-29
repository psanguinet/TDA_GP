using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public interface IPersonaLogic
    {
        IEnumerable<Persona> ListPersonas();
        Persona GetPersona(int id);

        void Save(Persona persona);
        void Delete(Persona persona);
        void Edit(Persona persona);
    }
}
