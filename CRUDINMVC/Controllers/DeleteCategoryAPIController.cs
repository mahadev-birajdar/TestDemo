using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRUDINMVC.Models;


namespace CRUDINMVC
{
    public class DeleteCategoryAPIController : ApiController
    {
        private DemoDBEntities1 db = new DemoDBEntities1();

        private readonly List<tblProduct> ilstProduct = new List<tblProduct>();

        [HttpGet]
        public IEnumerable<tblProduct> GetCategories()
        {
            var lobjProducts = db.sp_tblProduct_data().ToList();
            foreach (var Product in lobjProducts)
            {
                tblProduct lobjProduct = new tblProduct();
                lobjProduct.PROD_ID = Product.PROD_ID;
                lobjProduct.PROD_CATEGORY_ID = Product.PROD_CATEGORY_ID;
                lobjProduct.PROD_PRICE = Product.PROD_PRICE;
                lobjProduct.PROD_UNIT = Product.PROD_UNIT;
                ilstProduct.Add(lobjProduct);
            }
            return ilstProduct;
        }
    }
}
