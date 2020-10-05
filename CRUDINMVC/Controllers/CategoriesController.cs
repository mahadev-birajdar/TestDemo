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
    public class CategoriesController : Controller
    {
        private DemoDBEntities1 db = new DemoDBEntities1();

        // GET: Categories
        public ActionResult AllCategoryList()
        {
            return View(db.sp_Select_tblCategory().ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? CATEGORY_ID)
        {
            if (CATEGORY_ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var lobtblCategory = db.sp_details_tblCategory(CATEGORY_ID).FirstOrDefault();
            if (lobtblCategory == null)
            {
                return HttpNotFound();
            }
            return View(lobtblCategory);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CATEGORY_ID,CATEGORY_NAME")] tblCategory aobjtblCategory)
        {
            if (ModelState.IsValid)
            {
                db.sp_Insert_tblCategory(aobjtblCategory.CATEGORY_NAME);               
                return RedirectToAction("AllCategoryList");
            }
            return View(aobjtblCategory);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? CATEGORY_ID)
        {
            if (CATEGORY_ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var lobjtblCategory = db.sp_details_tblCategory(CATEGORY_ID).FirstOrDefault();
            if (lobjtblCategory == null)
            {
                return HttpNotFound();
            }
            return View(lobjtblCategory);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CATEGORY_ID,CATEGORY_NAME")] tblCategory aobjtblCategory)
        {
            if (ModelState.IsValid)
            {
                db.sp_Update_tblCategory(aobjtblCategory.CATEGORY_ID, aobjtblCategory.CATEGORY_NAME);                
                return RedirectToAction("AllCategoryList");
            }
            return View(aobjtblCategory);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? CATEGORY_ID)
        {
            if (CATEGORY_ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var lobjtblCategory = db.sp_details_tblCategory(CATEGORY_ID).FirstOrDefault();
            if (lobjtblCategory == null)
            {
                return HttpNotFound();
            }
            return View(lobjtblCategory);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int CATEGORY_ID)
        {            
            db.sp_delete_tblCategory(CATEGORY_ID);
            return RedirectToAction("AllCategoryList");
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
