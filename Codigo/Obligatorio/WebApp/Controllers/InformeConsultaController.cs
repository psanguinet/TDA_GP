using BusinessLogic.Logic;
using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{

    public class InformeConsultaController : Controller
    {
        [Authorize(Roles = "DOCTOR")]
        public ActionResult Index()
        {
            IEnumerable<InformesDeConsulta> result = new List<InformesDeConsulta>();
            try
            {
                using (IInformeDeConsultaLogic bl = new InformeDeConsultaLogic())
                {
                    using (DataAccess.Model.Context db = new DataAccess.Model.Context())
                    {
                        string userName = ((HttpContext.User).Identity).Name;
                        var doc = db.Doctores.Include("Usuario").SingleOrDefault(d => d.Usuario.Username == userName);
                        result = bl.ListInformeDeConsultas(doc);
                    }
                }
            }
            catch (Exception e)
            {
                return View("Error");
            }
            return View(result);
        }
        [Authorize(Roles = "DOCTOR")]
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

                    ViewBag.ImageDataPaciente = Helper.HelperImage.ImagesConvert(agenda.Paciente.Foto);

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
                return View("Error");
            }
            return View("Create", informeConsulta);
        }

        [Authorize(Roles = "DOCTOR")]
        [HttpPost]
        public ActionResult Create(InformesDeConsulta informeConsulta)
        {

            try
            {
                if (ModelState.IsValid)
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
                return View("Error");
            }
            return RedirectToAction("Index", "Agenda");
        }

        [Authorize(Roles = "DOCTOR")]
        public ActionResult Edit(int id)
        {
            InformesDeConsulta informeDeConsulta = null;
            try
            {
                if (id != null)
                {
                    using (IInformeDeConsultaLogic bl = new InformeDeConsultaLogic())
                    {
                        informeDeConsulta = bl.GetInformeDeConsulta(id);
                        ViewBag.ImageDataPaciente = Helper.HelperImage.ImagesConvert(informeDeConsulta.Paciente.Foto);
                    }
                }
                if (informeDeConsulta == null)
                {
                    return HttpNotFound();
                }
            }
            catch (Exception e)
            {
                return View("Error");
            }
            return View(informeDeConsulta);
        }

        [Authorize(Roles = "DOCTOR")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InformesDeConsulta informeDeConsulta)
        {
            ActionResult result = null;
            try
            {
                if (ModelState.IsValid)
                {
                    using (IInformeDeConsultaLogic bl = new InformeDeConsultaLogic())
                    {
                        bl.Edit(informeDeConsulta);
                    }
                    result = RedirectToAction("Index");
                }
                else
                {
                    result = View(informeDeConsulta);
                }
            }
            catch (Exception e)
            {

                return View("Error");
            }
            return result;
        }

        public ActionResult Details(int id)
        {
            InformesDeConsulta informeDeConsulta = null;
            try
            {
                if (id != null)
                {
                    using (IInformeDeConsultaLogic bl = new InformeDeConsultaLogic())
                    {
                        informeDeConsulta = bl.GetInformeDeConsulta(id);
                        ViewBag.ImageDataPaciente = Helper.HelperImage.ImagesConvert(informeDeConsulta.Paciente.Foto);
                    }
                }
                if (informeDeConsulta == null)
                {
                    return HttpNotFound();
                }
            }
            catch (Exception e)
            {
                return View("Error");
            }
            return View(informeDeConsulta);
        }

        [Authorize(Roles = "DOCTOR")]
        public ActionResult Delete(int id)
        {
            InformesDeConsulta informeDeConsulta = null;
            try
            {
                if (id != null)
                {
                    using (IInformeDeConsultaLogic bl = new InformeDeConsultaLogic())
                    {
                        informeDeConsulta = bl.GetInformeDeConsulta(id);
                        ViewBag.ImageDataPaciente = Helper.HelperImage.ImagesConvert(informeDeConsulta.Paciente.Foto);
                    }
                }
            }
            catch (Exception e)
            {

                return View("Error");
            }
            return View(informeDeConsulta);
        }
        [Authorize(Roles = "DOCTOR")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActionResult result = null;
            try
            {
                if (ModelState.IsValid)
                {
                    using (IInformeDeConsultaLogic bl = new InformeDeConsultaLogic())
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