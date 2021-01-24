using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _12246765_OnlineStore.Data;
using _12246765_OnlineStore.Models;

namespace _12246765_OnlineStore.Controllers
{
    public class ProductImageMappingsController : Controller
    {
        private MyStoreContext db = new MyStoreContext();

        // GET: ProductImageMappings
        public ActionResult Index()
        {
            var productImageMappings = db.ProductImageMappings.Include(p => p.Product).Include(p => p.ProductImage);
            return View(productImageMappings.ToList());
        }

        // GET: ProductImageMappings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductImageMapping productImageMapping = db.ProductImageMappings.Find(id);
            if (productImageMapping == null)
            {
                return HttpNotFound();
            }
            return View(productImageMapping);
        }

        // GET: ProductImageMappings/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name");
            ViewBag.ProductImageID = new SelectList(db.ProductImages, "ID", "FileName");
            return View();
        }

        // POST: ProductImageMappings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ImageNumber,ProductID,ProductImageID")] ProductImageMapping productImageMapping)
        {
            if (ModelState.IsValid)
            {
                db.ProductImageMappings.Add(productImageMapping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", productImageMapping.ProductID);
            ViewBag.ProductImageID = new SelectList(db.ProductImages, "ID", "FileName", productImageMapping.ProductImageID);
            return View(productImageMapping);
        }

        // GET: ProductImageMappings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductImageMapping productImageMapping = db.ProductImageMappings.Find(id);
            if (productImageMapping == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", productImageMapping.ProductID);
            ViewBag.ProductImageID = new SelectList(db.ProductImages, "ID", "FileName", productImageMapping.ProductImageID);
            return View(productImageMapping);
        }

        // POST: ProductImageMappings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ImageNumber,ProductID,ProductImageID")] ProductImageMapping productImageMapping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productImageMapping).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", productImageMapping.ProductID);
            ViewBag.ProductImageID = new SelectList(db.ProductImages, "ID", "FileName", productImageMapping.ProductImageID);
            return View(productImageMapping);
        }

        // GET: ProductImageMappings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductImageMapping productImageMapping = db.ProductImageMappings.Find(id);
            if (productImageMapping == null)
            {
                return HttpNotFound();
            }
            return View(productImageMapping);
        }

        // POST: ProductImageMappings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductImageMapping productImageMapping = db.ProductImageMappings.Find(id);
            db.ProductImageMappings.Remove(productImageMapping);
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
