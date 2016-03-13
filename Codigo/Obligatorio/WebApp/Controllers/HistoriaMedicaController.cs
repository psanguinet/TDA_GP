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
        [Authorize(Roles = "PACIENTE")]
        public ActionResult IndexPaciente()
        {
            return View();

        }
        [Authorize(Roles = "DOCTOR")]
        public ActionResult IndexDoctor()
        {
            return View();

        }

        //
        // GET: /HistoriaMedica/
        [Authorize(Roles = "PACIENTE")]
        public ActionResult HistoriaMedicaPaciente()
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

        [Authorize(Roles = "DOCTOR")]
        public ActionResult HistoriaMedicaDoctor()
        {

            VM_HistoriaMedica historiaMedica = new VM_HistoriaMedica();
            Doctor doctor = null;
            try
            {
                string userName = ((HttpContext.User).Identity).Name;
                using (DataAccess.Model.Context db = new DataAccess.Model.Context())
                {
                    db.Configuration.ProxyCreationEnabled = false;
                    db.Configuration.LazyLoadingEnabled = false;
                    doctor = db.Doctores.Include("Usuario").SingleOrDefault(d => d.Usuario.Username == userName);
                }
                using (IInformeDeConsultaLogic bl = new InformeDeConsultaLogic())
                {
                    historiaMedica.ListadoInformeDeConsultas = bl.ListInformeDeConsultas(doctor);
                }
                using (IAnalisisClinicosLogic bl = new AnalisisClinicosLogic())
                {
                    historiaMedica.ListadoInformesAnalisisClinicos = bl.ListadoInformesAnalisisClinicos(doctor);
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