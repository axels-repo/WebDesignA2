using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using _12246765_OnlineStore.Data;
using _12246765_OnlineStore.Models;

namespace _12246765_OnlineStore.Controllers
{
    public class ProductImagesController : Controller
    {
        private MyStoreContext db = new MyStoreContext();

        // GET: ProductImages
        public ActionResult Index()
        {
            return View(db.ProductImages.ToList());
        }

        // GET: ProductImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductImage productImage = db.ProductImages.Find(id);
            if (productImage == null)
            {
                return HttpNotFound();
            }
            return View(productImage);
        }

        // GET: ProductImages/Create
        public ActionResult Upload()
        {
            return View();
        }

        // POST: ProductImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                if (ValidateFile(file))
                {
                    try
                    {
                        SaveFileToDisk(file);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                        ModelState.AddModelError("FileName", "Error occured when saving file. Please try again");
                    }
                }
                else
                {
                    ModelState.AddModelError("FileName", "The file must be in the correct format (gif,png,jpeg,jpg) and less than 2MB");
                }
            }
            else
            {
                ModelState.AddModelError("FineName", "Please choose a file");
            }
            if (ModelState.IsValid)
            {
                db.ProductImages.Add(new ProductImage { FileName = file.FileName });
                try { db.SaveChanges(); }
                catch (DbUpdateException ex)
                {
                    SqlException innerException = ex.InnerException.InnerException as SqlException;
                    if (innerException != null && innerException.Number == 2601)
                    {
                        ModelState.AddModelError("FileName", "The file" + file.FileName + " already exists in the system. Please delete it and try again if you wish to re-add it");
                    }
                    else
                    {
                        ModelState.AddModelError("FileName", "Sorry an error occurred saving the file to disk, please try again");
                    }
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }
        

        // GET: ProductImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductImage productImage = db.ProductImages.Find(id);
            if (productImage == null)
            {
                return HttpNotFound();
            }
            return View(productImage);
        }

        // POST: ProductImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FileName")] ProductImage productImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productImage);
        }

        // GET: ProductImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductImage productImage = db.ProductImages.Find(id);
            if (productImage == null)
            {
                return HttpNotFound();
            }
            return View(productImage);
        }

        // POST: ProductImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductImage productImage = db.ProductImages.Find(id);
            Product product = db.Products.Find(id);
            if (product != null)
            {
                var mappings = product.ProductImageMappings.Where(pim => pim.ProductImageID == id);

                foreach (var mapping in mappings)
                {
                    //find all mappings for any product containing this image
                    var mappingsToUpdate = db.ProductImageMappings.Where(pim => pim.ProductID ==
                    mapping.ProductID);
                    //for each image in each product change its imagenumber to one lower if it is higher
                    //than the current image
                    foreach (var mappingToUpdate in mappingsToUpdate)
                    {
                        if (mappingToUpdate.ImageNumber > mapping.ImageNumber)
                        {
                            mappingToUpdate.ImageNumber--;
                        }
                    }
                }
            }
            System.IO.File.Delete(Request.MapPath(Constants.ProductImagePath + productImage.FileName));
            System.IO.File.Delete(Request.MapPath(Constants.ProductThumbnailPath + productImage.FileName));
            db.ProductImages.Remove(productImage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        private bool ValidateFile(HttpPostedFileBase file)
        {
            string fileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();
            string[] allowedFileTypes = { ".gif", ".png", ".jpeg", ".jpg" };
            if ((file.ContentLength > 0 && file.ContentLength < 2097152) && allowedFileTypes.Contains(fileExtension))
            {
                return true;
            }
            return false;
        }
        private void SaveFileToDisk(HttpPostedFileBase file)
        {
            WebImage img = new WebImage(file.InputStream);
            if (img.Width > 190)
            {
                img.Resize(190, img.Height);
            }
            img.Save(Constants.ProductImagePath + file.FileName);
            if (img.Width > 100)
            {
                img.Resize(100, img.Height);
            }
            img.Save(Constants.ProductThumbnailPath + file.FileName);
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
