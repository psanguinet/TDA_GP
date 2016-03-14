using BusinessLogic.Logic;
using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    [Authorize(Roles = "DOCTOR")]
    public class InformeController : Controller
    {
        //
        // GET: /Informe/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InformeConsultaReducido()
        {
            IEnumerable<InformesDeConsulta> result = new List<InformesDeConsulta>();
            try
            {
                Doctor doctor = null;
                using (IDoctorLogic bl = new DoctorLogic())
                {
                    string userName = ((HttpContext.User).Identity).Name;
                    doctor = bl.GetDoctorByUserName(userName);
                }
                using (IInformeDeConsultaLogic bl = new InformeDeConsultaLogic())
                {
                    result = bl.ListInformeDeConsultas(doctor);
                }
            }
            catch (Exception e)
            {
                return View("Error");
            }
            return View(result);
        }
        public ActionResult InformeConsultaExtenso()
        {
            IEnumerable<InformesDeConsulta> result = new List<InformesDeConsulta>();
            try
            {
                Doctor doctor = null;
                using (IDoctorLogic bl = new DoctorLogic())
                {
                    string userName = ((HttpContext.User).Identity).Name;
                    doctor = bl.GetDoctorByUserName(userName);
                }
                using (IInformeDeConsultaLogic bl = new InformeDeConsultaLogic())
                {
                    result = bl.ListInformeDeConsultas(doctor);
                }
            }
            catch (Exception e)
            {
                return View("Error");
            }
            return View(result);
        }
        public ActionResult InformeAnalisisClinicoReducido()
        {

            IEnumerable<AnalisisClinico> result = new List<AnalisisClinico>();
            try
            {
                Doctor doctor = null;
                using (IDoctorLogic bl = new DoctorLogic())
                {
                    string userName = ((HttpContext.User).Identity).Name;
                    doctor = bl.GetDoctorByUserName(userName);
                }
                using (IAnalisisClinicosLogic bl = new AnalisisClinicosLogic())
                {
                    result = bl.ListadoInformesAnalisisClinicos(doctor);
                }
            }
            catch (Exception e)
            {
                return View("Error");
            }
            return View(result);
        }
        public ActionResult InformeAnalisisClinicoExtenso()
        {
            IEnumerable<AnalisisClinico> result = new List<AnalisisClinico>();
            try
            {
                Doctor doctor = null;
                using (IDoctorLogic bl = new DoctorLogic())
                {
                    string userName = ((HttpContext.User).Identity).Name;
                    doctor = bl.GetDoctorByUserName(userName);
                }
                using (IAnalisisClinicosLogic bl = new AnalisisClinicosLogic())
                {
                    result = bl.ListadoInformesAnalisisClinicos(doctor);
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