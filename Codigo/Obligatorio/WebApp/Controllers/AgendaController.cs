using BusinessLogic.Logic;
using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;

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

                    //TODO: obtener el usuario logueado
                    string userName = ((HttpContext.User).Identity).Name;

                    //Guid userId = (Guid)WebSecurity.GetUser(userName).ProviderUserKey;


                    //using(IDoctorLogic bl = new DoctorLogic)
                    //{
                    // Doctor doctor = bl.GetDoctorByUser(userId);
                    //}


                    DateTime fecha = DateTime.Now;
                    IDictionary<string, bool> horas = bl.ListHorasDisponiblesPorFecha(1, fecha);
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
            string userName = ((HttpContext.User).Identity).Name;
            var agenda = new Modelo.Models.Agenda();
            using (DataAccess.Model.Context db = new DataAccess.Model.Context())
            {
                var doctor = db.Doctores.Single(d => d.DoctorID == 1);
                agenda.Doctor = doctor;
                ViewBag.Doctor = doctor;
            }

            //ViewBag.Doctor = userName;
            using (IPacienteLogic bl = new PacienteLogic())
            {
                IEnumerable<Paciente> pacientes = bl.ListPacientes();

                ViewBag.Pacientes = pacientes;
            }

            return View();
        }

        [HttpPost]
        public ActionResult AgendarPaciente(Agenda agenda)
        {
            //bool isValid = agenda.Fecha != null && agenda.Hora != "" && agenda.Paciente.PacienteID > 0;
            //if (isValid)
            //{
            //    using (IAgendaLogic bl = new AgendaLogic())
            //    {

            //        //TODO: obtener el usuario logueado
            //        string userName = ((HttpContext.User).Identity).Name;

            //        agenda.Doctor = new Doctor() { DoctorID = 1};
            //        DateTime fecha = DateTime.Now;
            //        bl.Save(agenda);
            //    }
            //}

            return View("Index");
        }

        public Action HorasDisponibles()
        {
            return null;

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
