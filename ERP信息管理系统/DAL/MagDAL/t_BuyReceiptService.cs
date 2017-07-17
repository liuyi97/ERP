using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models.MagMdl;
namespace DAL
{
   public  class t_BuyReceiptService
    {
       /// <summary>
       /// OR 选择类型
       /// </summary>
       /// <param name="index"></param>
       /// <param name="count"></param>
       /// <param name="orderid"></param>
       /// <param name="begin"></param>
       /// <param name="end"></param>
       /// <param name="receorderid"></param>
       /// <returns></returns>
        public static List<t_BuyReceipt> GetBuyReceipt(int index, int count, string orderid, string begin, string end, int receorderid)
        {
            string sql = "";
            sql = string.Format(@"select top {0}  r.ReceiptOrderID,r.ReceiptOrderDate ,s.HouseName,h.SubareaName
                   ,r.UserName,r.TotalPrice,t.StateName
              from t_BuyReceipt r,t_StoreHouse s,t_StoreHouseDetail h,t_Ste t where
               r.State=t.StateID and r.HouseDetailID=s.HouseID and r.StoreHouseID=h.ID 
               and t.StateID=r.State and  ReceiptOrderID not
               in(select top {1} ReceiptOrderID from  t_BuyReceipt) 
                 and (ReceiptOrderDate 
             between '{2}' and '{3}'  or ReceiptOrderID= '{4}' or r.State={5})", count, (index - 1) * count, begin, end, orderid, receorderid);

            DataTable dt = DBHelper.GetDatatable(sql);
            List<t_BuyReceipt> list = new List<t_BuyReceipt>();
            foreach (DataRow item in dt.Rows)
            {
                t_BuyReceipt e = new t_BuyReceipt();
                e.ReceiptOrderID= item["ReceiptOrderID"].ToString();
                e.ReceiptOrderDate = item["ReceiptOrderDate"].ToString();
                e.HouseName = item["HouseName"].ToString();
                e.SubareaName = item["SubareaName"].ToString();
                e.TotalPrice = Convert.ToInt32(item["TotalPrice"]);
                e.StateName = item["StateName"].ToString();
                e.UserName = item["UserName"].ToString();
                list.Add(e);
            }
            return list;
        }

/// <summary>
///  AND 选择类型
/// </summary>
/// <param name="index"></param>
/// <param name="count"></param>
/// <param name="orderid"></param>
/// <param name="begin"></param>
/// <param name="end"></param>
/// <param name="receorderid"></param>
/// <returns></returns>
        public static List<t_BuyReceipt> GetBuyAReceipt(int index, int count, string orderid, string begin, string end, int receorderid)
        {
            string sql = "";
            sql = string.Format(@"select top {0}  r.ReceiptOrderID,r.ReceiptOrderDate ,s.HouseName,h.SubareaName
                   ,r.UserName,r.TotalPrice,t.StateName
              from t_BuyReceipt r,t_StoreHouse s,t_StoreHouseDetail h,t_Ste t where
               r.State=t.StateID and r.HouseDetailID=s.HouseID and r.StoreHouseID=h.ID 
               and t.StateID=r.State and  ReceiptOrderID not
               in(select top {1} ReceiptOrderID from  t_BuyReceipt) 
                 and (ReceiptOrderDate 
             between '{2}' and '{3}'  and ReceiptOrderID='{4}' and r.State={5})", count, (index - 1) * count, begin, end, orderid, receorderid);

            DataTable dt = DBHelper.GetDatatable(sql);
            List<t_BuyReceipt> list = new List<t_BuyReceipt>();
            foreach (DataRow item in dt.Rows)
            {
                t_BuyReceipt e = new t_BuyReceipt();
                e.ReceiptOrderID = item["ReceiptOrderID"].ToString();
                e.ReceiptOrderDate = item["ReceiptOrderDate"].ToString();
                e.HouseName = item["HouseName"].ToString();
                e.SubareaName = item["SubareaName"].ToString();
                e.TotalPrice = Convert.ToInt32(item["TotalPrice"]);
                e.StateName = item["StateName"].ToString();
                e.UserName = item["UserName"].ToString();
                list.Add(e);
            }
            return list;
        }

        public static List<t_BuyReceipt> getinfobuyreceipt(int index, int count)
        {
            string sql = "";
            sql = string.Format(@"select top {0}  r.ReceiptOrderID,r.ReceiptOrderDate ,s.HouseName,h.SubareaName
                   ,r.UserName,r.TotalPrice,t.StateName
              from t_BuyReceipt r,t_StoreHouse s,t_StoreHouseDetail h,t_Ste t where
               r.State=t.StateID and r.HouseDetailID=s.HouseID and r.StoreHouseID=h.ID 
               and t.StateID=r.State and  ReceiptOrderID not
               in(select top {1} ReceiptOrderID from  t_BuyReceipt) ", count, (index - 1) * count);
            DataTable dt = DBHelper.GetDatatable(sql);
            List<t_BuyReceipt> list = new List<t_BuyReceipt>();
            foreach (DataRow item in dt.Rows)
            {
                t_BuyReceipt e = new t_BuyReceipt();
                e.ReceiptOrderID = item["ReceiptOrderID"].ToString();
                e.ReceiptOrderDate = item["ReceiptOrderDate"].ToString();
                e.HouseName = item["HouseName"].ToString();
                e.SubareaName = item["SubareaName"].ToString();
                e.TotalPrice = Convert.ToInt32(item["TotalPrice"]);
                e.StateName = item["StateName"].ToString();
                e.UserName = item["UserName"].ToString();
                list.Add(e);
            }
            return list;
        }

        public static int Getcount()
        {
            string sql = string.Format(@"select  r.ReceiptOrderID,r.ReceiptOrderDate ,s.HouseName,h.SubareaName
                   ,r.UserName,r.TotalPrice,t.StateName
              from t_BuyReceipt r,t_StoreHouse s,t_StoreHouseDetail h,t_Ste t where
               r.State=t.StateID and r.HouseDetailID=s.HouseID and r.StoreHouseID=h.ID 
               and t.StateID=r.State");
            DataTable dt = DBHelper.GetDatatable(sql);
            return dt.Rows.Count;
        }

        public static bool Buyreceiptid(string s)
        {
            string sql = string.Format(@"update t_BuyReceipt set  State = 1 where ReceiptOrderID in ({0})", s);
            bool dt = DBHelper.ExecuteSql(sql);
            return dt;
        }
        public static bool Buynotreceiptid(string s)
        {
            string sql = string.Format(@"update t_BuyReceipt set  State = 2 where ReceiptOrderID in ({0})", s);
            bool dt = DBHelper.ExecuteSql(sql);
            return dt;
        }
    }
}
