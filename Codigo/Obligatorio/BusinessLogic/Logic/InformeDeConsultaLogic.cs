using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class InformeDeConsultaLogic:IInformeDeConsultaLogic
    {
        public Modelo.Models.InformesDeConsulta GetInformeDeConsulta(int id)
        {
            throw new NotImplementedException();
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
    }
}
