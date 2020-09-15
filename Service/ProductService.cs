using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using DAO;
namespace Service
{
   public class ProductService :_Service
   {
        public Products Product { get; set; }
        /// <summary>
        /// catagories選單
        /// </summary>
        public List<Catagories> Cat { get; set; }
        /// <summary>
        /// suppliers選單
        /// </summary>
        public List<Suppliers> Sup { get; set; }
        public ProductService() : base()
        {

        }
        public ProductService(Employees User) : base(User)
        { 
        
        }
        /// <summary>
        /// 取得catagories下拉資料
        /// </summary>
        /// <returns></returns>
        public List<Catagories> GetCatagories()
        {
            using (var dao = new CatagoriesDAO())
            {
                return dao.GetCatagoryList();
            }
        }
        /// <summary>
        /// 取得Suppliers下拉資料
        /// </summary>
        /// <returns></returns>
        public List<Suppliers> GetSupplierList()
        {
            using (var dao = new SuppliersDAO())
            {
                return dao.GetSuppliers();
            }
        }
        /// <summary>
        /// 讀取查詢畫面資料
        /// </summary>
        /// <returns></returns>
        public void LoadQueryData()
        {
            Cat = GetCatagories();
            Sup = GetSupplierList();
        }
        /// <summary>
        /// 查詢
        /// </summary>
        /// <returns></returns>
        public List<Products> Query()
        {
            using (var dao = new ProductsDAO())
            {
                return dao.GetProductList(Product);
            }
        }
        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="ProductId"></param>
        public void Delete(int[] ProductId)
        {
            using (var dao = new ProductsDAO())
            {
                dao.Delete(ProductId);
            }
        }
   }
}
