using DataAccess.Model;
using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogic.Logic
{
   
    public class ConsultaLogic : IConsultaLogic
    {

        public IEnumerable<Modelo.Models.Agenda> ListFuturasConsultasByPaciente(int PacienteID)
        {
            IEnumerable<Agenda> result = new List<Agenda>();
            try
            {
                using (Context db = new Context())
                {
                    DateTime dateFrom = DateTime.Now;
                    result = db.Agendas.Include("Paciente").Include("Doctor").Where(a => a.Paciente.PacienteID == PacienteID && a.Fecha >= dateFrom).OrderByDescending(a => a.Fecha).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public void Dispose()
        {
            GC.Collect();
        }
    }
}
