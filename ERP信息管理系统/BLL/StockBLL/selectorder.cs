using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.NewFolder1;
using DAL.NewFolder1;
using System.Data;
namespace BLL.NewFolder1
{
    //通过buyorderid查询数据
    public class selectorder
    {
        public static DataTable GetSelect(string id)
        {
            return selectorderdetail.GetSelect(id);
        }
        //通过库房id 查询库房名
        public static DataTable GetStoreDetail(int id)
        {
            return selectorderdetail.GetStore(id);
        }
        //通过库房id 查询库房名
        public static DataTable GetHouseDetail(int id)
        {
            return selectorderdetail.GetHouse(id);
        }
    }
}
