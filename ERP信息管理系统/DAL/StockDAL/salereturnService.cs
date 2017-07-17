using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.NewFolder1;
using System.Data;
namespace DAL.NewFolder1
{
  public class salereturnService
    {
      public static DataTable GetOrderid()
       {
           string sqlstr = string.Format(@"select ReceiptOrderDate,ReceiptOrderID from t_BuyReceipt");
           DataTable dt = DBHelper.GetDataTable(sqlstr);
           return dt;
       }
      //获取采购订单时间
      public static DataTable GetTrandTime(string order)
      {
          string sqlstr = string.Format(@"select ReceiptOrderDate from t_BuyReceipt where ReceiptOrderID='{0}'",order);
          DataTable dt = DBHelper.GetDataTable(sqlstr);
          return dt;
      }
      //获取库房
      public static DataTable GetHouse(string buyorder)
      {
          string sqlstr = string.Format(@"select distinct st.HouseName,buy.StoreHouseID from t_BuyReceipt
                          buy,t_StoreHouse st,t_StoreHouseDetail sto where
                          buy.StoreHouseID=st.HouseID and buy.HouseDetailID=sto.HouseID and
                          buy.ReceiptOrderID='{0}'",buyorder);
          DataTable dt=DBHelper.GetDataTable(sqlstr);
          return dt;
      }
      //获取库区
      public static DataTable GetStore(string buyorder,int storehouse)
      {
          string sqlstr = string.Format(@"select sto.SubareaName,sto.ID,sto.HouseID from t_BuyReceipt
buy,t_StoreHouse st,t_StoreHouseDetail sto where
buy.StoreHouseID=st.HouseID and buy.HouseDetailID=sto.HouseID
and buy.ReceiptOrderID='{0}' and st.HouseID='{1}'",buyorder,storehouse);
          DataTable dt = DBHelper.GetDataTable(sqlstr);
          return dt;
      }
      //获取总价
      public static DataTable TotalPrice(string order)
      {
          string sqlstr = string.Format(@"select TotalPrice,AlreadyPay from t_BuyReceipt where ReceiptOrderID='{0}'",order);
          DataTable dt = DBHelper.GetDataTable(sqlstr);
          return dt;
      }
      //添加到退货数据库
      public static bool GetALL(addorder ad)
      {
          string sqlstr = string.Format(@"insert into t_BuyReturn (BuyReturnID,BuyReturnDate,StoreHouseID,HouseDetailID,ReceiptOrderID,UserName,TradeDate,TotalPrice,AlreadyPay,Description,State)
values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",ad.BuyReturnID,ad.BuyReturnDate,ad.StoreHouseID,ad.HouseDetailID,ad.ReceiptOrderID,ad.userName,ad.TradeDate,ad.TotalPrice,ad.AlreadyPay,ad.Description,ad.State);
          bool rows = DBHelper.ExecuteNon(sqlstr);
          return rows;
      }
      //通过入库单号查询商品信息
      public static DataTable GetProduct(string orderid)
      {
          string sqlstr = string.Format(@"select p.ProductsName,p.Price,buy.Quantity,buy.ReceiptOrderID,s.SupplierName,s.Description from
t_BuyReceiptDetail buy,t_Products p,t_Supplier s where buy.ProductsID=p.ProductsID
and buy.SupplierID=s.SupplierID and buy.ReceiptOrderID='{0}'",orderid);
          DataTable dt = DBHelper.GetDataTable(sqlstr);
          return dt;
      }
      //通过orderid 显示商品名
      public static DataTable GetP(string orderid)
      {
          string sqlstr = string.Format(@" select p.ProductsID,p.ProductsName from t_BuyReceiptDetail buy,t_Products p where
 buy.ProductsID=p.ProductsID and buy.ReceiptOrderID='{0}'",orderid);
          DataTable dt = DBHelper.GetDataTable(sqlstr);
          return dt;
      }
      //通过orderid 显示供应商名
      public static DataTable GetS(string orderid)
      {
          string sqlstr = string.Format(@"select s.SupplierID,s.SupplierName from t_BuyReceiptDetail buy,t_Supplier s where
 buy.SupplierID=s.SupplierID and buy.ReceiptOrderID='{0}'",orderid);
          DataTable dt = DBHelper.GetDataTable(sqlstr);
          return dt;
      }
      //通过orderid 添加商品信息
      public static bool GetA(addorder ad)
      {
          string sqlstr = string.Format(@"insert into t_BuyReturnDetail(BuyReturnID,ProductsID,SupplierID,Quantity,Price,Description)
values('{0}','{1}','{2}','{3}','{4}','{5}')",ad.BuyReturnID,ad.ProductsID,ad.SupplierID,ad.Quantity,ad.Price,ad.Description);
          bool rows = DBHelper.ExecuteNon(sqlstr);
          return rows;
      }
      //显示购买退货的所有信息
      public static List<addorder> GetAdd(int rows, int page)
      {
          string sqlstr = string.Format(@" select top {0} * from t_BuyReturn buy,t_BuyReturnDetail buyr,t_Supplier s,t_Products p
 where buy.BuyReturnID=buyr.BuyReturnID and buyr.ProductsID=p.ProductsID and 
 buyr.SupplierID=s.SupplierID and buy.ReceiptOrderID not in( select top {1} buy.ReceiptOrderID from t_BuyReturn buy,t_BuyReturnDetail buyr,t_Supplier s,t_Products p
 where buy.BuyReturnID=buyr.BuyReturnID and buyr.ProductsID=p.ProductsID and 
 buyr.SupplierID=s.SupplierID) ", rows, (page - 1) * rows);
          List<addorder> list = new List<addorder>();
          DataTable dt = DBHelper.GetDataTable(sqlstr);
          foreach (DataRow item in dt.Rows)
          {
              addorder ad = new addorder();
              ad.BuyReturnID = item["BuyReturnID"].ToString();
              ad.ProductsName = item["ProductsName"].ToString();
              ad.SupplierName = item["SupplierName"].ToString();
              ad.Quantity =Convert.ToInt32(item["Quantity"].ToString());
              ad.Price = item["Price"].ToString();
              ad.ReceiptOrderID = item["ReceiptOrderID"].ToString();
              ad.TotalPrice = item["TotalPrice"].ToString();
              ad.AlreadyPay = item["AlreadyPay"].ToString();
              list.Add(ad);
          }
          return list;
      }
      //显示总行数
      public static int GetHang()
      {
          string sqlstr = string.Format(@"select * from t_BuyReturn");
          DataTable dt = DBHelper.GetDataTable(sqlstr);
          return dt.Rows.Count;
      }
    }
}
