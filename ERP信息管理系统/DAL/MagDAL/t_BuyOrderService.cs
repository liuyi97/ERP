using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;
namespace DAL
{
    public static class t_BuyOrderService
    {
        public static List<t_BuyOrder> GetEmp(int index, int count)
        {
            string sql = string.Format(@"select top  {0}    BuyOrderID,BuyOrderDate,HouseName,TotalPrice,
SubareaName,UserName,t.StateName from t_BuyOrder b ,t_StoreHouse st ,t_Ste t 
  ,t_StoreHouseDetail sh where b.StoreHouseID=st.HouseID and t.StateID=b.State
  and b.HouseDetailID=sh.ID and BuyOrderID not in(select top {1} BuyOrderID from  t_BuyOrder) 
             ", count, (index - 1) * count);
            DataTable dt = DBHelper.GetDatatable(sql);
            List<t_BuyOrder> list = new List<t_BuyOrder>();
            foreach (DataRow item in dt.Rows)
            {
                t_BuyOrder e = new t_BuyOrder();
                e.BuyOrderID = item["BuyOrderID"].ToString();
                e.BuyOrderDate = item["BuyOrderDate"].ToString();
                e.HouseName = item["HouseName"].ToString();
                e.SubareaName = item["SubareaName"].ToString();
                e.TotalPrice = Convert.ToDouble(item["TotalPrice"]);
                e.StateName = item["StateName"].ToString();
                e.UserName = item["UserName"].ToString();
                list.Add(e);
            }
            return list;
        }
        public static int Getcount()
        {
            string sql = string.Format(@"select 
            BuyOrderID,BuyOrderDate,HouseName,TotalPrice,
SubareaName,UserName,t.StateName from t_BuyOrder b, t_StoreHouse st ,t_Ste t
  , t_StoreHouseDetail sh where b.StoreHouseID = st.HouseID and t.StateID = b.State
  and b.HouseDetailID = sh.ID");
            DataTable dt = DBHelper.GetDatatable(sql);
            return dt.Rows.Count;
        }

        public static int Getcounta()
        {
            string sql = string.Format(@"select  BuyOrderID,BuyOrderDate,HouseName,TotalPrice,
              SubareaName,UserName,t.StateName from t_BuyOrder b ,t_StoreHouse st ,t_Ste t 
     ,t_StoreHouseDetail sh where b.StoreHouseID=st.HouseID and t.StateID=b.State
           and b.HouseDetailID=sh.ID ");
            DataTable dt = DBHelper.GetDatatable(sql);
            return dt.Rows.Count;
        }
        public static List<t_BuyOrder> getIDdata(int index, int count, string orderid, string begin, string end,int dataid)
        {
            string sql = "";
                sql = string.Format(@"select  top {0} BuyOrderID, b.State, BuyOrderDate,HouseName,TotalPrice,
                SubareaName,UserName,t.StateName from t_BuyOrder b ,t_StoreHouse st ,t_Ste t 
              ,t_StoreHouseDetail sh where b.StoreHouseID=st.HouseID and t.StateID=b.State
              and b.HouseDetailID=sh.ID and BuyOrderID not
               in(select top {1} BuyOrderID from  t_BuyOrder) 
                  and (BuyOrderDate 
             between '{2}' and '{3}'  or   BuyOrderID= '{4}' or b.State={5}  )", count, (index - 1) * count, begin, end, orderid,dataid);
            DataTable dt = DBHelper.GetDatatable(sql);
            List<t_BuyOrder> list = new List<t_BuyOrder>();
            foreach (DataRow item in dt.Rows)
            {
                t_BuyOrder e = new t_BuyOrder();
                e.BuyOrderID = item["BuyOrderID"].ToString();
                e.BuyOrderDate = item["BuyOrderDate"].ToString();
                e.HouseName = item["HouseName"].ToString();
                e.SubareaName = item["SubareaName"].ToString();
                e.TotalPrice = Convert.ToDouble(item["TotalPrice"]);
                e.StateName = item["StateName"].ToString();
                e.UserName = item["UserName"].ToString();
                list.Add(e);
            }
            return list;
        }
        /// <summary>
        /// datagrid分页 传入 5个人参数
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <param name="orderid"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="dataid"></param>
        /// <returns></returns>
        public static List<t_BuyOrder> getIDdataa(int index, int count, string orderid, string begin, string end,int dataid)
        {
            string sql = "";
            sql = string.Format(@"select  top {0} BuyOrderID,b.State,BuyOrderDate,HouseName,TotalPrice,
                SubareaName,UserName,t.StateName from t_BuyOrder b ,t_StoreHouse st ,t_Ste t 
              ,t_StoreHouseDetail sh where b.StoreHouseID=st.HouseID and t.StateID=b.State
              and b.HouseDetailID=sh.ID and BuyOrderID not
               in(select top {1} BuyOrderID from  t_BuyOrder) 
                  and (BuyOrderDate 
             between '{2}' and '{3}'  and   BuyOrderID= '{4}' and b.State={5} )", count, (index - 1) * count, begin, end, orderid,dataid);
            DataTable dt = DBHelper.GetDatatable(sql);
            List<t_BuyOrder> list = new List<t_BuyOrder>();
            foreach (DataRow item in dt.Rows)
            {
                t_BuyOrder e = new t_BuyOrder();
                e.BuyOrderID = item["BuyOrderID"].ToString();
                e.BuyOrderDate = item["BuyOrderDate"].ToString();
                e.HouseName = item["HouseName"].ToString();
                e.SubareaName = item["SubareaName"].ToString();
                e.TotalPrice = Convert.ToDouble(item["TotalPrice"]);
                e.StateName = item["StateName"].ToString();
                e.UserName = item["UserName"].ToString();
                list.Add(e);
            }
            return list;
        }

        public  static bool getbuyid(string s)
        {
            string sql = string.Format(@"update t_BuyOrder set  State = 1 where BuyOrderID in ({0})", s);
            bool dt = DBHelper.ExecuteSql(sql);
            return dt;
        }
        public static bool getnotbuyid(string s)
        {
            string sql = string.Format(@"update t_BuyOrder set  State = 2 where BuyOrderID in ({0})", s);
            bool dt = DBHelper.ExecuteSql(sql);
            return dt;
        }

    }
}
