using BusinessLogic.Logic;
using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.ViewModel;

namespace WebApp.Controllers
{
   
    public class HistoriaMedicaController : Controller
    {
        //
        // GET: /HistoriaMedica/
         [Authorize(Roles = "PACIENTE")]
        public ActionResult Index()
        {

            VM_HistoriaMedica historiaMedica = new VM_HistoriaMedica();
            Paciente paciente = null;
            try
            {
                string userName = ((HttpContext.User).Identity).Name;
                using (IPacienteLogic bl = new PacienteLogic())
                {
                    paciente = bl.GetPacienteByUserName(userName);
                }
                using (IInformeDeConsultaLogic bl = new InformeDeConsultaLogic())
                {
                    historiaMedica.ListadoInformeDeConsultas = bl.ListInformeDeConsultas(paciente);
                }
                using (IAnalisisClinicosLogic bl = new AnalisisClinicosLogic())
                {
                    historiaMedica.ListadoInformesAnalisisClinicos = bl.ListadoInformesAnalisisClinicos(paciente);
                }
            }
            catch (Exception e)
            {
                return View("Error");
            }
            return View(historiaMedica);
        }
    }
}