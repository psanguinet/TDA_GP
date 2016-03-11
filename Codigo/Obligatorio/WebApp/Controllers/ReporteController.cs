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
    [Authorize(Roles = "DIRECTOR")]
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
            VM_Reportes vm_reportes = new VM_Reportes();
            return View(vm_reportes);
        }

        [HttpPost]
        public ActionResult NumeroDeConsultasMensuales(DateTime dateFrom, DateTime dateTo)
        {
            VM_Reportes vm_reportes = new VM_Reportes();
            try
            {
                using (IReporteLogic bl = new ReporteLogic())
                {
                    vm_reportes.ListadoNumeroDeConsultasMensuales = bl.ListadoNumeroDeConsultasMensuales(dateFrom, dateTo);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return PartialView("_NumeroDeConsultasMensuales", vm_reportes);
        }

        public ActionResult DoctorMasyMenosVisitado()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoctorMasyMenosVisitado(DateTime dateFrom, DateTime dateTo)
        {


            ViewModel.VM_Reportes vm_doctores = new ViewModel.VM_Reportes();
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