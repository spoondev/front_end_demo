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
    public class totalsController : Controller
    {
        private demo_front_end_V2Entities1 db = new demo_front_end_V2Entities1();

        // GET: totals
        public ActionResult Index()
        {
            return View(db.totals.ToList());
        }

        // GET: totals/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            total total = db.totals.Find(id);
            if (total == null)
            {
                return HttpNotFound();
            }
            return View(total);
        }

        // GET: totals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: totals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UID,totalFiles,totalRemediated,percentRemedited,PII,PCI,RET,SPEC,Public,Internal,Classified,ClassifiedSen,Secret")] total total)
        {
            if (ModelState.IsValid)
            {
                db.totals.Add(total);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(total);
        }

        // GET: totals/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            total total = db.totals.Find(id);
            if (total == null)
            {
                return HttpNotFound();
            }
            return View(total);
        }

        // POST: totals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UID,totalFiles,totalRemediated,percentRemedited,PII,PCI,RET,SPEC,Public,Internal,Classified,ClassifiedSen,Secret")] total total)
        {
            if (ModelState.IsValid)
            {
                db.Entry(total).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(total);
        }

        // GET: totals/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            total total = db.totals.Find(id);
            if (total == null)
            {
                return HttpNotFound();
            }
            return View(total);
        }

        // POST: totals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            total total = db.totals.Find(id);
            db.totals.Remove(total);
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
