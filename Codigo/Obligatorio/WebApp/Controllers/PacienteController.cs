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
    public class PacienteController : Controller
    {
        /// <summary>
        /// Listado de pacientes
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            IEnumerable<Paciente> result = new List<Paciente>();
            try
            {
                using (IPacienteLogic bl = new PacienteLogic())
                {
                    result = bl.ListPacientes();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return View(result);
        }

        /// <summary>
        /// Detalles del paciente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            Paciente paciente = null;
            try
            {
                using (IPacienteLogic bl = new PacienteLogic())
                {
                    paciente = bl.GetPaciente(id);
                }
                if (paciente == null)
                {
                    return HttpNotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return View(paciente);
        }


        public ActionResult Create()
        {
            using (IRoleLogic bl = new RoleLogic())
            {
                ViewBag.Roles = bl.ListRoles();
            }

            return View();
        }



        /// <summary>
        /// Crear nuevo paciente
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Paciente paciente, RegisterModel userRegister)
        {
            ActionResult result = null;
            try
            {
                if (ModelState.IsValid)
                {


                    using (IPacienteLogic bl = new PacienteLogic())
                    {
                        paciente.Usuario = new Modelo.Models.User()
                        {
                            UserId = Guid.NewGuid(),
                            Username = userRegister.UserName,
                            Password = userRegister.Password,
                            Email = userRegister.Email,
                            IsApproved = true,
                            PasswordFailuresSinceLastSuccess = 0,
                            IsLockedOut = false
                        };
                       
                        bl.Save(paciente);
                        Roles.AddUserToRole(userRegister.UserName, "PACIENTE");
                    }


                    result = RedirectToAction("Index");
                }
                else
                {
                    using (IRoleLogic bl = new RoleLogic())
                    {
                        ViewBag.Roles = bl.ListRoles();
                    }
                    result = View("Create", paciente);
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }
            return result;
        }

        public ActionResult Edit(int id)
        {
            Paciente result = null;
            try
            {
                if (id != null)
                {
                    using (IPacienteLogic bl = new PacienteLogic())
                    {
                        result = bl.GetPaciente(id);
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
        public ActionResult Edit(Paciente paciente)
        {
            ActionResult result = null;
            try
            {
                if (ModelState.IsValid)
                {
                    using (IPacienteLogic bl = new PacienteLogic())
                    {
                        bl.Edit(paciente);
                    }
                    result = RedirectToAction("Index");
                }
                else
                {
                    result = View(paciente);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }


        public ActionResult Delete(int id)
        {
            Paciente result = null;
            try
            {
                if (id != null)
                {
                    using (IPacienteLogic bl = new PacienteLogic())
                    {
                        result = bl.GetPaciente(id);
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
        public ActionResult DeleteConfirmed(int id)
        {
            ActionResult result = null;
            try
            {
                if (ModelState.IsValid)
                {
                    using (IPacienteLogic bl = new PacienteLogic())
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
