using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.SysDAL;
using Model.SysModel;
using System.Data;

namespace BLL.SysBLL
{
    public class UserManager
    {
        public static List<User> dingleiDrop()
        {
            return UserService.dingleiDrop();
        }
        public static List<User> leiDrop()
        {
            return UserService.leiDrop();
        }

        public static List<User> quanDrop()
        {
            return UserService.quanDrop();
        }

        public static List<User> UserALL(int index, int rows)
        {
            return UserService.UserALL(index,rows);
        }
        public static int Userzong()
        {
            return UserService.Userzong();
        }
        public static int UserInsert(User s)
        {
            return UserService.UserInsert(s);
        }
        public static int UserDelete(string name)
        {
            return UserService.UserDelete(name);
        }
        public static int UserUpdate(User s)
        {
            return UserService.UserUpdate(s);
        }
        public static List<User> UserID(string name)
        {
            return UserService.UserID(name);
        }
    }
}
