using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.SysDAL;
using Model.SysModel;

namespace BLL.SysBLL
{
    public class UserTypeManager
    {
        public static List<UserType> UserTypeDrop()
        {
            return UserTypeService.StoreHouseDetailDrop();
        }
        public static List<UserType> UserTypeALL(int index, int rows)
        {
            return UserTypeService.UserTypeALL(index,rows);
        }
        public static int UserTypezong()
        {
            return UserTypeService.UserTypezong();
        }
        public static int UserTypeInsert(UserType s)
        {
            return UserTypeService.UserTypeInsert(s);
        }
        public static int UserTypeDelete(int id)
        {
            return UserTypeService.UserTypeDelete(id);
        }
        public static int UserTypeUpdate(UserType s)
        {
            return UserTypeService.UserTypeUpdate(s);
        }
        public static List<UserType> UserTypeID( int id)
        {
            return UserTypeService.UserTypeID(id);
        }
    }
}
