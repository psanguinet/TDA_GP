using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Models;

namespace BusinessLogic.Logic
{
    public interface IRoleLogic : IDisposable
    {
        IEnumerable<Role> ListRoles();
        Role GetRol(Guid id);
        Role GetRolByName(string rolName);
        IEnumerable<string> GetRolByUserName(string userName);
        void Save(Role rol);
        void Delete(Guid id);
        void Edit(Role rol);
    }
}
