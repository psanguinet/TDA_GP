using BusinessLogic.Logic;
using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.ViewModel;

namespace WebApp.Controllers
{
    public class ReporteController : Controller
    {
        //
        // GET: /Reporte/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NumeroDeConsultasMensuales()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NumeroDeConsultasMensuales(DateTime dateFrom, DateTime dateTo)
        {
            IDictionary<int, int> listado = null;
            try
            {
                using (IReporteLogic bl = new ReporteLogic())
                {
                    listado = bl.ListadoNumeroDeConsultasMensuales(dateFrom, dateTo);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(listado);
        }

        public ActionResult DoctorMasyMenosVisitado()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoctorMasyMenosVisitado(DateTime dateFrom, DateTime dateTo)
        {


            ViewModel.VM_DoctorMasYMenosVisitados vm_doctores = new ViewModel.VM_DoctorMasYMenosVisitados();
            try
            {
                using (IReporteLogic bl = new ReporteLogic())
                {
                    vm_doctores.DoctorMasVisitado = bl.DoctorMasVisitado(dateFrom, dateTo);

                    vm_doctores.DoctorMenosVisitado = bl.DoctorMenosVisitado(dateFrom, dateTo);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return PartialView("_DoctorMasMenosVisitados", vm_doctores);
        }
    }
}