using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.SysDAL;
using Model.SysModel;

namespace BLL.SysBLL
{
    public class StoreHouseManager
    {
        public static int StoreHouseInsert(StoreHouse s)
        {
            return StoreHouseService.StoreHouseInsert(s);
        }
        public static List<StoreHouse> StoreHouseALL(int index, int rows)
        {
            return StoreHouseService.StoreHouseALL(index,rows);
        }
        public static int StoreHousezong()
        {
            return StoreHouseService.StoreHousezong();
        }

        public static int StoreHouseDelete(int id)
        {
            return StoreHouseService.StoreHouseDelete(id);
        }
        public static int StoreHouseUpdate(StoreHouse s)
        {
            return StoreHouseService.StoreHouseUpdate(s);
        }
        public static List<StoreHouse> StoreHouseID(int id)
        {
            return StoreHouseService.StoreHouseID(id);
        }
    }
}
