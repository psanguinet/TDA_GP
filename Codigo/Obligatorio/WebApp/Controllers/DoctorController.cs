using BusinessLogic.Logic;
using Modelo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApp.Controllers
{
    public class DoctorController : Controller
    {
        /// <summary>
        /// Listado de doctores
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            IEnumerable<Doctor> result = new List<Doctor>();
            try
            {
                using (IDoctorLogic bl = new DoctorLogic())
                {
                    result = bl.ListDoctores();
                }
            }
            catch (Exception e)
            {
                return View("Error");
            }
            return View(result);
        }

        /// <summary>
        /// Detalles del doctor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            Doctor doctor = null;
            try
            {
                using (IDoctorLogic dl = new DoctorLogic())
                {
                    ViewBag.Especialidades = dl.GetDoctor(id).ListEspecialidades;
                }
                using (IDoctorLogic bl = new DoctorLogic())
                {
                    doctor = bl.GetDoctor(id);
                    ViewBag.ImageDataDoctor = Helper.HelperImage.ImagesConvert(doctor.Foto);
                }
                if (doctor == null)
                {
                    return HttpNotFound();
                }
            }
            catch (Exception e)
            {
                return View("Error");
            }
            return View(doctor);
        }


        public ActionResult Create()
        {
            using (IEspecialidadLogic bl = new EspecialidadLogic())
            {
                ViewBag.Especialidades = bl.ListEspecialidades();
            }
            return View();
        }



        /// <summary>
        /// Crear nuevo doctor
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Doctor doctor, RegisterModel userRegister,FormCollection form)
        {

            //s1.raw value  stringvalues  2 y 3
            string[] especialidades = form.GetValues(10);


            ActionResult result = null;
            try
            {
                if (ModelState.IsValid)
                {

                    using (IDoctorLogic bl = new DoctorLogic())
                    {
                        doctor.Usuario = new Modelo.Models.User()
                        {
                            UserId = Guid.NewGuid(),
                            Username = userRegister.UserName,
                            Password = userRegister.Password,
                            Email = userRegister.Email,
                            IsApproved = true,
                            PasswordFailuresSinceLastSuccess = 0,
                            IsLockedOut = false
                        };
                        if (!bl.UserExist(doctor.Usuario))
                        {
                            List<Especialidad> especialidadesToAdd = new List<Especialidad>();
                            using (IEspecialidadLogic el = new EspecialidadLogic())
                            {

                                for (int i = 0; i < especialidades.Length; i++)
                                {
                                    especialidadesToAdd.Add(el.GetEspecialidad(int.Parse(especialidades[i])));
                                }

                                doctor.ListEspecialidades = especialidadesToAdd;
                                bl.Save(doctor);
                                Roles.AddUserToRole(userRegister.UserName, "DOCTOR");

                            }
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
                    result = View("Create", doctor);
                }
            }
            catch (Exception e)
            {
                return View("Error");
            }
            return result;
        }

        /// <summary>
        /// Invoca a vista de edicion de doctor con el doctor id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            Doctor doctor = null;
            try
            {
                if (id != null)
                {
                    using (IDoctorLogic bl = new DoctorLogic())
                    {
                        doctor = bl.GetDoctor(id);
                        ViewBag.ImageDataDoctor = Helper.HelperImage.ImagesConvert(doctor.Foto);
                        var user = new RegisterModel()
                        {
                            UserName = doctor.Usuario.Username,
                            Password = doctor.Usuario.Password,
                            Email = doctor.Usuario.Email,
                            ConfirmPassword = doctor.Usuario.Password,
                        };
                        
                        ViewBag.User = user;
                    }
                    using (IEspecialidadLogic el = new EspecialidadLogic())
                    {
                        ViewBag.Especialidades = el.ListEspecialidades();
                    }
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
            return View(doctor);
        }

        /// <summary>
        /// Guarda el doctor modificado
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Doctor doctor, RegisterModel userRegister, FormCollection form)
        {
           
            ActionResult result = null;
            try
            {
                if (ModelState.IsValid)
                {
                    using (IDoctorLogic bl = new DoctorLogic())
                    {
                        doctor.Usuario.Email = (userRegister.Email != null || userRegister.Email != "") ? userRegister.Email : doctor.Usuario.Email;
                        doctor.Usuario.Password = (doctor.Usuario.Password != userRegister.Password) ? userRegister.Password : doctor.Usuario.Password;

                        List<string> chkKeys = form.AllKeys.Where(p => p.StartsWith("chkDoctor_Especialidad_")).ToList();
                        List<Especialidad> especialidadesToAdd = new List<Especialidad>();
                        using (IEspecialidadLogic el = new EspecialidadLogic())
                        {

                            foreach (string key in chkKeys)
                            {
                                string[] chkNameArray = key.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                                int IDEspecilidad = int.Parse(chkNameArray.Last());
                                if (this.HttpContext.Request.Params[key] != "false")
                                {
                                    especialidadesToAdd.Add(el.GetEspecialidad(IDEspecilidad));
                                }
                                
                            }

                            doctor.ListEspecialidades = especialidadesToAdd;
                            
                            bl.Edit(doctor);
                        }
                    }
                    result = RedirectToAction("Index");
                }
                else
                {
                    result = View(doctor);
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
            Doctor result = null;
            try
            {
                if (id != null)
                {
                    using (IDoctorLogic bl = new DoctorLogic())
                    {
                        result = bl.GetDoctor(id);
                        ViewBag.ImageDataDoctor = Helper.HelperImage.ImagesConvert(result.Foto);
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
                    using (IDoctorLogic bl = new DoctorLogic())
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

        private List<int> parseIntoInt(string especialidades)
        {
            List<int> especialidadesList = new List<int>();
            especialidadesList = especialidades.Split(',').Select(Int32.Parse).ToList();
            return especialidadesList;
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
                        using (IDoctorLogic bl = new DoctorLogic())
                        {
                            Doctor doctor = bl.GetDoctor(int.Parse(id));
                            doctor.Foto = imageByteData;
                            bl.Edit(doctor);
                        }

                        string imageBase64Data = Convert.ToBase64String(imageByteData);
                        string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                        ViewBag.ImageDataDoctor = imageDataURL;
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
