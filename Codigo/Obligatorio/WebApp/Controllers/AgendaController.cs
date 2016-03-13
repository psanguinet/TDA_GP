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
                using (IAgendaLogic bl = new AgendaLogic())
                {
                    //TODO: CAMBIAR DE DATA ACCESS A BUSINESS
                    using (DataAccess.Model.Context db = new DataAccess.Model.Context())
                    {
                        string userName = ((HttpContext.User).Identity).Name;
                        var doc = db.Doctores.Include("Usuario").SingleOrDefault(d => d.Usuario.Username == userName);
                        DateTime fecha = DateTime.Now;

                    }
                    result = bl.ListAgendaByDoctor(1);
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
            Doctor doc = null;
            VM_Agenda vm_agenda = null;

            using (DataAccess.Model.Context db = new DataAccess.Model.Context())
            {
                string userName = ((HttpContext.User).Identity).Name;
                //TODO: CAMBIAR DE DATA ACCESS A BUSINESS
                doc = db.Doctores.Include("Usuario").SingleOrDefault(d => d.Usuario.Username == userName);
                ViewBag.DoctorNombre = doc.Nombre + " " + doc.Apellido;
            }

            using (IPacienteLogic bl = new PacienteLogic())
            {
                IEnumerable<Paciente> pacientes = bl.ListPacientes();
                ViewBag.Pacientes = pacientes;
            }

            using (IAgendaLogic bl = new AgendaLogic())
            {
                vm_agenda = new VM_Agenda();
                vm_agenda.ListHorasDisponibles = bl.ListHorasDisponiblesPorFecha(doc.DoctorID, DateTime.Now);
            }
            return View(vm_agenda);
        }

        [HttpPost]
        public ActionResult AgendarPaciente(VM_Agenda vm_agenda)
        {

            using (IAgendaLogic bl = new AgendaLogic())
            {

                using (DataAccess.Model.Context db = new DataAccess.Model.Context())
                {
                    string userName = ((HttpContext.User).Identity).Name;
                    db.Configuration.ProxyCreationEnabled = false;
                    db.Configuration.LazyLoadingEnabled = false;
                    var doc = db.Doctores.Include("Usuario").SingleOrDefault(d => d.Usuario.Username == userName);

                    var paciente = db.Pacientes.Single(p => p.PacienteID == vm_agenda.PacienteID);
                    Agenda agenda = new Agenda()
                    {
                        Doctor = doc,
                        Fecha = vm_agenda.Agenda.Fecha,
                        Hora = vm_agenda.Agenda.Hora,
                        Descripcion = vm_agenda.Agenda.Descripcion,
                        Paciente = paciente,
                    };

                    bl.Save(agenda);
                }

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
                    ViewBag.ImageData = Helper.HelperImage.ImagesConvert(agenda.Paciente.Foto);
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
                        ViewBag.ImageData = Helper.HelperImage.ImagesConvert(result.Paciente.Foto);
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
        public Action HorasDisponibles()
        {
            return null;

        }

        public ActionResult BuscarHorarios(string date)
        {
            IDictionary<string, bool> listData = null;
            //checking the query parameter sent from view. If it is null we will return null else we will return list based on query.
            string result = string.Empty;
            if (!string.IsNullOrEmpty(date))
            {
                DateTime fecha = DateTime.ParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                //TODO: CAMBIAR DE DATA ACCESS A BUSINESS
                using (DataAccess.Model.Context db = new DataAccess.Model.Context())
                {
                    string userName = ((HttpContext.User).Identity).Name;
                    var doc = db.Doctores.Include("Usuario").SingleOrDefault(d => d.Usuario.Username == userName);
                    using (IAgendaLogic bl = new AgendaLogic())
                    {

                        listData = bl.ListHorasDisponiblesPorFecha(doc.DoctorID, fecha);
                    }
                }
            }
            VM_Agenda vm_agenda = new VM_Agenda()
            {
                ListHorasDisponibles = listData,
            };
            return PartialView("_HorariosDisponibles", vm_agenda);
        }

        public ActionResult BuscarPaciente(string query)
        {
            List<string> listData = null;
            //checking the query parameter sent from view. If it is null we will return null else we will return list based on query.
            if (!string.IsNullOrEmpty(query))
            {
                //Created an array of players. We can fetch this from database as well.
                string[] arrayData = new string[] { "Fabregas", "Messi", "Ronaldo", "Ronaldinho", "Goetze", "Cazorla", "Henry", "Luiz", "Reus", "Neur", "Podolski" };

                //Using Linq to query the result from an array matching letter entered in textbox.
                listData = arrayData.Where(q => q.ToLower().Contains(query.ToLower())).ToList();
            }

            //Returning the matched list as json data.
            return Json(new { Data = listData });
        }

    }
}
