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
    public class ClienteController : Controller
    {
        private SegurosDbContext db = new SegurosDbContext();
        private List<SelectListItem> _regionsItems;


        // GET: Cliente
        public ActionResult Index()
        {
            return View(db.Cliente.ToList());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {

            var regions = db.Region.ToList();
            _regionsItems = new List<SelectListItem>();
            foreach (var item in regions)
            {
                _regionsItems.Add(new SelectListItem
                {
                    Text = item.Nombre_region,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.regionsItems = _regionsItems;
            //List<Region> RegionList = db.Region.ToList();
            //ViewBag.RegionList = new SelectList(RegionList, "Id", "Nombre_region");
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetCiudadByRegion(int RegionId)
        {
            List<Ciudad> CiudadList = db.Ciudad.Where(x => x.region.Id == RegionId).ToList();
            return Json(new { CiudadList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetComunaByCiudad(int CiudadId)
        {
            List<Comuna> ComunaList = db.Comuna.Where(x => x.ciudad.Id == CiudadId).ToList();
            return Json(new { ComunaList }, JsonRequestBehavior.AllowGet);
        }

        // POST: Cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_cliente,Rut_cliente,Nombre,ApellidoPat,ApellidoMat,Fecha_nacimiento,Calle,NumCalle,comuna,ciudad,Region,Telefono,Email,Operacion,Estado,Observaciones")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_cliente,Rut_cliente,Nombre,ApellidoPat,ApellidoMat,Fecha_nacimiento,Calle,NumCalle,Comuna,Ciudad,Region,Telefono,Email,Operacion,Estado,Observaciones")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
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
