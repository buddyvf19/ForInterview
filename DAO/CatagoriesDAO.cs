using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
namespace DAO
{
    public class CatagoriesDAO : _DAO
    {
        public CatagoriesDAO(int commandTimeout=0):base(commandTimeout)
        { 
            
        }
        /// <summary>
        /// 取得登入員工資料
        /// </summary>
        /// <param name="EmpId">員工帳號</param>
        /// <param name="Password">密碼</param>
        /// <returns></returns>
        public List<Catagories> GetCatagoryList()
        {
            sql = @"select   CategoryID,CategoryName,Description from Categories ";
            return QueryLists<Catagories>(sql);
        }
    }
}
