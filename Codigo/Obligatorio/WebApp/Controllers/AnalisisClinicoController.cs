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
        [Authorize(Roles = "DOCTOR")]
        public ActionResult Index()
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

        [Authorize(Roles = "DOCTOR")]
        public ActionResult Create()
        {
            try
            {
                Doctor doctor = null;
                using (IDoctorLogic bl = new DoctorLogic())
                {
                    string userName = ((HttpContext.User).Identity).Name;
                    doctor = bl.GetDoctorByUserName(userName);
                }

                ViewBag.DoctorNombre = doctor.Nombre + " " + doctor.Apellido;
                ViewBag.DoctorID = doctor.DoctorID;

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

        [Authorize(Roles = "DOCTOR")]
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

        [Authorize(Roles = "DOCTOR")]
        public ActionResult Edit(int id)
        {
            AnalisisClinico analisisClinico = null;
            try
            {
                using (IAnalisisClinicosLogic bl = new AnalisisClinicosLogic())
                {
                    analisisClinico = bl.GetAnalisisClinico(id);
                    ViewBag.ImageDataPaciente = Helper.HelperImage.ImagesConvert(analisisClinico.Paciente.Foto);
                    ViewBag.ImageDataDoctor = Helper.HelperImage.ImagesConvert(analisisClinico.Doctor.Foto);
                }

            }
            catch (Exception e)
            {
                return View("Error");
            }
            return View(analisisClinico);
        }

        [Authorize(Roles = "DOCTOR")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AnalisisClinico analisisClinico)
        {
            ActionResult result = null;
            try
            {
                using (IAnalisisClinicosLogic bl = new AnalisisClinicosLogic())
                {
                    bl.Edit(analisisClinico);
                }
                result = RedirectToAction("Index");

            }
            catch (Exception)
            {
                return View("Error");
            }
            return result;
        }

        public ActionResult Details(int id)
        {
            AnalisisClinico analisisClinico = null;
            try
            {
                using (IAnalisisClinicosLogic bl = new AnalisisClinicosLogic())
                {
                    analisisClinico = bl.GetAnalisisClinico(id);
                    ViewBag.ImageDataPaciente = Helper.HelperImage.ImagesConvert(analisisClinico.Paciente.Foto);
                    ViewBag.ImageDataDoctor = Helper.HelperImage.ImagesConvert(analisisClinico.Doctor.Foto);
                }
            }
            catch (Exception e)
            {
                return View("Error");
            }
            return View(analisisClinico);
        }

        [Authorize(Roles = "DOCTOR")]
        public ActionResult Delete(int id)
        {
            AnalisisClinico analisisClinico = null;
            try
            {
                using (IAnalisisClinicosLogic bl = new AnalisisClinicosLogic())
                {
                    analisisClinico = bl.GetAnalisisClinico(id);
                    ViewBag.ImageDataPaciente = Helper.HelperImage.ImagesConvert(analisisClinico.Paciente.Foto);
                    ViewBag.ImageDataDoctor = Helper.HelperImage.ImagesConvert(analisisClinico.Doctor.Foto);
                }

            }
            catch (Exception e)
            {
                return View("Error");
            }
            return View(analisisClinico);
        }

        [Authorize(Roles = "DOCTOR")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ActionResult result = null;
            try
            {
                if (ModelState.IsValid)
                {
                    using (IAnalisisClinicosLogic bl = new AnalisisClinicosLogic())
                    {
                        bl.Delete(id);
                    }
                    result = RedirectToAction("Index");
                }
                else
                {
                    result = View();
                }
            }
            catch (Exception e)
            {
                return View("Error");
            }
            return result;
        }
    }

}