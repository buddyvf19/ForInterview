using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DataModels;
namespace Service
{
    public class LoginService : _Service
    {
        public LoginService() : base()
        {
        }
        public LoginService(Employees User, IDAC DataObject) : base(User,DataObject)
        {
            EmpData = loginUser;
        }
        public Employees EmpData { get; set; }
        /// <summary>
        /// 登入帳號檢查
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="Passowrd"></param>
        /// <returns></returns>
        public bool Login()
        {
            loginUser = _Dac.GetFirst(loginUser);
            if (loginUser != null)
                return true;
            else
                return false;
        }
    }
}
