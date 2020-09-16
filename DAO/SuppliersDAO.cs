using System.Collections.Generic;
namespace DAO
{
    public class SuppliersDAO : _DAO
    {
        public SuppliersDAO(int commandTimeout=0):base(commandTimeout)
        { 
            
        }
        /// <summary>
        /// 取得登入員工資料
        /// </summary>
        /// <param name="EmpId">員工帳號</param>
        /// <param name="Password">密碼</param>
        /// <returns></returns>
        public override  List<T> GetList<T>() 
        {
            sql = @"select SupplierID,CompanyName,ContactName,ContactTitle,Address,City,Region from Suppliers
                     ";
           return QueryLists<T>(sql);
        }
    }
}
