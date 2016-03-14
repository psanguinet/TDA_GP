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
    public class DoctorLogic : IDoctorLogic
    {

        public IEnumerable<Modelo.Models.Doctor> ListDoctores()
        {
            IEnumerable<Doctor> result = new List<Doctor>();
            try
            {
                using (Context db = new Context())
                {
                    result = db.Doctores.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public Modelo.Models.Doctor GetDoctor(int id)
        {
            Doctor result = null;
            try
            {
                using (Context db = new Context())
                {
                    result = db.Doctores.Include("Usuario").Include("ListEspecialidades").SingleOrDefault(d => d.DoctorID == id);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return result;
        }

        public void Save(Modelo.Models.Doctor doctor)
        {
            try
            {
                using (Context db = new Context())
                {
                    doctor.Usuario.Comment = "Paciente_Usuario";
                    doctor.Usuario.ConfirmationToken = "0";

                    doctor.Usuario.FirstName = doctor.Nombre;
                    doctor.Usuario.IsApproved = true;
                    doctor.Usuario.LastName = doctor.Apellido;
                    doctor.Usuario.CreateDate = DateTime.UtcNow;
                    doctor.Usuario.LastPasswordChangedDate = DateTime.UtcNow;
                    doctor.Usuario.PasswordFailuresSinceLastSuccess = 0;
                    doctor.Usuario.LastLoginDate = DateTime.UtcNow;
                    doctor.Usuario.LastActivityDate = DateTime.UtcNow;
                    doctor.Usuario.LastLockoutDate = DateTime.UtcNow;
                    doctor.Usuario.IsLockedOut = false;
                    doctor.Usuario.LastPasswordFailureDate = DateTime.UtcNow;

                    doctor.Activo = true;
                    foreach (Especialidad item in doctor.ListEspecialidades)
                    {
                        db.Entry(item).State = System.Data.Entity.EntityState.Unchanged;
                        db.SaveChanges();
                    }
                    db.Doctores.Add(doctor);
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

                    var doctor = GetDoctor(id);
                    if (doctor != null)
                    {
                        doctor.Activo = false;
                        db.Entry(doctor).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Edit(Modelo.Models.Doctor doctor)
            {
                try
                {
                    using(Context db = new Context())
                    {
                        // Se agrega el objeto modificado. 
                        doctor.Usuario.IsApproved = true;
                        db.Entry(doctor.Usuario).State = System.Data.Entity.EntityState.Modified;
                        db.Entry(doctor).State = System.Data.Entity.EntityState.Modified;
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
            catch (Exception)
            {

                throw;
            }
            return duplicate;
        }


        public Doctor GetDoctorByUserName(string userName)
        {
            Doctor doctor = null;
            try
            {
                if (userName != string.Empty)
                {
                    using (Context db = new Context())
                    {
                        doctor = db.Doctores.Include("Usuario").SingleOrDefault(d => d.Usuario.Username == userName);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return doctor;
        }
    }




}
