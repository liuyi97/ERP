using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.MagMdl;
using DAL.MagDAL;
 namespace BLL.MagBLL
{
    public class StockStatusManages
    {
        public static List<StockStatus> StockStatusinfo(int index, int count)
        {
            return StockStatusSerive.StockStatusinfo(index, count);
        }
        public static int StockStatuscount()
        {
            return StockStatusSerive.StockStatuscount();
        }
        public static List<t_StoreHouse> getA()
        {
            return StockStatusSerive.getA();
        }
        public static List<t_StoreHouseDetail> getA(int a)
        {
            return StockStatusSerive.getA(a);
        }
        public static List<StockStatus> StockStatusgetStoreName(string SubName, string StoreName, int index, int count)
        {
            return StockStatusSerive.StockStatusgetStoreName(SubName, StoreName, index, count);
        }
        public static int StockStatuscounta(string SubName, string StoreName, int index, int count)
        {
            return StockStatusSerive.StockStatuscounta(SubName, StoreName, index, count);
        }
      
        }
}
