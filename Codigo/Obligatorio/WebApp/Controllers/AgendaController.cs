using BusinessLogic.Logic;
using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApp.Controllers
{
    public class AgendaController : Controller
    {
        //
        // GET: /Agenda/

        public ActionResult Index()
        {
            IEnumerable<Agenda> result = new List<Agenda>();
            try
            {
                using (IAgendaLogic bl = new AgendaLogic())
                {
                    string userName = ((HttpContext.User).Identity).Name;

                    //Guid userId = (Guid)WebSecurity.GetUser(userName).ProviderUserKey;
                    
                  
                   //using(IDoctorLogic bl = new DoctorLogic)
                   //{
                   // Doctor doctor = bl.GetDoctorByUser(userId);
                   //}
                   
                   
                    DateTime fecha = DateTime.Now;
                    IDictionary<string, bool> horas = bl.ListHorasDisponiblesPorFecha(1,fecha);
                    result = bl.ListAgendaByDoctor(1);
                }
            }
            catch (Exception e)
            {
                return View("Error");
            }
            return View(result);
        }

        public Action HorasDisponibles()
        {
            return null;

        }

    }
}
