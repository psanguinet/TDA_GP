using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Models;

namespace BusinessLogic.Logic
{
    public class InformeDeConsultaLogic : IInformeDeConsultaLogic
    {
        public Modelo.Models.InformesDeConsulta GetInformeDeConsulta(int id)
        {
            InformesDeConsulta result = null;
            try
            {
                if (id != null)
                {
                    using (Context db = new Context())
                    {
                        result = db.InformesDeConsultas.Include("Doctor").Include("Paciente").SingleOrDefault(ic => ic.InformesDeConsultaID == id);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public void Save(Modelo.Models.InformesDeConsulta informeDeConsulta)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(informeDeConsulta.Paciente).State = System.Data.Entity.EntityState.Unchanged;
                    db.Entry(informeDeConsulta.Doctor).State = System.Data.Entity.EntityState.Unchanged;
                    //db.Entry(informeDeConsulta.Doctor.Usuario).State = System.Data.Entity.EntityState.Unchanged;
                    db.InformesDeConsultas.Add(informeDeConsulta);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void Dispose()
        {
            GC.Collect();
        }

        public IEnumerable<Modelo.Models.InformesDeConsulta> ListInformeDeConsultas(int DoctorID)
        {
            IEnumerable<InformesDeConsulta> result = new List<InformesDeConsulta>();
            try
            {
                using (Context db = new Context())
                {
                    result = db.InformesDeConsultas.Include("Paciente").Where(a => a.Doctor.DoctorID == DoctorID).OrderByDescending(a => a.Fecha).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }


        public void Delete(int id)
        {
            try
            {
                using (Context db = new Context())
                {
                    var informeDeConsulta = GetInformeDeConsulta(id);
                    if (informeDeConsulta != null)
                    {
                        db.Entry(informeDeConsulta).State = System.Data.Entity.EntityState.Deleted;
                        db.InformesDeConsultas.Remove(informeDeConsulta);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Edit(InformesDeConsulta informeDeConsulta)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(informeDeConsulta).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
