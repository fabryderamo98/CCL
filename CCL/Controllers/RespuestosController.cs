using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CCL.Models;
using Rotativa.MVC;

namespace CCL.Controllers
{
    public class RespuestosController : Controller
    {
        private CCLEntities db = new CCLEntities();

        // GET: Respuestos
        public ActionResult Index()
        {
            var respuestos = db.Respuestos.Include(r => r.Activos).Include(r => r.TipoRepuesto);
            return View(respuestos.ToList());
        }

        // GET: Respuestos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuestos respuestos = db.Respuestos.Find(id);
            if (respuestos == null)
            {
                return HttpNotFound();
            }
            return View(respuestos);
        }

        // GET: Respuestos/Create
        public ActionResult Create()
        {
            ViewBag.idActivo = new SelectList(db.Activos, "idActivo", "marca");
            ViewBag.idTiporepuesto = new SelectList(db.TipoRepuesto, "idTiporepuesto", "nombre");
            return View();
        }

        // POST: Respuestos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRepuesto,modelo,marca,idActivo,idTiporepuesto")] Respuestos respuestos)
        {
            if (ModelState.IsValid)
            {
                db.Respuestos.Add(respuestos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idActivo = new SelectList(db.Activos, "idActivo", "marca", respuestos.idActivo);
            ViewBag.idTiporepuesto = new SelectList(db.TipoRepuesto, "idTiporepuesto", "nombre", respuestos.idTiporepuesto);
            return View(respuestos);
        }

        // GET: Respuestos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuestos respuestos = db.Respuestos.Find(id);
            if (respuestos == null)
            {
                return HttpNotFound();
            }
            ViewBag.idActivo = new SelectList(db.Activos, "idActivo", "marca", respuestos.idActivo);
            ViewBag.idTiporepuesto = new SelectList(db.TipoRepuesto, "idTiporepuesto", "nombre", respuestos.idTiporepuesto);
            return View(respuestos);
        }

        // POST: Respuestos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRepuesto,modelo,marca,idActivo,idTiporepuesto")] Respuestos respuestos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(respuestos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idActivo = new SelectList(db.Activos, "idActivo", "marca", respuestos.idActivo);
            ViewBag.idTiporepuesto = new SelectList(db.TipoRepuesto, "idTiporepuesto", "nombre", respuestos.idTiporepuesto);
            return View(respuestos);
        }

        // GET: Respuestos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuestos respuestos = db.Respuestos.Find(id);
            if (respuestos == null)
            {
                return HttpNotFound();
            }
            return View(respuestos);
        }

        // POST: Respuestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Respuestos respuestos = db.Respuestos.Find(id);
            db.Respuestos.Remove(respuestos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Print()
        {
            return new ActionAsPdf("Index") { FileName = "RepuestosReport.pdf" };
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
