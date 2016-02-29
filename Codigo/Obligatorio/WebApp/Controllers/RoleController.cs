using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Logic;
using Modelo.Models;

namespace WebApp.Controllers
{
    public class RoleController : Controller
    {

        /// <summary>
        /// Listado de Roles
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            IEnumerable<Role> result = new List<Role>();
            try
            {
                using (RoleLogic bl = new RoleLogic())
                {
                    result = bl.ListRoles();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return View(result);
        }

        /// <summary>
        /// Detalles del rol
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(Guid id)
        {
            Role rol = null;
            try
            {
                using (RoleLogic bl = new RoleLogic())
                {
                    rol = bl.GetRol(id);
                }
                if (rol == null)
                {
                    return HttpNotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return View(rol);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Role role)
        {
            ActionResult result = null;
            try
            {
                if (ModelState.IsValid)
                {
                    using (RoleLogic bl = new RoleLogic())
                    {
                        bl.Save(role);
                    }
                    result = RedirectToAction("Index");
                }
                else
                {
                    result = View(role);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public ActionResult Edit(Guid id)
        {
            Role result = null;
            try
            {
                if (id != null)
                {
                    using (RoleLogic bl = new RoleLogic())
                    {
                       result= bl.GetRol(id);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Role role)
        {
            ActionResult result = null;
            try
            {
                if (ModelState.IsValid)
                {
                    using (RoleLogic bl = new RoleLogic())
                    {
                        bl.Edit(role);
                    }
                    result = RedirectToAction("Index");
                }
                else
                {
                    result = View(role);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }


        public ActionResult Delete(Guid id)
        {
            Role result = null;
            try
            {
                if (id != null)
                {
                    using (RoleLogic bl = new RoleLogic())
                    {
                        result = bl.GetRol(id);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(result);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ActionResult result = null;
            try
            {
                if (ModelState.IsValid)
                {
                    using (RoleLogic bl = new RoleLogic())
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

                throw;
            }
            return result;
        }
    }
}
