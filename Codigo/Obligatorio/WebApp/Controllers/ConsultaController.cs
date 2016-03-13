using BusinessLogic.Logic;
using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    [Authorize(Roles = "PACIENTE")]
    public class ConsultaController : Controller
    {
        //
        // GET: /Consulta/
        public ActionResult Index()
        {
            IEnumerable<Agenda> result = new List<Agenda>();
            Paciente paciente = null;
            try
            {
                string userName = ((HttpContext.User).Identity).Name;
                using (IPacienteLogic bl = new PacienteLogic())
                {
                    paciente = bl.GetPacienteByUserName(userName);
                }
                using (IConsultaLogic bl = new ConsultaLogic())
                {
                    result = bl.ListFuturasConsultasByPaciente(paciente.PacienteID);
                }
            }
            catch (Exception e)
            {
                return View("Error");
            }
            return View(result);
        }

    }
}