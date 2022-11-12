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
    public class ActivosController : Controller
    {
        private CCLEntities db = new CCLEntities();

        // GET: Activos
        public ActionResult Index()
        {
            var activos = db.Activos.Include(a => a.Estados).Include(a => a.TipoActivo).Include(a => a.Usuario);
            return View(activos.ToList());
        }

        // GET: Activos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activos activos = db.Activos.Find(id);
            if (activos == null)
            {
                return HttpNotFound();
            }
            return View(activos);
        }

        // GET: Activos/Create
        public ActionResult Create()
        {
            ViewBag.idEstado = new SelectList(db.Estados, "idEstado", "descripcion");
            ViewBag.idTipoactivo = new SelectList(db.TipoActivo, "idTipoactivo", "activo");
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "numlegajo");
            return View();
        }

        // POST: Activos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idActivo,marca,modelo,idUsuario,idTipoactivo,idEstado")] Activos activos)
        {
            if (ModelState.IsValid)
            {
                db.Activos.Add(activos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstado = new SelectList(db.Estados, "idEstado", "descripcion", activos.idEstado);
            ViewBag.idTipoactivo = new SelectList(db.TipoActivo, "idTipoactivo", "activo", activos.idTipoactivo);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "numlegajo", activos.idUsuario);
            return View(activos);
        }

        // GET: Activos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activos activos = db.Activos.Find(id);
            if (activos == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstado = new SelectList(db.Estados, "idEstado", "descripcion", activos.idEstado);
            ViewBag.idTipoactivo = new SelectList(db.TipoActivo, "idTipoactivo", "activo", activos.idTipoactivo);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "numlegajo", activos.idUsuario);
            return View(activos);
        }

        // POST: Activos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idActivo,marca,modelo,idUsuario,idTipoactivo,idEstado")] Activos activos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstado = new SelectList(db.Estados, "idEstado", "descripcion", activos.idEstado);
            ViewBag.idTipoactivo = new SelectList(db.TipoActivo, "idTipoactivo", "activo", activos.idTipoactivo);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "numlegajo", activos.idUsuario);
            return View(activos);
        }

        // GET: Activos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activos activos = db.Activos.Find(id);
            if (activos == null)
            {
                return HttpNotFound();
            }
            return View(activos);
        }

        // POST: Activos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activos activos = db.Activos.Find(id);
            db.Activos.Remove(activos);
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
