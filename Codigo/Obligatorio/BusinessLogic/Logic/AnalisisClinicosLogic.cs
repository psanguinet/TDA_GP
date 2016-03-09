using DataAccess.Model;
using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class AnalisisClinicosLogic : IAnalisisClinicosLogic
    {

        public IEnumerable<AnalisisClinico> ListadoInformesAnalisisClinicos(Paciente paciente)
        {
            IEnumerable<AnalisisClinico> result = new List<AnalisisClinico>();
            try
            {
                int PacienteID = paciente.PacienteID;
                using (Context db = new Context())
                {
                    result = db.AnalisisClinicos.Include("Doctor").Include("Paciente").Where(a => a.Paciente.PacienteID == PacienteID).OrderByDescending(a => a.Fecha).ToList();
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
