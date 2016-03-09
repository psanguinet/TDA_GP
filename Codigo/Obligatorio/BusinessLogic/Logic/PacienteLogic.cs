using DataAccess.Model;
using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;



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
                    result = db.Pacientes.Include("Usuario").SingleOrDefault(p => p.PacienteID == id);
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
                    paciente.Usuario.Comment = "Paciente_Usuario";
                    paciente.Usuario.ConfirmationToken = "0";
                   
                    paciente.Usuario.FirstName = paciente.Nombre;
                    paciente.Usuario.IsApproved = true;
                    paciente.Usuario.LastName = paciente.Apellido;
                    paciente.Usuario.CreateDate = DateTime.UtcNow;
                    paciente.Usuario.LastPasswordChangedDate = DateTime.UtcNow;
                    paciente.Usuario.PasswordFailuresSinceLastSuccess = 0;
                    paciente.Usuario.LastLoginDate = DateTime.UtcNow;
                    paciente.Usuario.LastActivityDate = DateTime.UtcNow;
                    paciente.Usuario.LastLockoutDate = DateTime.UtcNow;
                    paciente.Usuario.IsLockedOut = false;
                    paciente.Usuario.LastPasswordFailureDate = DateTime.UtcNow;

                    paciente.Activo = true;
                    db.Pacientes.Add(paciente);
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

                    var paciente = GetPaciente(id);
                    if (paciente != null)
                    {
                        paciente.Activo = false;
                        db.Entry(paciente).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception e)
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
                    db.Entry(paciente.Usuario).State = System.Data.Entity.EntityState.Modified;
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


        public bool UserExist(User user)
        {
            bool duplicate = false;
            try
            {
                using (Context db = new Context())
                {
                    duplicate = db.Users.Where(Usr => Usr.Username == user.Username).Any();
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return duplicate;
        }
    }
}
