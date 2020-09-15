using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
namespace Service
{
   public class _Service
   {
        internal Employees loginUser;
        public _Service()
        {
        }
        public _Service(Employees User)
        {
            loginUser = User;
        }
    }
}
