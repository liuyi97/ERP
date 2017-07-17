using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;
namespace DAL.MagDAL
{
      public class t_BuyReturnService
    {
          public static List<t_BuyReturn> getReturnInfo(int index, int count)
          {
              string sql = "";
              sql = string.Format(@"select  top {0} RT.BuyReturnID,RT.BuyReturnDate,S.HouseName,H.SubareaName,
                        RT.UserName,RT.TotalPrice,st.StateName   from  t_BuyReturn rt,t_StoreHouse s,t_StoreHouseDetail h ,t_Ste st where 
                   rt.HouseDetailID=s.HouseID and rt.StoreHouseID=h.ID and rt.State=st.StateID and 
                         BuyReturnID not
               in(select top {1} BuyReturnID from  t_BuyReturn) ", count, (index - 1) * count);
              DataTable dt = DBHelper.GetDatatable(sql);
              List<t_BuyReturn> list = new List<t_BuyReturn>();
              foreach (DataRow item in dt.Rows)
              {
                  t_BuyReturn e = new t_BuyReturn();
                  e.BuyReturnID = item["BuyReturnID"].ToString();
                  e.BuyReturnDate = item["BuyReturnDate"].ToString();
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
            string sql = string.Format(@"select  RT.BuyReturnID,RT.BuyReturnDate,S.HouseName,H.SubareaName,
                        RT.UserName,RT.TotalPrice,st.StateName   from  t_BuyReturn rt,t_StoreHouse s,t_StoreHouseDetail h ,t_Ste st where 
                   rt.HouseDetailID=s.HouseID and rt.StoreHouseID=h.ID and rt.State=st.StateID ");
            DataTable dt = DBHelper.GetDatatable(sql);
            return dt.Rows.Count;
        }
        public static List<t_BuyReturn> getReturninfoandid(int index, int count, string orderid, string begin, string end, int receorderid)
        {
            string sql = "";
            sql = string.Format(@"select {0} RT.BuyReturnID,RT.BuyReturnDate,S.HouseName,H.SubareaName,
                        RT.UserName,RT.TotalPrice,st.StateName   from  t_BuyReturn rt,t_StoreHouse s,t_StoreHouseDetail 
             h ,t_Ste st where     rt.HouseDetailID=s.HouseID and rt.StoreHouseID=h.ID and rt.State=st.StateID and           
              BuyReturnID not  in(select top {1} BuyReturnID from  t_BuyReturn
                and (BuyReturnDate between '{2}' and '{3}'  and BuyReturnID='{4}' and RT.State={5})", 
                  count, (index - 1) * count, begin, end, orderid, receorderid);
            DataTable dt = DBHelper.GetDatatable(sql);
            List<t_BuyReturn> list = new List<t_BuyReturn>();
            foreach (DataRow item in dt.Rows)
            {
                t_BuyReturn e = new t_BuyReturn();
                e.BuyReturnID = item["BuyReturnID"].ToString();
                e.BuyReturnDate = item["BuyReturnDate"].ToString();
                e.HouseName = item["HouseName"].ToString();
                e.SubareaName = item["SubareaName"].ToString();
                e.TotalPrice = Convert.ToInt32(item["TotalPrice"]);
                e.StateName = item["StateName"].ToString();
                e.UserName = item["UserName"].ToString();
                list.Add(e);
            }
            return list;
        }
        public static List<t_BuyReturn> getReturninfoorid(int index, int count, string orderid, string begin, string end, int receorderid)
        {
            string sql = "";
            sql = string.Format(@"select  top {0} RT.BuyReturnID,RT.BuyReturnDate,S.HouseName,H.SubareaName,
                        RT.UserName,RT.TotalPrice,st.StateName   from  t_BuyReturn rt,t_StoreHouse s,t_StoreHouseDetail 
             h ,t_Ste st where     rt.HouseDetailID=s.HouseID and rt.StoreHouseID=h.ID and rt.State=st.StateID and           
              BuyReturnID not  in(select top {1} BuyReturnID from  t_BuyReturn)
                and (BuyReturnDate between '{2}' and '{3}'  or BuyReturnID='{4}' or RT.State={5})",
                  count, (index - 1) * count, begin, end, orderid, receorderid);
            DataTable dt = DBHelper.GetDatatable(sql);
            List<t_BuyReturn> list = new List<t_BuyReturn>();
            foreach (DataRow item in dt.Rows)
            {
                t_BuyReturn e = new t_BuyReturn();
                e.BuyReturnID = item["BuyReturnID"].ToString();
                e.BuyReturnDate = item["BuyReturnDate"].ToString();
                e.HouseName = item["HouseName"].ToString();
                e.SubareaName = item["SubareaName"].ToString();
                e.TotalPrice = Convert.ToInt32(item["TotalPrice"]);
                e.StateName = item["StateName"].ToString();
                e.UserName = item["UserName"].ToString();
                list.Add(e);
            }
            return list;
        }
        public static bool buyReturnsheng(string s)
        {
            string sql = string.Format(@"update t_BuyReturn set  State = 2 where BuyReturnID in ({0})", s);
            bool dt = DBHelper.ExecuteSql(sql);
            return dt;
        }
        public static bool buyReturnDel(string s)
        {
            string sql = string.Format("delete from t_BuyReturn where BuyReturnID=" + s);
            bool dt = DBHelper.ExecuteSql(sql);
            return dt;
        }


        }
}
