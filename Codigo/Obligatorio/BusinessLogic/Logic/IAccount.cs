using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessLogic.Logic
{
    public interface IAccount
    {
        ActionResult Login(LoginModel model, string returnUrl);
    }
}
