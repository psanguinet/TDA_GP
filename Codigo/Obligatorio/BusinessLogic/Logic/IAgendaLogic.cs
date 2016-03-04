using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Models;

namespace BusinessLogic.Logic
{
    public interface IAgendaLogic
    {
        IEnumerable<Agenda> ListAgendaByDoctor(int DoctorID);
        Agenda GetAgendaItem(int id);
        void Save(Agenda agenda);
        void Delete(int id);
        void Edit(Agenda agenda);
        IDictionary<int,int> ListHorasDisponiblesPorFecha(DateTime date);
      
    }
}
