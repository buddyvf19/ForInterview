using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using DAO;
namespace Service
{
    /// <summary>
    /// service底層
    /// </summary>
   public class _Service
   {
        /// <summary>
        /// session物件
        /// </summary>
        internal Employees loginUser;
        /// <summary>
        /// data control interface
        /// </summary>
        internal IDAC _Dac;
        public _Service()
        {
        }
        public _Service(IDAC DataControl)
        {
            _Dac = DataControl;
        }
        public _Service(Employees User,IDAC DataObject)
        {
            loginUser = User;
            _Dac = DataObject;
        }
    }
}
