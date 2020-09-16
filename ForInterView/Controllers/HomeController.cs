using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataModels;
using Service;
using DAO;
namespace ForInterView.Controllers
{
    public class HomeController : _Controller
    {
        /// <summary>
        /// login page
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect(FormsAuthentication.DefaultUrl);
            }
            Logout();
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="Emp">登入資料</param>
        /// <returns></returns>
        [HttpPost]
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Login(Employees Emp)
        {
            LoginService service = new LoginService(Emp,new EmployeesDAO());
            //check login data
            if (service.Login())
            {
                ///set session
                Session["User"] = service.EmpData;
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, service.EmpData.Account, DateTime.Now, DateTime.Now.AddMinutes(20), true, "", FormsAuthentication.FormsCookiePath);
                string encTicket = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
                return Json(new { success = true });
            }
            else
                return Json(new {success=false });
        }
        /// <summary>
        /// Logout system
        /// </summary>
        /// <returns></returns>
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Logout()
        {
            Session.Clear();
            Response.Cookies.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            return Redirect(FormsAuthentication.LoginUrl);
        }
   
    }
}