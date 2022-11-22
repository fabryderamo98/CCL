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
    public class LocacionController : Controller
    {
        private CCLEntities db = new CCLEntities();

        // GET: Locacion
        public ActionResult Index()
        {
            return View(db.Locacion.ToList());
        }

        // GET: Locacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locacion locacion = db.Locacion.Find(id);
            if (locacion == null)
            {
                return HttpNotFound();
            }
            return View(locacion);
        }

        // GET: Locacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Locacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idLocacion,nombre")] Locacion locacion)
        {
            if (ModelState.IsValid)
            {
                db.Locacion.Add(locacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(locacion);
        }

        // GET: Locacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locacion locacion = db.Locacion.Find(id);
            if (locacion == null)
            {
                return HttpNotFound();
            }
            return View(locacion);
        }

        // POST: Locacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idLocacion,nombre")] Locacion locacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locacion);
        }

        // GET: Locacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locacion locacion = db.Locacion.Find(id);
            if (locacion == null)
            {
                return HttpNotFound();
            }
            return View(locacion);
        }

        // POST: Locacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Locacion locacion = db.Locacion.Find(id);
            db.Locacion.Remove(locacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Print()
        {
            return new ActionAsPdf("Index") { FileName = "LocacionReport.pdf" };
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
