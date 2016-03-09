using BusinessLogic.Logic;
using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class InformeConsultaController : Controller
    {
        
        public ActionResult InformeConsulta(int agendaID)
        {
            InformesDeConsulta informeConsulta = null;
            try
            {
                informeConsulta = new InformesDeConsulta();
                using (IAgendaLogic bl = new AgendaLogic())
                {
                    Agenda agenda = bl.GetAgendaItem(agendaID);
                    informeConsulta.Paciente = agenda.Paciente;
                    using (DataAccess.Model.Context db = new DataAccess.Model.Context())
                    {
                        string userName = ((HttpContext.User).Identity).Name;
                        db.Configuration.ProxyCreationEnabled = false;
                        db.Configuration.LazyLoadingEnabled = false;
                        var doc = db.Doctores.Include("Usuario").SingleOrDefault(d => d.Usuario.Username == userName);
                        informeConsulta.Doctor = doc;
                        informeConsulta.Motivo = agenda.Descripcion;
                    }

                }

            }
            catch (Exception e)
            {
                throw;
            }
            return View("Create", informeConsulta);
        }

        [HttpPost]
        public ActionResult Create(InformesDeConsulta informeConsulta)
        {

            try
            {
                if(ModelState.IsValid)
                {
                    using (IInformeDeConsultaLogic bl = new InformeDeConsultaLogic())
                    {
                        informeConsulta.Fecha = DateTime.UtcNow;
                        bl.Save(informeConsulta);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", "Agenda");
        }
    }


}