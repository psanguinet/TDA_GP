using BusinessLogic.Logic;
using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace WebApp.Controllers
{
    [Authorize(Roles = "DIRECTOR")]
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
                return View("Error");
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

                    if (paciente.Foto != null)
                    {
                        string imageBase64Data = Convert.ToBase64String(paciente.Foto.ToArray());
                        string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                        ViewBag.ImageData = imageDataURL;

                    }
                }
                if (paciente == null)
                {
                    return HttpNotFound();
                }
            }
            catch (Exception)
            {
                return View("Error");
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
                        if (!bl.UserExist(paciente.Usuario))
                        {
                            bl.Save(paciente);
                            Roles.AddUserToRole(userRegister.UserName, "PACIENTE");
                        }
                        else
                        {
                            return View("Error");
                        }

                    }
                    result = RedirectToAction("Index");
                }
                else
                {
                    result = View("Create", paciente);
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
            return result;
        }

        /// <summary>
        /// Invoca a vista de edicion de paciente con el paciente id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                        var user = new RegisterModel()
                        {
                            UserName = result.Usuario.Username,
                            Password = result.Usuario.Password,
                            Email = result.Usuario.Email,
                            ConfirmPassword = result.Usuario.Password,
                        };
                        ViewBag.User = user;
                        if (result.Foto != null)
                        {
                            string imageBase64Data = Convert.ToBase64String(result.Foto.ToArray());
                            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                            ViewBag.ImageData = imageDataURL;

                        }

                    }
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
            return View(result);
        }

        /// <summary>
        /// Guarda el paciente modificado
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Paciente paciente, RegisterModel userRegister)
        {
            ActionResult result = null;
            try
            {
                if (ModelState.IsValid)
                {
                    using (IPacienteLogic bl = new PacienteLogic())
                    {
                        paciente.Usuario.Email = (userRegister.Email != null || userRegister.Email != "") ? userRegister.Email : paciente.Usuario.Email;
                        paciente.Usuario.Password = (paciente.Usuario.Password != userRegister.Password) ? userRegister.Password : paciente.Usuario.Password;

                        bl.Edit(paciente);


                    }
                    result = RedirectToAction("Index");
                }
                else
                {
                    result = View(paciente);
                }
            }
            catch (Exception e)
            {
                return View("Error");

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
            catch (Exception e)
            {
                return View("Error");
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
            catch (Exception e)
            {
                return View("Error");
            }
            return result;
        }

        [HttpPost]
        public ActionResult Upload(string id)
        {
            byte[] imageByteData = null;
            try
            {

                if (Request.Files.Count > 0 && id != null)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        string path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                        file.SaveAs(path);

                        imageByteData = System.IO.File.ReadAllBytes(path);
                        using (IPacienteLogic bl = new PacienteLogic())
                        {
                           Paciente paciente = bl.GetPaciente(int.Parse(id));
                           paciente.Foto = imageByteData;
                           bl.Edit(paciente);
                        }

                        string imageBase64Data = Convert.ToBase64String(imageByteData);
                        string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                        ViewBag.ImageData = imageDataURL;
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }

            string respuesta = (imageByteData.Length > 0) ? respuesta = "Imagen subida correctamente" : respuesta = "Error";
            return PartialView("_FileUpload", respuesta);
        }

    }

}
