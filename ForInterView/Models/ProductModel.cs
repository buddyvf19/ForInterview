using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataModels;
namespace ForInterView.Models
{
    public class ProductModel:Products
    {
        /// <summary>
        /// catagory dropdown
        /// </summary>
        public List<SelectListItem> Cat { get; set; }
        /// <summary>
        /// supplier dropdown
        /// </summary>
        public List<SelectListItem> Sup { get; set; }
    }
}