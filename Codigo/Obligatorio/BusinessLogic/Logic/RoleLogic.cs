using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using Modelo.Models;

namespace BusinessLogic.Logic
{
    public class RoleLogic : IRoleLogic, IDisposable
    {
        public IEnumerable<Role> ListRoles()
        {
            IEnumerable<Role> result = new List<Role>();
            try
            {
                using (Context db = new Context())
                {
                    result = db.Roles.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public Role GetRol(Guid id)
        {
            Role result = null;
            try
            {
                using (Context db = new Context())
                {
                    result = db.Roles.SingleOrDefault(r => r.RoleId == id);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public void Save(Role rol)
        {
            try
            {
                using (Context db = new Context())
                {
                    rol.RoleId = Guid.NewGuid();
                    db.Roles.Add(rol);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                using (Context db = new Context())
                {
                  
                    var rol = GetRol(id);
                    if (rol != null)
                    {
                        db.Entry(rol).State = System.Data.Entity.EntityState.Deleted;
                        db.Roles.Remove(rol);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Edit(Role rol)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(rol).State = System.Data.Entity.EntityState.Modified;
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
