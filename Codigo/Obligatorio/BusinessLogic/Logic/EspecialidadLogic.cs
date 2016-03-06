using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using Modelo.Models;

namespace BusinessLogic.Logic
{
    public class EspecialidadLogic : IEspecialidadLogic
    {
       
        public IEnumerable<Especialidad> ListEspecialidades()
        {
            IEnumerable<Especialidad> result = new List<Especialidad>();
            try
            {
                using (Context db = new Context())
                {
                    result = db.Especialidades.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public Especialidad GetEspecialidad(int id)
        {
            Especialidad result = null;
            try
            {
                using (Context db = new Context())
                {
                    result = db.Especialidades.SingleOrDefault(e => e.EspecilidadID == id);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public Especialidad GetEspecialidadByName(string especialidadName)
        {
            Especialidad result = null;
            try
            {
                using (Context db = new Context())
                {
                    result = db.Especialidades.SingleOrDefault(e => e.Nombre == especialidadName);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public void Save(Especialidad especialidad)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Especialidades.Add(especialidad);
                    db.SaveChanges();
                }
            }
            catch (Exception)
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

                    var especialidad = GetEspecialidad(id);
                    if (especialidad != null)
                    {
                        db.Entry(especialidad).State = System.Data.Entity.EntityState.Deleted;
                        db.Especialidades.Remove(especialidad);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Edit(Especialidad especialidad)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(especialidad).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception)
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
