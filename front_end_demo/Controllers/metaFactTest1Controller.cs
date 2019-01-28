using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using front_end_demo.Models;

namespace front_end_demo.Controllers
{
    public class metaFactTest1Controller : Controller
    {
        private demo_front_end_V2Entities1 db = new demo_front_end_V2Entities1();

        // GET: metaFactTest1
        public ActionResult Index()
        {
            return View(db.metaFactTest1.ToList());
        }

        // GET: metaFactTest1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            metaFactTest1 metaFactTest1 = db.metaFactTest1.Find(id);
            if (metaFactTest1 == null)
            {
                return HttpNotFound();
            }
            return View(metaFactTest1);
        }

        // GET: metaFactTest1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: metaFactTest1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UID,id,filter,fileName,fileRoot,RootReference,securityClass,businessClass,filePath,extension,mimeType,MD5,emailID,emailNew")] metaFactTest1 metaFactTest1)
        {
            if (ModelState.IsValid)
            {
                db.metaFactTest1.Add(metaFactTest1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(metaFactTest1);
        }

        // GET: metaFactTest1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            metaFactTest1 metaFactTest1 = db.metaFactTest1.Find(id);
            if (metaFactTest1 == null)
            {
                return HttpNotFound();
            }
            return View(metaFactTest1);
        }

        // POST: metaFactTest1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UID,id,filter,fileName,fileRoot,RootReference,securityClass,businessClass,filePath,extension,mimeType,MD5,emailID,emailNew")] metaFactTest1 metaFactTest1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metaFactTest1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(metaFactTest1);
        }

        // GET: metaFactTest1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            metaFactTest1 metaFactTest1 = db.metaFactTest1.Find(id);
            if (metaFactTest1 == null)
            {
                return HttpNotFound();
            }
            return View(metaFactTest1);
        }

        // POST: metaFactTest1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            metaFactTest1 metaFactTest1 = db.metaFactTest1.Find(id);
            db.metaFactTest1.Remove(metaFactTest1);
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
