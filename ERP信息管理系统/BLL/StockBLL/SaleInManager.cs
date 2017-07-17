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
  public  class SaleInManager
    {
        //订单编号显示
        public static DataTable GetOrderSelect()
        {
            return SaleInService.GetOrderSel();
        }
        //根据订单编号显示库房
        public static DataTable GetStore(string orderid)
        {
            return SaleInService.GetStore(orderid);
        }
        //根据订单编号和库房显示库区
        public static DataTable GetHouse(string orderid, int  storehouse)
        {
            return SaleInService.GetHouse(orderid,storehouse);
        }
        //添加信息到采购入库中
        public static bool GetSale(addorder ad)
        {
            return SaleInService.GetSale(ad);
        }
        //通过订单编号查询商品信息
        public static DataTable GetProduct(string BuyOrderID)
        {
            return SaleInService.GetProduct(BuyOrderID);
        }
        //添加信息到采购入库详情
        public static bool insertProduct(addorder ad)
        {
            return SaleInService.insertProduct(ad);
        }
        //通过订单编号dropdownlist控件显示商品名
        public static DataTable GetProductname(string BuyOrderID)
        {
            return SaleInService.GetProductname(BuyOrderID);
        }
        //通过订单编号dropdownlist显示供应商名
        public static DataTable GetSupplier(string BuyOrderID)
        {
           return SaleInService.GetSupplier(BuyOrderID);
        }
        //商品总信息显示datagrid控件中
        public static List<addorder> GetNum(int count,int index)
        {
            return SaleInService.GetNum(count,index);
        }
        //返回总行数
        public static int GetSum()
        {
              return SaleInService.GetSum();
        }
        //通过buyorderid 查询所有数据
        public static DataTable GetSaleDetail(string id)
        {
               return SaleInService.GetSaleDetail(id);
        }
        //通过buyordereid 的id查询库房名
        public static DataTable GetSaleStore(string ReceiptOrderID)
        {
            return SaleInService.GetSaleStore(ReceiptOrderID);
        }
        //通过buyorderid id，houseid 查询库区
        public static DataTable GetSaleHouse(string ReceiptOrderID, int HouseID)
        {
            return SaleInService.GetSaleHouse(ReceiptOrderID, HouseID);
        }
    }
}
