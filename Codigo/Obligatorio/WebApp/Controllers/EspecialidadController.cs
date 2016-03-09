using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Logic;
using Modelo.Models;

namespace WebApp.Controllers
{
    public class EspecialidadController : Controller
    {

        /// <summary>
        /// Listado de Especialidades
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            IEnumerable<Especialidad> result = new List<Especialidad>();
            try
            {
                using (IEspecialidadLogic bl = new EspecialidadLogic())
                {
                    result = bl.ListEspecialidades();
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
            return View(result);
        }


        /// <summary>
        /// Detalles del Especialidades
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            Especialidad especialidad = null;
            try
            {
                using (IEspecialidadLogic bl = new EspecialidadLogic())
                {
                    especialidad = bl.GetEspecialidad(id);
                }
                if (especialidad == null)
                {
                    return HttpNotFound();
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
            return View(especialidad);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Especialidad especialidad)
        {
            ActionResult result = null;
            try
            {
                if (ModelState.IsValid)
                {
                    using (IEspecialidadLogic bl = new EspecialidadLogic())
                    {
                        bl.Save(especialidad);
                    }
                    result = RedirectToAction("Index");
                }
                else
                {
                    result = View(especialidad);
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
            return result;
        }

        public ActionResult Edit(int id)
        {
            Especialidad result = null;
            try
            {
                if (id != null)
                {
                    using (IEspecialidadLogic bl = new EspecialidadLogic())
                    {
                        result = bl.GetEspecialidad(id);
                    }
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Especialidad especialidad)
        {
            ActionResult result = null;
            try
            {
                if (ModelState.IsValid)
                {
                    using (IEspecialidadLogic bl = new EspecialidadLogic())
                    {
                        bl.Edit(especialidad);
                    }
                    result = RedirectToAction("Index");
                }
                else
                {
                    result = View(especialidad);
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
            return result;
        }


        public ActionResult Delete(int id)
        {
            Especialidad result = null;
            try
            {
                if (id != null)
                {
                    using (IEspecialidadLogic bl = new EspecialidadLogic())
                    {
                        result = bl.GetEspecialidad(id);
                    }
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
            return View(result);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActionResult result = null;
            try
            {
                if (ModelState.IsValid)
                {
                    using (IEspecialidadLogic bl = new EspecialidadLogic())
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
            catch (Exception)
            {
                return View("Error");
            }
            return result;
        }
    }
}
