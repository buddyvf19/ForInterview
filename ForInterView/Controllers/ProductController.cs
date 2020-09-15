using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using ForInterView.Models;
using DataModels;
namespace ForInterView.Controllers
{
    public class ProductController : _Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ProductModel Product = new ProductModel();
            ProductService service = new ProductService();
            service.LoadQueryData();
            Product.Cat = MapDropDown(service.Cat, "CategoryName", "CategoryID");
            Product.Sup = MapDropDown(service.Sup, "CompanyName", "SupplierID");
            return View(Product);
        }
        public ActionResult QueryGrid(Products P)
        {
            ProductService service = new ProductService { Product=P};
            List <Products> ProductList= service.Query();
            return PartialView("_ProdtGrid", ProductList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int[] Products)
        {
            ProductService service = new ProductService();
            service.Delete(Products);
            return Json(new { success = true });
        }
    }
}