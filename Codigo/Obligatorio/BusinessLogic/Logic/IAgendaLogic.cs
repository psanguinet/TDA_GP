using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Models;

namespace BusinessLogic.Logic
{
    public interface IAgendaLogic : IDisposable
    {
        IEnumerable<Agenda> ListAgendaByDoctor(int DoctorID);
        Agenda GetAgendaItem(int id);
        void Save(Agenda agenda);
        void Delete(int id);
        void Edit(Agenda agenda);
        IDictionary<string, bool> ListHorasDisponiblesPorFecha(int doctorId, DateTime date);

    }
}
