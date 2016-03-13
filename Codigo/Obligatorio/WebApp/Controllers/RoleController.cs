using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Logic;
using Modelo.Models;

namespace WebApp.Controllers

{
     [Authorize(Roles = "DIRECTOR")]
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
                using (IRoleLogic bl = new RoleLogic())
                {
                    result = bl.ListRoles();
                }
            }
            catch (Exception)
            {
                return View("Error");
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
                using (IRoleLogic bl = new RoleLogic())
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
                return View("Error");
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
                    using (IRoleLogic bl = new RoleLogic())
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
                return View("Error");
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
                    using (IRoleLogic bl = new RoleLogic())
                    {
                       result= bl.GetRol(id);
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
        public ActionResult Edit(Role role)
        {
            ActionResult result = null;
            try
            {
                if (ModelState.IsValid)
                {
                    using (IRoleLogic bl = new RoleLogic())
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
                return View("Error");
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
                    using (IRoleLogic bl = new RoleLogic())
                    {
                        result = bl.GetRol(id);
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
        public ActionResult DeleteConfirmed(Guid id)
        {
            ActionResult result = null;
            try
            {
                if (ModelState.IsValid)
                {
                    using (IRoleLogic bl = new RoleLogic())
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
