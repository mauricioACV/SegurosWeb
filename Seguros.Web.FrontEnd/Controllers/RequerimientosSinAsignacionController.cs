using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Seguros.Web.FrontEnd.Models;

namespace Seguros.Web.FrontEnd.Controllers
{
    public class RequerimientosSinAsignacionController : Controller
    {
        private SegurosDbContext db = new SegurosDbContext();

        // GET: RequerimientosSinAsignacion
        public ActionResult Index()
        {
            return View(db.Requerimiento.ToList());
        }

        // GET: RequerimientosSinAsignacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requerimiento requerimiento = db.Requerimiento.Find(id);
            if (requerimiento == null)
            {
                return HttpNotFound();
            }
            return View(requerimiento);
        }

        // GET: RequerimientosSinAsignacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RequerimientosSinAsignacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha_req,Fecha_limit_req,Fecha_fin_real")] Requerimiento requerimiento)
        {
            if (ModelState.IsValid)
            {
                db.Requerimiento.Add(requerimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(requerimiento);
        }

        // GET: RequerimientosSinAsignacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requerimiento requerimiento = db.Requerimiento.Find(id);
            if (requerimiento == null)
            {
                return HttpNotFound();
            }
            return View(requerimiento);
        }

        // POST: RequerimientosSinAsignacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha_req,Fecha_limit_req,Fecha_fin_real")] Requerimiento requerimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requerimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(requerimiento);
        }

        // GET: RequerimientosSinAsignacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requerimiento requerimiento = db.Requerimiento.Find(id);
            if (requerimiento == null)
            {
                return HttpNotFound();
            }
            return View(requerimiento);
        }

        // POST: RequerimientosSinAsignacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Requerimiento requerimiento = db.Requerimiento.Find(id);
            db.Requerimiento.Remove(requerimiento);
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
