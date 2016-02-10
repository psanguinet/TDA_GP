using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess.Model;

namespace WebClinicaMedica.Controllers
{
    public partial class DoctorController : Controller
    {
        private ClinicaMedicaEntities db = new ClinicaMedicaEntities();

        // GET: /Doctor/
        public virtual ActionResult Index()
        {
            var doctor = db.Doctor.Include(d => d.Usuario);
            return View(doctor.ToList());
        }

        // GET: /Doctor/Details/5
        public virtual ActionResult Details(int? id)
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

        // GET: /Doctor/Create
        public virtual ActionResult Create()
        {
            ViewBag.Especialidades = db.Especialidad.OrderBy(e => e.Nombre).ToList();
            return View();
        }

        // POST: /Doctor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create([Bind(Include = "DoctorID,Nombre,Apellido,CI,Foto,Direccion,Telefono,ValorConsulta,SueldoMinimo,IsDirector,UsuarioID,Active")] Doctor doctor, Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Doctor.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "UserName", doctor.UsuarioID);
            return View(doctor);
        }

        // GET: /Doctor/Edit/5
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

        // POST: /Doctor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: /Doctor/Delete/5
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

        // POST: /Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = db.Doctor.Find(id);
            db.Doctor.Remove(doctor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
