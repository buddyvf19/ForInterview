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
        public ProductService(IDAC DataControl) : base(DataControl)
        {

        }
        /// <summary>
        /// 取得下拉資料
        /// </summary>
        /// <returns></returns>
        public List<T> GetDropdown<T>(IDAC DataControl)
        {
            _Dac = DataControl;
            return _Dac.GetList<T>();
        }
        public T QueryId<T>(int ProductId)
        {
            return _Dac.GetFirst<T>(ProductId);
        }
        /// <summary>
        /// 查詢
        /// </summary>
        /// <returns></returns>
        public List<Products> Query()
        {
            return _Dac.GetList(Product);
        }
        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="ProductId"></param>
        public void Delete(int[] ProductId)
        {
           _Dac.Delete(ProductId);
        }
        /// <summary>
        /// 新增/修改
        /// </summary>
        public void Modify(Products P)
        {
            if (P.ProductID == 0)
            {
                _Dac.Insert(P);
            }
            else
            {
                _Dac.Update(P);
            }
        }
   }
}
