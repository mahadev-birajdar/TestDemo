using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRUDINMVC.Models;


namespace CRUDINMVC.Controllers
{
    public class CategoryAPIController : ApiController
    {
        private DemoDBEntities1 db = new DemoDBEntities1();

        private readonly List<tblCategory> ilstCtegory = new List<tblCategory>();

        [HttpGet]
        public IEnumerable<tblCategory> GetCategories()
        {
            var lobjCategories = db.sp_Select_tblCategory().ToList();
            foreach(var category in lobjCategories)
            {
                tblCategory lobjCategory = new tblCategory();
                lobjCategory.CATEGORY_ID = category.CATEGORY_ID;
                lobjCategory.CATEGORY_NAME = category.CATEGORY_NAME;
                ilstCtegory.Add(lobjCategory);
            }

            return ilstCtegory; 
        }

        [HttpGet]
        public tblCategory GetCategoryByID(int id)
        {
            return ilstCtegory.Find(x => x.CATEGORY_ID == id);
        }
    }
}
