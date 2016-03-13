using BusinessLogic.Logic;
using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace WebApp.Controllers
{
    public class LiquidacionSueldoController : Controller
    {
        //
        // GET: /LiquidacionSueldo/

        public ActionResult Index(FormCollection form)
        {
            int month = int.Parse(form["Mes"]);
            int year = int.Parse(form["Anio"]);
            IEnumerable<LiquidacionDeSueldo> result;
            try
            {
                using (ILiquidacionSueldoLogic ls = new LiquidacionSueldoLogic())
                {
                    result = ls.GetLiquidacionesDelMesYAnio(month, year);
                }
            }
            catch (Exception)
            {
                return View("Error");
            }

            return View(result);
        }

        public void CreateLiq(FormCollection form)
        {
            int month = int.Parse(form["Mes"]);
            int year = int.Parse(form["Anio"]);
            try
            {
                using (ILiquidacionSueldoLogic ls = new LiquidacionSueldoLogic())
                {
                    ls.HacerLiquidacionesDelMesYAnio(month, year);
                }
            }
            catch (Exception)
            {
                 View("Error");
            }
            //ActionResult result = RedirectToAction("Index",form);
            //return View(result);
            Index(form);
        }


        public ActionResult ShowLiq()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }








    }
}
