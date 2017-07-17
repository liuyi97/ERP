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
   public class salereturnManager
    {
       public static DataTable GetOrderid()
       {
           return salereturnService.GetOrderid();
       }
       //获取采购订单时间
       public static DataTable GetTrandTime(string order)
       {
           return salereturnService.GetTrandTime(order);
       }
       //获取库房
       public static DataTable GetHouse(string buyorder)
       {
           return salereturnService.GetHouse(buyorder);
       }
       //获取库区
       public static DataTable GetStore(string buyorder, int storehouse)
       {
           return salereturnService.GetStore(buyorder, storehouse);
       }
       //获取总价
       public static DataTable TotalPrice(string order)
       {
           return salereturnService.TotalPrice(order);
       }
       //添加到退货数据库
       public static bool GetALL(addorder ad)
       {
           return salereturnService.GetALL(ad);
       }
       //通过入库单号查询商品信息
       public static DataTable GetProduct(string orderid)
       {
           return salereturnService.GetProduct(orderid);
       }
       //通过orderid 显示商品名
       public static DataTable GetS(string orderid)
       {
           return salereturnService.GetS(orderid);
       }
       //通过orderid 显示供应商名
       public static DataTable GetP(string orderid)
       {
           return salereturnService.GetP(orderid);
       }
       //通过orderid 添加商品信息
       public static bool GetA(addorder ad)
       {
           return salereturnService.GetA(ad);
       }
       //显示购买退货的所有信息
       public static List<addorder> GetAdd(int rows, int page)
       {
           return salereturnService.GetAdd(rows,page);
       }
       //显示总行数
       public static int GetHang()
       {
           return salereturnService.GetHang();
       }
    }
}
