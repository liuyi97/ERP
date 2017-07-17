using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.NewFolder1;
namespace DAL.NewFolder1
{
  public  class addorderService
    {
        //添加采购订单
        public static bool AddSaleorder(addorder ad)
        {
            string strsql = string.Format(@"insert into t_BuyOrder (BuyOrderID,BuyOrderDate,UserName,StoreHouseID,HouseDetailID,SignDate,TradeDate,TradeAddress,Description,TotalPrice,state)
                                                         values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                                                      ad.BuyOrderID,ad.BuyOrderDate,ad.userName,ad.StoreHouseID,ad.HouseDetailID,ad.SignDate,ad.TradeDate,ad.TradeAddress,ad.Description,ad.TotalPrice,ad.State);
            bool rows = DBHelper.ExecuteNon(strsql);
            return rows;
        }
        //添加商品信息
        public static bool AddProduct(addorder ad)
        {
            string sqlstr = string.Format(@"insert into t_BuyOrderDetail(ProductsID,Price,Quantity,TaxRate,DiscountRate,SupplierID,Description,BuyOrderID)
                                                values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", ad.ProductsID,ad.Price,ad.Quantity,ad.TaxRate,ad.DiscountRate,ad.SupplierID,ad.Description,ad.BuyOrderID);
            bool rows = DBHelper.ExecuteNon(sqlstr);
            return rows;
        }
    }
}
