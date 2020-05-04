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
            List<Region> RegionList = db.Region.ToList();
            ViewBag.RegionList = new SelectList(RegionList, "Id", "Nombre_region");
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetCiudadByRegion(int id)
        {
            List<Ciudad> CiudadList = db.Ciudad.Where(x => x.region.Id == id).ToList();
            return Json(new { CiudadList = CiudadList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetComunaByCiudad(string name)
        {
            List<Comuna> ComunaList = db.Comuna.Where(x => x.ciudad.Nombre_ciudad == name).ToList();
            return Json(new { ComunaList = ComunaList }, JsonRequestBehavior.AllowGet);
        }

        // POST: Cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_cliente,Rut_cliente,Nombre,ApellidoPat,ApellidoMat,Fecha_nacimiento,Calle,NumCalle,Comuna,Ciudad,Region,Telefono,Email,Operacion,Estado,Observaciones")] Cliente cliente, String ciudades_name, String comuna_name, String Region)
        {
            try
            {
                Requerimiento newReq = new Requerimiento();
                newReq.Fecha_req = DateTime.Now;
                newReq.Fecha_limit_req = DateTime.Now.AddDays(12);
                newReq.Fecha_fin_real = DateTime.Now.AddDays(12);
                int Id = 1;
                newReq.Estado = db.Estado.Find(Id);
                Id = Int32.Parse(Region);
                cliente.Region = db.Region.Find(Id);
                cliente.ciudad = db.Ciudad.Where(e => e.Nombre_ciudad.Equals(ciudades_name)).FirstOrDefault();
                cliente.comuna = db.Comuna.Where(e => e.Nombre_comuna.Equals(comuna_name)).FirstOrDefault();
                db.Cliente.Add(cliente);
                newReq.Cliente = cliente;
                db.Requerimiento.Add(newReq);
                db.SaveChanges();
                return RedirectToAction("Index", "RequerimientosSinAsignacion");
            }catch(Exception e)
            {
                List<Region> RegionList = db.Region.ToList();
                ViewBag.RegionList = new SelectList(RegionList, "Id", "Nombre_region");
                return View(cliente);
            }
        }

        private bool ValidaRut(string rut)
        {
            rut = rut.Replace(".", "").ToUpper();
            System.Text.RegularExpressions.Regex expresion = new System.Text.RegularExpressions.Regex("^([0-9]+-[0-9K])$");
            string dv = rut.Substring(rut.Length - 1, 1);
            if (!expresion.IsMatch(rut))
            {
                return false;
            }
            char[] charCorte = { '-' };
            string[] rutTemp = rut.Split(charCorte);
            if (dv != Digito(int.Parse(rutTemp[0])))
            {
                return false;
            }
            return true;
        }
        private string Digito(int rut)
        {
            int suma = 0;
            int multiplicador = 1;
            while (rut != 0)
            {
                multiplicador++;
                if (multiplicador == 8)
                    multiplicador = 2;
                suma += (rut % 10) * multiplicador;
                rut = rut / 10;
            }
            suma = 11 - (suma % 11);
            if (suma == 11)
            {
                return "0";
            }
            else if (suma == 10)
            {
                return "K";
            }
            else
            {
                return suma.ToString();
            }
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
