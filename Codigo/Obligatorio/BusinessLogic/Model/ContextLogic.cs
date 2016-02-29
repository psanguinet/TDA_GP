using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Model
{
    public class ContextLogic : IContextLogic
    {
        public DataAccess.Model.Context GetContext()
        {
            return new DataAccess.Model.Context();
        }
    }
}
