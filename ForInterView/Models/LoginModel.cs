using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModels;
using System.ComponentModel.DataAnnotations;
namespace ForInterView.Models
{
    public class LoginModel:Employees
    {
        [Required]
        public override string Account { get => base.Account; set => base.Account = value; }
        [Required]
        public override string Password { get => base.Password; set => base.Password = value; }
    }
}