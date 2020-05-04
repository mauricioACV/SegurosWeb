﻿using System;
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
    public class RequerimientosController : Controller
    {
        private SegurosDbContext db = new SegurosDbContext();


        private List<Empleado> FindListEmpleados()
        {
            List<Empleado> list = db.Empleado.ToList();
            list.ForEach(e => {
                e.Nombre = e.Nombre + " " + e.ApellidoPat + " " + e.ApellidoMat;
            });
            return list;
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetListEmpleados()
        {
            List<Empleado> EmpleadoList = FindListEmpleados();
            return Json(new { EmpleadoList = EmpleadoList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetListEstado()
        {
            List<Estado> EstadoList = db.Estado.ToList();
            return Json(new { EstadoList = EstadoList }, JsonRequestBehavior.AllowGet);
        }


        // GET: Requerimientos
        public ActionResult Index(int empleado =0, int estado = 0   )
        {
            List<Empleado> EmpleadoList = FindListEmpleados();
            ViewBag.EmpleadoList = new SelectList(EmpleadoList, "Id_empleado", "Nombre");

            List<Estado> EstadoList = db.Estado.ToList();
            Estado quitar = EstadoList.Where(est => est.Descripcion== "PENDIENTE").First();
            EstadoList.Remove(quitar);
            ViewBag.EstadoList = new SelectList(EstadoList, "Id", "Descripcion");

            List<Cliente> listEmpleado = db.Cliente.ToList();

            List<Requerimiento> list = db.Requerimiento.ToList();
            List<Requerimiento> nuevaList = new List<Requerimiento>();
            list.ForEach(l => {
                if(validarRequerimientoEmpleado(l, empleado) && validarRequerimientoEstado(l, estado))
                {
                    nuevaList.Add(l);
                }
            });
            return View(nuevaList);
        }

        private bool validarRequerimientoEmpleado(Requerimiento req , int empleado)
        {
            if (req.Empleado == null) return false;
            if ( empleado == 0 || req.Empleado.Id_empleado == empleado)
            {
                return true;
            }
            return false;
        }
        private bool validarRequerimientoEstado(Requerimiento req, int estado)
        {
            if (req.Estado == null) return false;
            if (estado == 0 || req.Estado.Id == estado)
            {
                return true;
            }
            return false;
        }

        // GET: Requerimientos/Details/5
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

        // GET: Requerimientos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Requerimientos/Create
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

        // GET: Requerimientos/Edit/5
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

        // POST: Requerimientos/Edit/5
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

        // GET: Requerimientos/Delete/5
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

        // POST: Requerimientos/Delete/5
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
