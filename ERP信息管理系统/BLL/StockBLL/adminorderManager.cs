using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.NewFolder1;
using DAL.NewFolder1;
namespace BLL.NewFolder1
{
  public  class adminorderManager
    {
        //采购订单管理局部查询
        public static List<addorder> GetAdmin(string BuyOrderID, string BuyOrderDate, string TradeDate, string Statename, int count, int index)
        {
            return adminorderService.GetAdmin(BuyOrderID, BuyOrderDate, TradeDate, Statename, count,index);
        }
        //采购订单管理查询
        public static List<addorder> GetAdminAll(string BuyOrderID, string BuyOrderDate, string TradeDate, string Statename, int count, int index)
        {
            return adminorderService.GetAdminAll(BuyOrderID, BuyOrderDate, TradeDate, Statename, count, index);
        }
        //采购订单总和
        public static int GetCount()
        {
            return adminorderService.GetCount();
        }
      //删除
        public static bool GetDelete(int id)
        {
            return adminorderService.GetDelete(id);
        }
        }
}
