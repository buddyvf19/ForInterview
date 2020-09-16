using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace DAO
{
    public class EmployeesDAO : _DAO
    {
        public EmployeesDAO(int commandTimeout=0):base(commandTimeout)
        { 
            
        }
        /// <summary>
        /// 取得登入員工資料
        /// </summary>
        /// <param name="EmpId">員工帳號</param>
        /// <param name="Password">密碼</param>
        /// <returns></returns>
        public Employees GetLoginEmp(Employees EmpData)
        {
            sql = @"select EmployeeID,Account,LastName,FirstName,Title from Employees
                    where Account=@Account ";
            if (!string.IsNullOrEmpty(EmpData.Password))
                sql += " and Password = @Password";
            return QueryFirst<Employees>(sql, EmpData);
        }
    }
}
