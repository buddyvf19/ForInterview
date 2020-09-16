using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using ForInterView.Models;
using DataModels;
using DAO;
namespace ForInterView.Controllers
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
    public class ProductController : _Controller
    {
        ProductService service;
        // GET: Product
        public ActionResult Index()
        {
            ProductModel Product = new ProductModel();
            service = new ProductService(new CatagoriesDAO());
            Product.Cat = MapDropDown(service.GetDropdown<Catagories>(new CatagoriesDAO()), "CategoryName", "CategoryID");
            Product.Sup = MapDropDown(service.GetDropdown<Suppliers>(new SuppliersDAO()), "CompanyName", "SupplierID");
            Product.Cat.Insert(0, new SelectListItem { Text = "ALL", Value = "" });
            Product.Sup.Insert(0, new SelectListItem { Text = "ALL", Value = "" });
            return View(Product);
        }
        /// <summary>
        /// 查詢表格
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult QueryGrid(Products P)
        {
            service = new ProductService(new ProductsDAO()){ Product=P};
            List <Products> ProductList= service.Query();
            return PartialView("_ProdtGrid", ProductList);
        }
        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="ProductIds">ProductIds</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int[] ProductIds)
        {
            service = new ProductService(new ProductsDAO());
            service.Delete(ProductIds);
            return Json(new { success = true });
        }
        /// <summary>
        /// 修改畫面
        /// </summary>
        /// <returns></returns>
        public ActionResult Modify(int ProductId)
        {
            service = new ProductService(new ProductsDAO());
            ProductModel Product;
            if (ProductId == 0)
            {
                ViewBag.Title = "New";
                Product = new ProductModel();
            }
            else
            {
                ViewBag.Title = "Modify";
                Product = service.QueryId<ProductModel>(ProductId);
            }
            ProductModel P = Product as ProductModel;
            P.Cat = MapDropDown(service.GetDropdown<Catagories>(new CatagoriesDAO()), "CategoryName", "CategoryID");
            P.Sup = MapDropDown(service.GetDropdown<Suppliers>(new SuppliersDAO()), "CompanyName", "SupplierID");
            P.Cat.Insert(0, new SelectListItem { Text = "ALL", Value = "" });
            P.Sup.Insert(0, new SelectListItem { Text = "ALL", Value = "" });
            return View(P);
        }
        /// <summary>
        ///  新增/修改
        /// </summary>
        /// <param name="P">Product</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult Modify(Products P)
        {
            service = new ProductService(new ProductsDAO());
            service.Modify(P);
            return Json(new { success = true });
        }
    }
}