using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.SysDAL;
using Model.SysModel;

namespace BLL.SysBLL
{
    public class StoreHouseDetailManager
    {
        public static List<StoreHouseDetail> StoreHouseDetailDrop()
        {
            return StoreHouseDetailService.StoreHouseDetailDrop();
        }
        public static List<StoreHouseDetail> StoreHouseDetailALL(int index, int rows)
        {
            return StoreHouseDetailService.StoreHouseDetailALL(index,rows);
        }
        public static int StoreHouseDetailzong()
        {
            return StoreHouseDetailService.StoreHouseDetailzong();
        }
        public static int StoreHouseDetailInsert(StoreHouseDetail s)
        {
            return StoreHouseDetailService.StoreHouseDetailInsert(s);
        }
        public static int StoreHouseDetailDelete(int id)
        {
            return StoreHouseDetailService.StoreHouseDetailDelete(id);
        }
        public static int StoreHouseDetailUpdate(StoreHouseDetail s)
        {
            return StoreHouseDetailService.StoreHouseDetailUpdate(s);
        }
        public static List<StoreHouseDetail> StoreHouseDetailID(int id)
        {
            return StoreHouseDetailService.StoreHouseDetailID(id);
        }
    }
}
