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
            db.Empleado.ToList();
            db.Cliente.ToList();
            db.Estado.ToList();
            List<Requerimiento> listNoAsignados = new List<Requerimiento>();
            db.Requerimiento.ToList().ForEach( req => {
                if (req.Estado.Descripcion.Equals("PENDIENTE"))
                {
                    listNoAsignados.Add(req);
                }
            });
            return View(listNoAsignados);
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
            db.Cliente.ToList();
            db.Estado.ToList();
            db.Rol.ToList();
            db.Requerimiento.ToList();
            List<Empleado> listEmpleados = db.Empleado.ToList();

            List <ResumenClass> listInfo = new List<ResumenClass>();

            listEmpleados.ForEach(emp => {
                ResumenClass arreglo = new ResumenClass();
                arreglo.nombre = emp.Nombre + " " + emp.ApellidoPat + " " + emp.ApellidoMat;
                arreglo.puesto = "EJECUTIVO VENTA";
                arreglo.cantidadReq = getCantidadReqAsignada(emp.Requerimientos);
                arreglo.idEmpleado = emp.Id_empleado;
                listInfo.Add(arreglo);
            });
            ViewBag.Empleados = listInfo;
            Requerimiento requerimiento = db.Requerimiento.Find(id);
            if (requerimiento == null)
            {
                return HttpNotFound();
            }
            requerimiento.Empleado = new Empleado();
            return View(requerimiento);
        }

        private int getCantidadReqAsignada(List<Requerimiento> listaRequerimientos)
        {
            if (listaRequerimientos == null) return 0;
            int cantidad = 0;
            listaRequerimientos.ForEach( req => {
                if (req.Estado.Descripcion.CompareTo("CERRADO") != 0 && req.Estado.Descripcion.CompareTo("CANCELADO") != 0 
                && req.Estado.Descripcion.CompareTo("APROBADO") != 0  )
                {
                    cantidad++;
                }
            });

            return cantidad;
        }

        // POST: RequerimientosSinAsignacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, [Bind(Include = "Id_empleado")] String Id_empleado)
        {
            if (ModelState.IsValid)
            {
                Estado estado = db.Estado.Where(e => e.Descripcion.Equals("PROCESANDO")).FirstOrDefault();
                DateTime localDate = DateTime.Now;
                localDate.AddDays(10);
                Empleado empleados = db.Empleado.Find(Int32.Parse(Id_empleado));
                Requerimiento requerimiento = db.Requerimiento.Find(Id);
                requerimiento.Fecha_limit_req = localDate;
                requerimiento.Fecha_fin_real = localDate;
                requerimiento.Empleado = empleados;
                requerimiento.Estado = estado;
                db.Entry(requerimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
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
