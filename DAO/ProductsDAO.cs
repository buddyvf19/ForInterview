using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using System.Transactions;
namespace DAO
{
    public class ProductsDAO : _DAO
    {
        public ProductsDAO(int commandTimeout=0):base(commandTimeout)
        { 
            
        }
        /// <summary>
        /// 查詢產品資料
        /// </summary>
        /// <param name="Products">查詢物件</param>
        /// <returns></returns>
        public List<Products> GetProductList(Products Products)
        {
            sql = @"select 
                    ProductID,ProductName,a.SupplierID,CompanyName SupplierName
                    ,a.CategoryID,CategoryName
                    ,QuantityPerUnit,UnitPrice
                    ,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued
                    from Products a left join Categories b on a.CategoryID=b.CategoryID
                    left join  Suppliers c on a.SupplierID=c.SupplierID
                    where 1=1
                    ";
            if (!string.IsNullOrEmpty(Products.ProductName))
            {
                sql += " and ProductName like '%'+@ProductName+'%' ";
            }
            if (Products.CategoryID>0)
            {
                sql += " and a.CategoryID =@CategoryID ";
            }
            if (Products.SupplierID>0)
            {
                sql += " and a.SupplierID =@SupplierID ";
            }
            return QueryLists<Products>(sql, Products);
        }
        /// <summary>
        /// 以ID取得product資料
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public Products GetProduct(int ProductId)
        {
            sql = @"select 
                    ProductID,ProductName,a.SupplierID,a.CategoryID,QuantityPerUnit,UnitPrice
                    ,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued
                    from Products a left join Categories b on a.CategoryID=b.CategoryID
                    left join  Suppliers c on a.SupplierID=c.SupplierID
                    where ProductID=@ProductID
                    ";
            return QueryFirst<Products>(sql, new { ProductId });
        }
        /// <summary>
        /// 新增product
        /// </summary>
        /// <param name="P"></param>
        public void Insert(Products P)
        {
            sql = @"Insert Products(ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice
                    ,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued)
                values(@ProductID,@ProductName,@SupplierID,@CategoryID,@QuantityPerUnit,@UnitPrice
                    ,@UnitsInStock,@UnitsOnOrder,@ReorderLevel,@Discontinued)
            ";
            ExcuteNoQuery(sql, P);
        }
        /// <summary>
        /// 新增product
        /// </summary>
        /// <param name="P"></param>
        public void Update(Products P)
        {
            sql = @"update Products
                    set ProductName=@ProductName,
                        SupplierID=@SupplierID,
                        CategoryID=@CategoryID,
                        QuantityPerUnit=@QuantityPerUnit,
                        UnitPrice=@UnitPrice,
                        UnitsInStock=@UnitsInStock,
                        UnitsOnOrder=@UnitsOnOrder,
                        ReorderLevel=@ReorderLevel,
                        Discontinued=@ReorderLevel
                   where ProductID=@ProductID
            ";
            ExcuteNoQuery(sql, P);
        }
        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="Product"></param>
        public void Delete(int[] Product)
        {
            using (TransactionScope scpoe = new TransactionScope())
            {
                sql = "delete Products where ProductId in @Product ";
                ExcuteNoQuery(sql, new { Product });
                scpoe.Complete();
            }
        }
    }
}
