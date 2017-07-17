using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.NewFolder1;
using System.Data;
namespace DAL.NewFolder1
{
  public  class adminorderService
    {
        //采购订单管理根据订单编号选择查询
        public static List<addorder> GetAdmin(string BuyOrderID, string BuyOrderDate, string TradeDate, string Statename, int count, int index)
        {
            List<addorder> list = new List<addorder>();
            string sqlstr = string.Format(@"select top '{0}' buy.BuyOrderID ,buy.BuyOrderDate ,buy.TradeDate  ,st.HouseName ,
                                                          ho.SubareaName ,buy.UserName ,buy.TotalPrice ,ste.StateName 
                                                          from t_BuyOrder buy,t_BuyOrderDetail buyo,t_StoreHouse st,
                                                          t_StoreHouseDetail ho,t_Ste ste where buy.BuyOrderID=buyo.BuyOrderID
                                                          and buy.StoreHouseID=st.HouseID and buy.HouseDetailID=ho.HouseID
                                                          and ste.StateID=buy.State  and buy.BuyOrderID not in(select top '{1}' BuyOrderID 
                                                          from t_BuyOrder) and (buy.BuyOrderID or
                                                          between '{2}' and  '{3}'   or buy.BuyOrderID='{4}' or ste.statename='{5}' )",
                                                          count,(index-1)*count,BuyOrderDate,TradeDate,BuyOrderID,Statename);
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            foreach (DataRow item in dt.Rows)
            {
                addorder ad = new addorder();
                ad.BuyOrderID = item["BuyOrderID"].ToString();
                ad.BuyOrderDate = item["BuyOrderDate"].ToString();
                ad.HouseName = item["HouseName"].ToString();
                ad.SubareaName = item["SubareaName"].ToString();
                ad.userName = item["userName"].ToString();
                ad.TotalPrice = item["TotalPrice"].ToString();
                ad.State = item["State"].ToString();
                list.Add(ad);
            }
            return list;
        }

        //采购订单管理根据订单编号以及其他条件进行全部查询
        public static List<addorder> GetAdminAll(string BuyOrderID, string BuyOrderDate, string TradeDate, string Statename, int count, int index)
        {
            List<addorder> list = new List<addorder>();
            string sqlstr = string.Format(@"select top '{0}' buy.BuyOrderID ,buy.BuyOrderDate ,buy.TradeDate  ,st.HouseName ,
                                                          ho.SubareaName ,buy.UserName ,buy.TotalPrice ,ste.StateName 
                                                          from t_BuyOrder buy,t_BuyOrderDetail buyo,t_StoreHouse st,
                                                          t_StoreHouseDetail ho,t_Ste ste where buy.BuyOrderID=buyo.BuyOrderID
                                                          and buy.StoreHouseID=st.HouseID and buy.HouseDetailID=ho.HouseID
                                                          and ste.StateID=buy.State  and buy.BuyOrderID not in(select top '{1}' BuyOrderID 
                                                          from t_BuyOrder) and (buy.BuyOrderID 
                                                           between '{2}' and '{3}' and buy.BuyOrderID='{4}'   and ste.statename='{5}' ",
                                                          count, (index - 1) * count,  BuyOrderDate, TradeDate,BuyOrderID, Statename);
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            foreach (DataRow item in dt.Rows)
            {
                addorder ad = new addorder();
                ad.BuyOrderID = item["BuyOrderID"].ToString();
                ad.BuyOrderDate = item["BuyOrderDate"].ToString();
                ad.HouseName = item["HouseName"].ToString();
                ad.SubareaName = item["SubareaName"].ToString();
                ad.userName = item["userName"].ToString();
                ad.TotalPrice = item["TotalPrice"].ToString();
                ad.State = item["Statename"].ToString();
                list.Add(ad);
            }
            return list;
        }

        //采购管理总行数
        public static int GetCount()
        {
            String sqlstr = string.Format(@"select  *  from t_BuyOrder buy,t_BuyOrderDetail buyo,t_StoreHouse st,
                   t_StoreHouseDetail ho,t_Ste ste where buy.BuyOrderID=buyo.BuyOrderID
                   and buy.StoreHouseID=st.HouseID and buy.HouseDetailID=ho.HouseID and ste.StateID=buy.State");
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            return dt.Rows.Count;
        }
      //删除
        public static bool GetDelete(int id)
        {
            string sqlstr = string.Format(@"delete  from t_BuyOrder where BuyOrderID='{0}'");
            bool rows= DBHelper.ExecuteNon(sqlstr);
            return rows;
        }
    }
}
