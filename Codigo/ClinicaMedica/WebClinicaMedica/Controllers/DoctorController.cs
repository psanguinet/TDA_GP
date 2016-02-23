using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess.Model;
using System.IO;
using WebClinicaMedica.Models;


namespace WebClinicaMedica.Controllers
{
    [Helper.AccessValidation]
    public partial class DoctorController : Controller
    {
        #region ATTRIBUTES

        private ClinicaMedicaEntities db = new ClinicaMedicaEntities();
        #endregion

        #region METHODS
        /// <summary>
        /// Muestra el listado de doctores
        /// </summary>
        /// <returns>Retorna el listado de doctores</returns>
        public virtual ActionResult Index()
        {
            List<Doctor> doctores = null;
            try
            {
                doctores = db.Doctor.Include(d => d.Usuario).ToList();
            }
            catch (Exception e)
            {
                return View(MVC.Dialogs.Views.DialogMessageError, new MessageDialog() { Titulo = "Error", Mensaje = "Se produjo un error al mostrar el listado de doctores" });
            }

            return View(doctores);
        }

        /// <summary>
        /// Muestra el detalle de un doctor
        /// </summary>
        /// <param name="id">id que identifica al doctor</param>
        /// <returns>La vista con los detalles del doctor</returns>
        public virtual ActionResult Details(int? id)
        {
            Doctor doctor = null;
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                doctor = db.Doctor.Find(id);
                if (doctor == null)
                {
                    return View(MVC.Dialogs.Views.DialogMessageError, new MessageDialog() { Titulo = "Error", Mensaje = "El doctor no existe" });
                }
            }
            catch (Exception e)
            {
                return View(MVC.Dialogs.Views.DialogMessageError, new MessageDialog() { Titulo = "Error", Mensaje = "Se produjo un error al mostrar el doctor" });
            }

            return View(doctor);
        }

       /// <summary>
       /// Llama a al vista de creacion del doctor
       /// </summary>
       /// <returns></returns>
        public virtual ActionResult Create()
        {
            var especialidades = db.Especialidad.OrderBy(e => e.Nombre).ToList();
            List<VM_Especialidad> especialidadesVM = new List<VM_Especialidad>();

            foreach (var item in especialidades)
            {
                VM_Especialidad e = new VM_Especialidad()
                {
                    Especialidad = item,
                    Activa = false
                };
                especialidadesVM.Add(e);
            }

            //Se pasan especialidades
            ViewBag.Especialidades = especialidadesVM;

            //Se le pasa el rol de doctor
            ViewBag.Roles = db.Rol.Where(r => r.Nombre == "Doctor").ToList();
            return View();
        }

        /// <summary>
        /// Crea un nuevo doctor
        /// </summary>
        /// <param name="doctor"></param>
        /// <param name="usuario"></param>
        /// <param name="frm"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create([Bind(Include = "DoctorID,Nombre,Apellido,CI,Foto,Direccion,Telefono,ValorConsulta,SueldoMinimo,IsDirector,UsuarioID,Active")] Doctor doctor, Usuario usuario, FormCollection frm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    doctor.Usuario = usuario;
                    AsignarRelacionDoctorEspecialidad(doctor, frm);
                    db.Doctor.Add(doctor);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return View(MVC.Dialogs.Views.DialogMessageError, new MessageDialog() { Titulo = "Error", Mensaje = "Se produjo un error al guardar el doctor." });
            }
            return RedirectToAction("Index");

        }

        /// <summary>
        /// Llama a la vista de edicion del doctor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctor.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "UserName", doctor.UsuarioID);
            return View(doctor);
        }

        /// <summary>
        /// Edita un doctor.
        /// </summary>
        /// <param name="doctor"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit([Bind(Include = "DoctorID,Nombre,Apellido,CI,Foto,Direccion,Telefono,ValorConsulta,SueldoMinimo,IsDirector,UsuarioID,Active")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "UserName", doctor.UsuarioID);
            return View(doctor);
        }

        /// <summary>
        /// LLama a la vista del doctor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctor.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        /// <summary>
        /// Borra un Doctor. El borrado fisico es solo si no tiene consultas o si tiene liquidaciones realizadas
        /// </summary>
        /// <param name="id">Numero que identifica al doctor</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = db.Doctor.Find(id);
            db.Doctor.Remove(doctor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public virtual ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images/profile"), pic);
                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }
            // after successfully uploading redirect the user
            return RedirectToAction("actionname", "controller name");
        }

        /// <summary>
        /// Asigna a un doctor un conjunto de especialidades
        /// </summary>
        /// <param name="doctor">Doctor al que se le asigna las especialidades</param>
        /// <param name="frm">Especialidades seleccionadas</param>
        private void AsignarRelacionDoctorEspecialidad(Doctor doctor, FormCollection frm)
        {
            try
            {
                // Se declara el objecto correspondiente a la tabla relación
                Especialidad especialidad = null;

                // Se obtienen las claves asociadas a los controles check con los que queremos trabajar.
                List<string> chkKeys = frm.AllKeys.Where(p => p.StartsWith("chkDoctor_Especialidad_")).ToList();

                foreach (string key in chkKeys)
                {
                    // Se obtiene el ID del objeto relacionado seleccionado a partir de la key
                    // En la vista se arma el nombre del check de la forma nombreDelCheck_IDdelObjeto
                    string[] chkNameArray = key.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                    int IDEspecialidad = int.Parse(chkNameArray.Last());

                    // Si es TRUE (si está chequeado) se agrega la asociación
                    if (this.HttpContext.Request.Params[key] != "false")
                    {
                        especialidad = db.Especialidad.Single(c => c.EspecialidadID == IDEspecialidad);
                        doctor.Especialidad.Add(especialidad);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
          
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}
