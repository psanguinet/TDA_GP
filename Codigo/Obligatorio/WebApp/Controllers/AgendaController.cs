using BusinessLogic.Logic;
using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using WebApp.ViewModel;
using System.Net;

namespace WebApp.Controllers
{
    [Authorize(Roles = "DOCTOR")]
    public class AgendaController : Controller
    {
        //
        // GET: /Agenda/

        public ActionResult Index()
        {
            IEnumerable<Agenda> result = new List<Agenda>();
            try
            {
                Doctor doctor = null;
                using (IDoctorLogic bl = new DoctorLogic())
                {
                    string userName = ((HttpContext.User).Identity).Name;
                    doctor = bl.GetDoctorByUserName(userName);
                }
                if (doctor != null)
                {

                    using (IAgendaLogic bl = new AgendaLogic())
                    {
                        result = bl.ListAgendaByDoctor(doctor.DoctorID);
                    }
                }

            }
            catch (Exception e)
            {
                return View("Error");
            }
            return View(result);
        }

        public ActionResult AgendarPaciente()
        {

            VM_Agenda vm_agenda = null;

            Doctor doctor = null;
            using (IDoctorLogic bl = new DoctorLogic())
            {
                string userName = ((HttpContext.User).Identity).Name;
                doctor = bl.GetDoctorByUserName(userName);
            }
            ViewBag.DoctorNombre = doctor.Nombre + " " + doctor.Apellido;

            using (IPacienteLogic bl = new PacienteLogic())
            {
                IEnumerable<Paciente> pacientes = bl.ListPacientes();
                ViewBag.Pacientes = pacientes;
            }

            using (IAgendaLogic bl = new AgendaLogic())
            {
                vm_agenda = new VM_Agenda();
                vm_agenda.ListHorasDisponibles = bl.ListHorasDisponiblesPorFecha(doctor.DoctorID, DateTime.Now);
            }
            return View(vm_agenda);
        }

        [HttpPost]
        public ActionResult AgendarPaciente(VM_Agenda vm_agenda)
        {
            Doctor doctor = null;
            using (IDoctorLogic bl = new DoctorLogic())
            {
                string userName = ((HttpContext.User).Identity).Name;
                doctor = bl.GetDoctorByUserName(userName);
            }
            Paciente paciente = null;
            using (IPacienteLogic bl = new PacienteLogic())
            {
                paciente = bl.GetPaciente(vm_agenda.PacienteID);
            }

            using (IAgendaLogic bl = new AgendaLogic())
            {
                Agenda agenda = new Agenda()
                {
                    Doctor = doctor,
                    Fecha = vm_agenda.Agenda.Fecha,
                    Hora = vm_agenda.Agenda.Hora,
                    Descripcion = vm_agenda.Agenda.Descripcion,
                    Paciente = paciente,
                };
                bl.Save(agenda);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Agenda agenda = null;
            try
            {
                using (IAgendaLogic bl = new AgendaLogic())
                {
                    agenda = bl.GetAgendaItem(id);
                    ViewBag.ImageDataPaciente = Helper.HelperImage.ImagesConvert(agenda.Paciente.Foto);
                    ViewBag.ImageDataDoctor = Helper.HelperImage.ImagesConvert(agenda.Doctor.Foto);
                }
                if (agenda == null)
                {
                    return HttpNotFound();
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
            return View(agenda);
        }

        public ActionResult Delete(int id)
        {
            Agenda result = null;
            try
            {
                if (id != null)
                {
                    using (IAgendaLogic bl = new AgendaLogic())
                    {
                        result = bl.GetAgendaItem(id);
                        ViewBag.ImageDataPaciente = Helper.HelperImage.ImagesConvert(result.Paciente.Foto);
                        ViewBag.ImageDataDoctor = Helper.HelperImage.ImagesConvert(result.Doctor.Foto);
                    }
                }
            }
            catch (Exception e)
            {
                return View("Error");
            }
            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ActionResult result = null;
            try
            {
                if (ModelState.IsValid)
                {
                    using (IAgendaLogic bl = new AgendaLogic())
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

        public ActionResult BuscarHorarios(string date)
        {
            IDictionary<string, bool> listData = null;
            //checking the query parameter sent from view. If it is null we will return null else we will return list based on query.
            string result = string.Empty;
            if (!string.IsNullOrEmpty(date))
            {
                DateTime fecha = DateTime.ParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                Doctor doctor = null;
                using (IDoctorLogic bl = new DoctorLogic())
                {
                    string userName = ((HttpContext.User).Identity).Name;
                    doctor = bl.GetDoctorByUserName(userName);
                }

                using (IAgendaLogic bl = new AgendaLogic())
                {

                    listData = bl.ListHorasDisponiblesPorFecha(doctor.DoctorID, fecha);
                }

            }
            VM_Agenda vm_agenda = new VM_Agenda()
            {
                ListHorasDisponibles = listData,
            };
            return PartialView("_HorariosDisponibles", vm_agenda);
        }



    }
}
