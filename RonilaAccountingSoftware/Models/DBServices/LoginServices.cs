using RonilaAccountingSoftware.myClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RonilaAccountingSoftware.Models.dbActions
{
    internal class LoginServices
    {
        Models.RonilaDBEntities db=new RonilaDBEntities();
        myClass.UtilityClass fun = new myClass.UtilityClass();
        public LoginServices()
        {
                
        }
        public bool checkLogin(string userName,string password)
        {
           var count_user= db.Logins.Where(x => x.userName == userName && x.password == password).Count();
            if (count_user > 0)
            {
                UtilityClass.Username=userName;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
