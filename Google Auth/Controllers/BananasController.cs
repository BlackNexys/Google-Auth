using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Google_Auth.Models;

namespace Google_Auth.Controllers
{
    public class BananasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bananas
        public ActionResult Index()
        {
            return View(db.Bananas.ToList());
        }

        // GET: Bananas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banana banana = db.Bananas.Find(id);
            if (banana == null)
            {
                return HttpNotFound();
            }
            return View(banana);
        }

        // GET: Bananas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bananas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,description,placeOfOrigin")] Banana banana)
        {
            if (ModelState.IsValid)
            {
                db.Bananas.Add(banana);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(banana);
        }

        // GET: Bananas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banana banana = db.Bananas.Find(id);
            if (banana == null)
            {
                return HttpNotFound();
            }
            return View(banana);
        }

        // POST: Bananas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,description,placeOfOrigin")] Banana banana)
        {
            if (ModelState.IsValid)
            {
                db.Entry(banana).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(banana);
        }

        // GET: Bananas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banana banana = db.Bananas.Find(id);
            if (banana == null)
            {
                return HttpNotFound();
            }
            return View(banana);
        }

        // POST: Bananas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Banana banana = db.Bananas.Find(id);
            db.Bananas.Remove(banana);
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
