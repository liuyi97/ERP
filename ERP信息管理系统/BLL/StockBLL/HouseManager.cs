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
    //库房库区级联
  public  class HouseManager
    {
        //库房
        public static List<StoreHouse> GetStore()
        {
            return HouseSeriver.GetStore();
        }
        //库区
        public static List<HouseDetail> GetHouse(int index)
        {
            return HouseSeriver.GetHouse(index);
        }
    }
}
