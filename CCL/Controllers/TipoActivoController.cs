using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CCL.Models;

namespace CCL.Controllers
{
    public class TipoActivoController : Controller
    {
        private CCLEntities db = new CCLEntities();

        // GET: TipoActivo
        public ActionResult Index()
        {
            return View(db.TipoActivo.ToList());
        }

        // GET: TipoActivo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoActivo tipoActivo = db.TipoActivo.Find(id);
            if (tipoActivo == null)
            {
                return HttpNotFound();
            }
            return View(tipoActivo);
        }

        // GET: TipoActivo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoActivo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoactivo,activo")] TipoActivo tipoActivo)
        {
            if (ModelState.IsValid)
            {
                db.TipoActivo.Add(tipoActivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoActivo);
        }

        // GET: TipoActivo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoActivo tipoActivo = db.TipoActivo.Find(id);
            if (tipoActivo == null)
            {
                return HttpNotFound();
            }
            return View(tipoActivo);
        }

        // POST: TipoActivo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoactivo,activo")] TipoActivo tipoActivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoActivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoActivo);
        }

        // GET: TipoActivo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoActivo tipoActivo = db.TipoActivo.Find(id);
            if (tipoActivo == null)
            {
                return HttpNotFound();
            }
            return View(tipoActivo);
        }

        // POST: TipoActivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoActivo tipoActivo = db.TipoActivo.Find(id);
            db.TipoActivo.Remove(tipoActivo);
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
