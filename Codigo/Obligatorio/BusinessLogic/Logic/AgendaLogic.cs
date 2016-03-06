using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Models;

namespace BusinessLogic.Logic
{
    public class AgendaLogic : IAgendaLogic
    {

        public IEnumerable<Agenda> ListAgendaByDoctor(int DoctorID)
        {

            IEnumerable<Agenda> result = new List<Agenda>();
            try
            {
                using (Context db = new Context())
                {
                    result = db.Agendas.Include("Paciente").Where(a => a.Doctor.DoctorID == DoctorID).OrderByDescending(a => a.Fecha).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public Modelo.Models.Agenda GetAgendaItem(int id)
        {
            Agenda result = null;
            try
            {
                using (Context db = new Context())
                {
                    result = db.Agendas.SingleOrDefault(a => a.AgendaID == id);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public void Save(Modelo.Models.Agenda agenda)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(agenda.Paciente).State = System.Data.Entity.EntityState.Unchanged;
                    db.Entry(agenda.Doctor).State = System.Data.Entity.EntityState.Unchanged;
                    db.Entry(agenda.Doctor.Usuario).State = System.Data.Entity.EntityState.Unchanged;
                    db.Agendas.Add(agenda);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (Context db = new Context())
                {
                    var agenda = GetAgendaItem(id);
                    if (agenda != null)
                    {
                        db.Entry(agenda).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Edit(Modelo.Models.Agenda agenda)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(agenda).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IDictionary<string, bool> ListHorasDisponiblesPorFecha(int  doctorId, DateTime date)
        {
            IDictionary<string, bool> horasDisponibles = new Dictionary<string, bool>();
            for (int i = 0; i < 21; i++)
            {
                horasDisponibles.Add(string.Concat(i.ToString(), ":00"), true);
                horasDisponibles.Add(string.Concat(i.ToString(), ":30"), true);
            }
            try
            {
                using (Context db = new Context())
                {

                    string dateString = date.ToShortDateString();
                    DateTime dateTo = new DateTime(date.Year, date.Month, date.Day);
                    dateTo = dateTo.AddDays(1).AddSeconds(-1);
                    var agendaItems = db.Agendas.Where(a => a.Doctor.DoctorID == doctorId && a.Fecha > date && a.Fecha <= dateTo).ToList();
                    foreach (Agenda item in agendaItems)
                    {
                        horasDisponibles[item.Hora] = !horasDisponibles.ContainsKey(item.Hora);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return horasDisponibles;
        }

              

        public void Dispose()
        {
            GC.Collect();
        }
    }
}
