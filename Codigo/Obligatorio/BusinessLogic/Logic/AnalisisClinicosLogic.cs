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

        public IEnumerable<AnalisisClinico> ListadoInformesAnalisisClinicos(Doctor doctor)
        {
            IEnumerable<AnalisisClinico> result = new List<AnalisisClinico>();
            try
            {
                int doctorID = doctor.DoctorID;
                using (Context db = new Context())
                {
                    result = db.AnalisisClinicos.Include("Doctor").Include("Paciente").Include("ListResultadoAnalisis").Where(a => a.Doctor.DoctorID == doctorID).OrderByDescending(a => a.Fecha).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }


        public AnalisisClinico GetAnalisisClinico(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(AnalisisClinico analisisClinico)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(analisisClinico.Paciente).State = System.Data.Entity.EntityState.Unchanged;
                    db.Entry(analisisClinico.Doctor).State = System.Data.Entity.EntityState.Unchanged;
                    //db.Entry(informeDeConsulta.Doctor.Usuario).State = System.Data.Entity.EntityState.Unchanged;
                    db.AnalisisClinicos.Add(analisisClinico);
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
            throw new NotImplementedException();
        }

        public void Edit(AnalisisClinico analisisClinico)
        {
            throw new NotImplementedException();
        }
    }
}
