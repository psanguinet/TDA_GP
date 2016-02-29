using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Models;

namespace BusinessLogic.Logic
{
    public interface IRoleLogic
    {
        IEnumerable<Role> ListRoles();
        Role GetRol(Guid id);
        void Save(Role rol);
        void Delete(Guid id);
        void Edit(Role rol);
    }
}
