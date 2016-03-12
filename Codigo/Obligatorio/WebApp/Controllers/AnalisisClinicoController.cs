using BusinessLogic.Logic;
using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class AnalisisClinicoController : Controller
    {
        //
        // GET: /AnalisisClinico/
        public ActionResult Index()
        {
            IEnumerable<AnalisisClinico> result = new List<AnalisisClinico>();
            try
            {
                using (IAnalisisClinicosLogic bl = new AnalisisClinicosLogic())
                {
                    using (DataAccess.Model.Context db = new DataAccess.Model.Context())
                    {
                        string userName = ((HttpContext.User).Identity).Name;
                        var doc = db.Doctores.Include("Usuario").SingleOrDefault(d => d.Usuario.Username == userName);
                        result = bl.ListadoInformesAnalisisClinicos(doc);
                    }
                }
            }
            catch (Exception e)
            {
                return View("Error");
            }
            return View(result);
        }

        public ActionResult Create()
        {
            try
            {
                using (DataAccess.Model.Context db = new DataAccess.Model.Context())
                {
                    string userName = ((HttpContext.User).Identity).Name;
                    //TODO: CAMBIAR DE DATA ACCESS A BUSINESS
                    Doctor doc = db.Doctores.Include("Usuario").SingleOrDefault(d => d.Usuario.Username == userName);
                    ViewBag.DoctorNombre = doc.Nombre + " " + doc.Apellido;
                    ViewBag.DoctorID = doc.DoctorID;
                }

                using (IPacienteLogic bl = new PacienteLogic())
                {
                    IEnumerable<Paciente> pacientes = bl.ListPacientes();
                    ViewBag.Pacientes = pacientes;
                }
            }
            catch (Exception e)
            {
                return View("Error");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnalisisClinico analisisClinico)
        {
            ActionResult result = null;
            try
            {
                using (IAnalisisClinicosLogic bl = new AnalisisClinicosLogic())
                {
                    bl.Save(analisisClinico);
                }
                result = RedirectToAction("Index");

            }
            catch (Exception)
            {
                return View("Error");
            }
            return result;
        }
    }
}