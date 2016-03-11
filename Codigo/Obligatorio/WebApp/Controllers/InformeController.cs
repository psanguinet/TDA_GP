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
        public ActionResult InformeConsultaExtenso()
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
        public ActionResult InformeAnalisisClinicoReducido()
        {
            return View();
        }
        public ActionResult InformeAnalisisClinicoExtenso()
        {
            return View();
        }
        
        
	}
}