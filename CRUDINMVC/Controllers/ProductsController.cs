using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDINMVC.Models;

namespace CRUDINMVC.Controllers
{
    public class ProductsController : Controller
    {
        private DemoDBEntities1 db = new DemoDBEntities1();

        // GET: Products
        public ActionResult AllProductList()
        {
            var lobjtblProducts = db.sp_Select_tblProduct().ToList();
            return View(lobjtblProducts);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var lobjtblProduct = db.sp_details_tblProduct(id).FirstOrDefault();
            if (lobjtblProduct == null)
            {
                return HttpNotFound();
            }
            return View(lobjtblProduct);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.PROD_CATEGORY_ID = new SelectList(db.sp_Select_tblCategory().ToList(), "CATEGORY_ID", "CATEGORY_NAME");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PROD_ID,PROD_NAME,PROD_PRICE,PROD_UNIT,PROD_CATEGORY_ID")] tblProduct aobjtblProduct)
        {
            if (ModelState.IsValid)
            {
                db.sp_Insert_tblProduct(aobjtblProduct.PROD_NAME, aobjtblProduct.PROD_PRICE, aobjtblProduct.PROD_UNIT, aobjtblProduct.PROD_CATEGORY_ID);
               
                return RedirectToAction("AllProductList");
            }

            ViewBag.PROD_CATEGORY_ID = new SelectList(db.sp_Select_tblCategory().ToList(), "CATEGORY_ID", "CATEGORY_NAME", aobjtblProduct.PROD_CATEGORY_ID);
            return View(aobjtblProduct);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var lobjtblProduct = db.sp_details_tblProduct(id).FirstOrDefault();
            if (lobjtblProduct == null)
            {
                return HttpNotFound();
            }            
            ViewBag.PROD_CATEGORY_ID = new SelectList(db.sp_Select_tblCategory().ToList(), "CATEGORY_ID", "CATEGORY_NAME", lobjtblProduct.CATEGORY_NAME);
            return View(lobjtblProduct);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PROD_ID,PROD_NAME,PROD_PRICE,PROD_UNIT,PROD_CATEGORY_ID")] tblProduct aobjtblProduct)
        {
            if (ModelState.IsValid)
            {                
                db.sp_Update_tblProduct(aobjtblProduct.PROD_ID, aobjtblProduct.PROD_NAME, aobjtblProduct.PROD_PRICE, aobjtblProduct.PROD_UNIT, aobjtblProduct.PROD_CATEGORY_ID);
                return RedirectToAction("AllProductList");
            }
            ViewBag.PROD_CATEGORY_ID = new SelectList(db.sp_Select_tblCategory().ToList(), "CATEGORY_ID", "CATEGORY_NAME", aobjtblProduct.PROD_CATEGORY_ID);
            return View(aobjtblProduct);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var lobjtblProduct = db.sp_details_tblProduct(id).FirstOrDefault();
            if (lobjtblProduct == null)
            {
                return HttpNotFound();
            }
            return View(lobjtblProduct);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.sp_delete_tblProduct(id);            
            return RedirectToAction("AllProductList");
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
