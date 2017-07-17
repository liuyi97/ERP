using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
namespace BLL
{
    public  class t_UserManages
    { 
        public static  int getlogin(t_User u)
        {
            return t_UserService.getLogin(u);
                 
        }
        public static int getLoginTypeid(t_User u)
        {
            return t_UserService.getLoginTypeid(u);
        }
        }
}
