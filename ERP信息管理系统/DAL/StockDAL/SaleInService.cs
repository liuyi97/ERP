using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.NewFolder1;
using System.Data;
namespace DAL.NewFolder1
{
 public   class SaleInService
    {
        //订单编号显示
        public static DataTable GetOrderSel()
        {
            string sqlstr = string.Format(@"select distinct buy.BuyOrderID from t_BuyOrder buy,t_StoreHouse sto,t_StoreHouseDetail ho
                                         where buy.StoreHouseID=sto.HouseID and buy.HouseDetailID=ho.HouseID");
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            return dt;
        }
     //根据订单编号显示库房
        public static DataTable GetStore(string orderid)
        {
            string sqlstr = string.Format(@"select st.HouseName,st.HouseID from t_BuyOrder buy,t_StoreHouse st
                           where buy.StoreHouseID=st.HouseID and buy.BuyOrderID='{0}'",orderid);
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            return dt;
        }
     //根据订单编号和库房显示库区
        public static DataTable GetHouse(string orderid,int  storehouse)
        {
            string sqlstr = string.Format(@"select sto.SubareaName,sto.ID from t_BuyOrder buy,t_StoreHouse st,t_StoreHouseDetail sto
                                          where buy.StoreHouseID=st.HouseID and buy.HouseDetailID=sto.HouseID
                                          and buy.BuyOrderID='{0}'and st.HouseID='{1}'", orderid, storehouse);
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            return dt;
        }
        //添加信息到采购入库中
        public static bool GetSale(addorder ad)
        {
            string sqlstr = string.Format(@"insert into t_BuyReceipt(ReceiptOrderID,ReceiptOrderDate,StoreHouseID,
                                                         HouseDetailID,BuyOrderID,TradeDate,UserName,TotalPrice,State,Description)
                                                         values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')",ad.ReceiptOrderID,ad.ReceiptOrderDate,
                                                         ad.StoreHouseID,ad.HouseDetailID,ad.BuyOrderID,ad.TradeDate,ad.userName,ad.TotalPrice,ad.State,ad.Description);
            bool  dt = DBHelper.ExecuteNon(sqlstr);
            return dt;
        }
        //通过订单编号查询商品信息
        public static DataTable GetProduct(string BuyOrderID)
        {
            string sqlstr = string.Format(@"select p.ProductsName,p.ProductsID,p.Price,buyo.Quantity,buyo.TaxRate,
buyo.DiscountRate,su.SupplierName,su.Description from t_BuyOrder buy,t_BuyOrderDetail buyo,t_Products p,
t_Supplier su where buy.BuyOrderID=buyo.BuyOrderID and buyo.ProductsID=p.ProductsID and buyo.SupplierID=su.SupplierID
and buy.BuyOrderID='{0}'", BuyOrderID);
            DataTable rows = DBHelper.GetDataTable(sqlstr);
            return rows;
        }
        //添加信息到采购入库详情
        public static bool insertProduct(addorder ad)
        {
            string sqlstr = string.Format(@"insert into t_BuyReceiptDetail(ProductsID,Price,Quantity,TaxRate,DiscountRate,SupplierID,Description,ReceiptOrderID)
                                                           values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", ad.ProductsID,ad.Price,ad.Quantity,ad.TaxRate,ad.DiscountRate,ad.ProductsID,
                                                           ad.Description,ad.ReceiptOrderID);
            bool dt = DBHelper.ExecuteNon(sqlstr);
            return dt;
        }
        //通过订单编号dropdownlist控件显示商品名
        public static DataTable GetProductname(string BuyOrderID)
        {
            string sqlstr = string.Format(@"select p.ProductsID,p.ProductsName from t_BuyOrderDetail buy,
                                                  t_Products p where buy.ProductsID=p.ProductsID and buy.BuyOrderID='{0}'",BuyOrderID);
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            return dt;
        }
        //通过订单编号dropdownlist显示供应商名
        public static DataTable GetSupplier(string BuyOrderID)
        {
            string sqlstr = string.Format(@"select su.SupplierID,su.SupplierName from
                                                     t_BuyOrderDetail buy,t_Supplier su where buy.SupplierID=su.SupplierID and
                                                     buy.BuyOrderID='{0}'",BuyOrderID);
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            return dt;
        }
        //商品总信息显示datagrid控件中
        public static List<addorder> GetNum(int count,int index)
        {
            string sqlstr = string.Format(@"select top {0}  p.ProductsID,p.ProductsName,su.SupplierName,buyo.Quantity,buy.TotalPrice,
buyo.TaxRate,buyo.DiscountRate,buyo.Price from t_Products p,t_Supplier su,t_BuyReceipt buy,
t_BuyReceiptDetail buyo where buy.ReceiptOrderID=buyo.ReceiptOrderID and buyo.ProductsID=p.ProductsID
and su.SupplierID=buyo.SupplierID
 and buyo.DetailID not in(select top {1} buyo.DetailID  from t_Products p,
t_Supplier su,t_BuyReceipt buy,t_BuyReceiptDetail buyo where buy.ReceiptOrderID=buyo.ReceiptOrderID and
buyo.ProductsID=p.ProductsID and su.SupplierID=buyo.SupplierID)order by buyo.DetailID", count, (index - 1) * count);
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            List<addorder> list = new List<addorder>();
            foreach (DataRow item in dt.Rows)
            {
                addorder ad = new addorder();
                ad.ProductsID =Convert.ToInt32( item["ProductsID"].ToString());
                ad.ProductsName = item["ProductsName"].ToString();
                ad.SupplierName = item["SupplierName"].ToString();
                ad.Quantity = Convert.ToInt32(item["Quantity"].ToString());
                ad.TotalPrice = item["TotalPrice"].ToString();
                ad.TaxRate = item["TaxRate"].ToString();
                ad.DiscountRate = item["DiscountRate"].ToString();
                ad.Price = item["Price"].ToString();
                list.Add(ad);
            }
            return list;
        }
        //返回总行数
        public static int GetSum()
        {
            string sqlstr = string.Format(@" select * from t_BuyReceiptDetail");
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            return dt.Rows.Count;
        }
     //通过buyorderid 查询所有数据
        public static DataTable GetSaleDetail(string id)
        {
            string sqlstr = string.Format(@"select b.ReceiptOrderID,b.ReceiptOrderDate,b.UserName,b.TotalPrice,
ste.StateName,b.TradeDate,b.Description from t_BuyReceipt b ,t_StoreHouse st,t_StoreHouseDetail ho,
t_Ste ste where b.StoreHouseID=st.HouseID and b.HouseDetailID=ho.HouseID and b.State=ste.StateID
and b.ReceiptOrderID='{0}'",id);
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            return dt;
        }
     //通过buyordereid 的id查询库房名
        public static DataTable GetSaleStore(string ReceiptOrderID)
        {
            string sqlstr = string.Format(@"select st.HouseName,st.HouseID from t_BuyReceipt b,t_StoreHouse st where b.StoreHouseID=st.HouseID 
and b.ReceiptOrderID='{0}'", ReceiptOrderID);
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            return dt;
        }
     //通过buyorderid id，houseid 查询库区
        public static DataTable GetSaleHouse(string ReceiptOrderID,int HouseID)
        {
            string sqlstr = string.Format(@"select sto.SubareaName,sto.ID from t_BuyReceipt buy,t_StoreHouseDetail sto,t_StoreHouse st where buy.StoreHouseID=sto.HouseID
and buy.HouseDetailID=st.HouseID and buy.ReceiptOrderID='{0}' and st.HouseID='{1}'", ReceiptOrderID, HouseID);
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            return dt;
        }
    }
}
