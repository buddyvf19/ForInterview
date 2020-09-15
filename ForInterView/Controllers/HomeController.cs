using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataModels;
using Service;
namespace ForInterView.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
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
        public ActionResult Login(Employees Emp)
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect(FormsAuthentication.DefaultUrl);
            }
            LoginService s = new LoginService(Emp);
            if (s.Login())
            {
                Session["User"] = s.EmpData;
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