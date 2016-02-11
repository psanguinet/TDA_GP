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
    public partial class EspecialidadController : Controller
    {
        private ClinicaMedicaEntities db = new ClinicaMedicaEntities();

        // GET: /Especialidad/
        public virtual ActionResult Index()
        {
            return View(db.Especialidad.ToList());
        }

        // GET: /Especialidad/Details/5
        public virtual ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidad especialidad = db.Especialidad.Find(id);
            if (especialidad == null)
            {
                return HttpNotFound();
            }
            return View(especialidad);
        }

        // GET: /Especialidad/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: /Especialidad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create([Bind(Include = "EspecialidadID,Nombre,Descripcion,Active")] Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                db.Especialidad.Add(especialidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especialidad);
        }

        // GET: /Especialidad/Edit/5
        public virtual ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidad especialidad = db.Especialidad.Find(id);
            if (especialidad == null)
            {
                return HttpNotFound();
            }
            return View(especialidad);
        }

        // POST: /Especialidad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit([Bind(Include = "EspecialidadID,Nombre,Descripcion,Active")] Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especialidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(especialidad);
        }

        // GET: /Especialidad/Delete/5
        public virtual ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidad especialidad = db.Especialidad.Find(id);
            if (especialidad == null)
            {
                return HttpNotFound();
            }
            return View(especialidad);
        }

        // POST: /Especialidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            Especialidad especialidad = db.Especialidad.Find(id);
            db.Especialidad.Remove(especialidad);
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
