using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class AdministracionController : Controller
    {
        //
        // GET: /Administracion/
       
        [Authorize(Roles = "DIRECTOR")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
