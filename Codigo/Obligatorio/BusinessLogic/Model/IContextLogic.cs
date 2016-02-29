using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace BusinessLogic.Model
{
    public interface IContextLogic
    {
        Context GetContext();
    }
}
