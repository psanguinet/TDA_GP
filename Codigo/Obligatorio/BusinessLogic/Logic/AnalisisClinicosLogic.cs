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
            AnalisisClinico analisisClinico = null;
            try
            {
                using (Context db = new Context())
                {

                    analisisClinico = db.AnalisisClinicos.Include("Doctor").Include("Paciente").Include("ListResultadoAnalisis").SingleOrDefault(ac => ac.AnalisisClinicoID == id);
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return analisisClinico;
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
            AnalisisClinico analisisClinico = null;
            try
            {
                using (Context db = new Context())
                {

                    analisisClinico = this.GetAnalisisClinico(id);
                    if (analisisClinico != null)
                    {
                        db.Entry(analisisClinico).State = System.Data.Entity.EntityState.Deleted;
                        db.AnalisisClinicos.Remove(analisisClinico);
                        db.SaveChanges();
                    }

                }

            }
            catch (Exception e)
            {
                throw;
            }

        }

        public void Edit(AnalisisClinico analisisClinico)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(analisisClinico).State = System.Data.Entity.EntityState.Modified;
                    foreach(var item in analisisClinico.ListResultadoAnalisis)
                    {
                        db.ResultadosAnalisis.Add(item);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
