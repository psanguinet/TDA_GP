using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Model;


namespace DataAccess.Model
{
    [Authorize(Roles="Doctor")]
    public class PersonaController : Controller
    {

        Context db = new Context();
        //
        // GET: /Persona/

        public ActionResult Index()
        {
            var personas = db.Personas.Include(p => p.Usuario);
            return View(personas.ToList());
        }

        //
        // GET: /Persona/Details/5

        public ActionResult Details(int id = 0)
        {
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        //
        // GET: /Persona/Create

        public ActionResult Create()
        {
            ViewBag.UsuarioID = new SelectList(db.Users, "UsuarioID", "NombreUsuario");
            return View();
        }

        //
        // POST: /Persona/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Personas.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioID = new SelectList(db.Users, "UsuarioID", "NombreUsuario", persona.UsuarioID);
            return View(persona);
        }

        //
        // GET: /Persona/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioID = new SelectList(db.Users, "UsuarioID", "NombreUsuario", persona.UsuarioID);
            return View(persona);
        }

        //
        // POST: /Persona/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioID = new SelectList(db.Users, "UsuarioID", "NombreUsuario", persona.UsuarioID);
            return View(persona);
        }

        //
        // GET: /Persona/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        //
        // POST: /Persona/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = db.Personas.Find(id);
            db.Personas.Remove(persona);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}