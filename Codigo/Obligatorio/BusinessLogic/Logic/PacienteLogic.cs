using DataAccess.Model;
using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class PacienteLogic : IPacienteLogic
    {

        public IEnumerable<Modelo.Models.Paciente> ListPacientes()
        {
            IEnumerable<Paciente> result = new List<Paciente>();
            try
            {
                using (Context db = new Context())
                {
                    result = db.Pacientes.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public Modelo.Models.Paciente GetPaciente(int id)
        {
            Paciente result = null;
            try
            {
                using (Context db = new Context())
                {
                    result = db.Pacientes.SingleOrDefault(p => p.PacienteID == id);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public void Save(Modelo.Models.Paciente paciente)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Pacientes.Add(paciente);
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

                    var paciente = GetPaciente(id);
                    if (paciente != null)
                    {
                        db.Entry(paciente).State = System.Data.Entity.EntityState.Deleted;
                        db.Pacientes.Remove(paciente);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Edit(Modelo.Models.Paciente paciente)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(paciente).State = System.Data.Entity.EntityState.Modified;
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
