using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using DataModels;
namespace ForInterView.Controllers
{
    public class _Controller : Controller
    {
        public Employees UserData=null;
        /// <summary>
        /// 例外處理
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }
        /// <summary>
        /// action執行前
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["User"] == null &&
                !filterContext.RequestContext.HttpContext.Request.RawUrl.ToLower().Contains("login") )
            {
                RedirectToAction("Home", "login");
            }
            else
            {
                UserData = (Employees)Session["User"];
            }
            base.OnActionExecuting(filterContext);
        }
        /// <summary>
        /// dorpdown databind
        /// </summary>
        /// <param name="SouceList">來源</param>
        /// <param name="KeyCol">text column</param>
        /// <param name="valCal">value column</param>
        /// <returns></returns>
        internal List<SelectListItem> MapDropDown<T>(List<T> SouceList,string KeyCol,string valCal)
        {
            List<SelectListItem> selList = new List<SelectListItem>();
            foreach (var s in SouceList)
            {
                string key = GetPropertyValue(s,KeyCol);
                string value = GetPropertyValue(s,valCal);
                if (!selList.Any(x => x.Text == key))
                {
                    selList.Add(new SelectListItem
                    {
                        Text = key,
                        Value = value
                    });
                }
            }
            return selList;
        }
        /// <summary>
        /// 取得泛型property
        /// </summary>
        /// <param name="Data">泛型</param>
        /// <param name="Key">欄位</param>
        /// <returns></returns>
        private string GetPropertyValue<T>(T Data, string Key)
        {
            PropertyInfo P = Data.GetType().GetProperty(Key);
            return P == null ? "" : P.GetValue(Data).ToString();
        }
    }
}