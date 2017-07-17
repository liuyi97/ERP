using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.NewFolder1;
using System.Data;
namespace DAL.NewFolder1
{
   public  class adminInPService
    {
        //状态显示
        public static DataTable GetSatate()
        {
            string sqlstr = string.Format(@"select StateID,StateName from t_Ste");
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            return dt;
        }
        //单据号显示
        public static DataTable GetOutID()
        {
            string sqlstr = string.Format(@"select OutID from t_OutStock");
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            return dt;
        }
        //分页显示总行数
        public static List<addorder> GetAll(int rows,int page)
        {
            string sqlstr = string.Format(@"select top {0} outs.DetailID, p.ProductsName,out.OutID,out.CreateDate,st.HouseName,
sto.SubareaName,out.TradeDate,outs.Quantity,outs.Price,s.StateName
from t_OutStock out,t_OutStockDetail outs,t_Products p,t_Ste s,t_StoreHouse st
,t_StoreHouseDetail sto where out.OutID=outs.OutID and p.ProductsID=outs.ProductsID
and s.StateID=out.State and out.StoreHouseID=st.HouseID and out.HouseDetailID=sto.ID
and outs.DetailID not in (select top {1} DetailID
from t_OutStock out,t_OutStockDetail outs,t_Products p,t_Ste s,t_StoreHouse st
,t_StoreHouseDetail sto where out.OutID=outs.OutID and p.ProductsID=outs.ProductsID
and s.StateID=out.State and out.StoreHouseID=st.HouseID and out.HouseDetailID=sto.ID)", rows, (page - 1) * rows);
            List<addorder> list = new List<addorder>();
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            foreach (DataRow item in dt.Rows)
            {
                addorder ad = new addorder();
                ad.DetailID =Convert.ToInt32(item["DetailID"].ToString());
                ad.ProductsName= item["ProductsName"].ToString();
                ad.OutID= item["OutID"].ToString();
                ad.CreateDate= item["CreateDate"].ToString();
                ad.HouseName= item["HouseName"].ToString();
                ad.SubareaName= item["SubareaName"].ToString();
                ad.TradeDate= item["TradeDate"].ToString();
                ad.Quantity= Convert.ToInt32(item["Quantity"].ToString());
                ad.Price=item["Price"].ToString();
                ad.StateName= item["StateName"].ToString();
                list.Add(ad);
            }
            return list;
        }
        //获取总行数
        public static int GetHang()
        {
            string sqlstr = "select * from t_OutStock";
            DataTable rows = DBHelper.GetDataTable(sqlstr);
            return rows.Rows.Count;
        }
        //判断条件,都满足的情况下
        public static List<addorder> GetSelect(int rows, int page,string outid,string create,string trade,int statename)
        {
            string sqlstr = string.Format(@"select top {0} outs.DetailID, p.ProductsName,out.OutID,out.CreateDate,st.HouseName,
sto.SubareaName,out.TradeDate,outs.Quantity,outs.Price,s.StateName
from t_OutStock out,t_OutStockDetail outs,t_Products p,t_Ste s,t_StoreHouse st
,t_StoreHouseDetail sto where out.OutID=outs.OutID and p.ProductsID=outs.ProductsID
and s.StateID=out.State and out.StoreHouseID=st.HouseID and out.HouseDetailID=sto.ID
and outs.DetailID not in (select top {1} DetailID
from t_OutStock out,t_OutStockDetail outs,t_Products p,t_Ste s,t_StoreHouse st
,t_StoreHouseDetail sto where out.OutID=outs.OutID and p.ProductsID=outs.ProductsID
and s.StateID=out.State and out.StoreHouseID=st.HouseID and out.HouseDetailID=sto.ID)and out.OutID='{2}' 
and out.CreateDate between '{3}' and '{4}' and s.StateID='{5}'", rows, (page - 1) * rows, outid, create, trade, statename);
            List<addorder> list = new List<addorder>();
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            foreach (DataRow item in dt.Rows)
            {
                addorder ad = new addorder();
                ad.DetailID = Convert.ToInt32(item["DetailID"].ToString());
                ad.ProductsName = item["ProductsName"].ToString();
                ad.OutID = item["OutID"].ToString();
                ad.CreateDate = item["CreateDate"].ToString();
                ad.HouseName = item["HouseName"].ToString();
                ad.SubareaName = item["SubareaName"].ToString();
                ad.TradeDate = item["TradeDate"].ToString();
                ad.Quantity = Convert.ToInt32(item["Quantity"].ToString());
                ad.Price = item["Price"].ToString();
                ad.StateName = item["StateName"].ToString();
                list.Add(ad);
            }
            return list;
        }
        //判断条件,多者满足其中之一即可,通过statename来查询
        public static List<addorder> GetS(int rows,int page,int statename)
        {
            string sqlstr = string.Format(@"select top {0} outs.DetailID, p.ProductsName,out.OutID,out.CreateDate,st.HouseName,
sto.SubareaName,out.TradeDate,outs.Quantity,outs.Price,s.StateName
from t_OutStock out,t_OutStockDetail outs,t_Products p,t_Ste s,t_StoreHouse st
,t_StoreHouseDetail sto where out.OutID=outs.OutID and p.ProductsID=outs.ProductsID
and s.StateID=out.State and out.StoreHouseID=st.HouseID and out.HouseDetailID=sto.ID
and outs.DetailID not in (select top {1} DetailID
from t_OutStock out,t_OutStockDetail outs,t_Products p,t_Ste s,t_StoreHouse st
,t_StoreHouseDetail sto where out.OutID=outs.OutID and p.ProductsID=outs.ProductsID
and s.StateID=out.State and out.StoreHouseID=st.HouseID and out.HouseDetailID=sto.ID)
and s.StateID='{2}'", rows, (page - 1) * rows, statename);
            List<addorder> list = new List<addorder>();
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            foreach (DataRow item in dt.Rows)
            {
                addorder ad = new addorder();
                //ad.DetailID = Convert.ToInt32(item["DetailID"].ToString());
                ad.ProductsName = item["ProductsName"].ToString();
                ad.OutID = item["OutID"].ToString();
                ad.CreateDate = item["CreateDate"].ToString();
                ad.HouseName = item["HouseName"].ToString();
                ad.SubareaName = item["SubareaName"].ToString();
                ad.TradeDate = item["TradeDate"].ToString();
                ad.Quantity = Convert.ToInt32(item["Quantity"].ToString());
                ad.Price = item["Price"].ToString();
                ad.StateName = item["StateName"].ToString();
                list.Add(ad);
            }
            return list;
        }

        //判断条件,多者满足其中之一即可,通过outid来查询
        public static List<addorder> GetSe(int rows, int page, string outid)
        {
            string sqlstr = string.Format(@"select top {0} outs.DetailID, p.ProductsName,out.OutID,out.CreateDate,st.HouseName,
sto.SubareaName,out.TradeDate,outs.Quantity,outs.Price,s.StateName
from t_OutStock out,t_OutStockDetail outs,t_Products p,t_Ste s,t_StoreHouse st
,t_StoreHouseDetail sto where out.OutID=outs.OutID and p.ProductsID=outs.ProductsID
and s.StateID=out.State and out.StoreHouseID=st.HouseID and out.HouseDetailID=sto.ID
and outs.DetailID not in (select top {1} DetailID
from t_OutStock out,t_OutStockDetail outs,t_Products p,t_Ste s,t_StoreHouse st
,t_StoreHouseDetail sto where out.OutID=outs.OutID and p.ProductsID=outs.ProductsID
and s.StateID=out.State and out.StoreHouseID=st.HouseID and out.HouseDetailID=sto.ID)and out.OutID='{2}'", rows, (page - 1) * rows, outid);
            List<addorder> list = new List<addorder>();
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            foreach (DataRow item in dt.Rows)
            {
                addorder ad = new addorder();
                ad.DetailID = Convert.ToInt32(item["DetailID"].ToString());
                ad.ProductsName = item["ProductsName"].ToString();
                ad.OutID = item["OutID"].ToString();
                ad.CreateDate = item["CreateDate"].ToString();
                ad.HouseName = item["HouseName"].ToString();
                ad.SubareaName = item["SubareaName"].ToString();
                ad.TradeDate = item["TradeDate"].ToString();
                ad.Quantity = Convert.ToInt32(item["Quantity"].ToString());
                ad.Price = item["Price"].ToString();
                ad.StateName = item["StateName"].ToString();
                list.Add(ad);
            }
            return list;
        }
        //判断条件,多者满足其中之一即可,通过createtime来查询
        public static List<addorder> GetSel(int rows, int page, string create,string tradetime)
        {
            string sqlstr = string.Format(@"select top {0} outs.DetailID, p.ProductsName,out.OutID,out.CreateDate,st.HouseName,
sto.SubareaName,out.TradeDate,outs.Quantity,outs.Price,s.StateName
from t_OutStock out,t_OutStockDetail outs,t_Products p,t_Ste s,t_StoreHouse st
,t_StoreHouseDetail sto where out.OutID=outs.OutID and p.ProductsID=outs.ProductsID
and s.StateID=out.State and out.StoreHouseID=st.HouseID and out.HouseDetailID=sto.ID
and outs.DetailID not in (select top {1} DetailID
from t_OutStock out,t_OutStockDetail outs,t_Products p,t_Ste s,t_StoreHouse st
,t_StoreHouseDetail sto where out.OutID=outs.OutID and p.ProductsID=outs.ProductsID
and s.StateID=out.State and out.StoreHouseID=st.HouseID and out.HouseDetailID=sto.ID)
and out.CreateDate between '{2}' and '{3}'", rows, (page - 1) * rows, create, tradetime);
            List<addorder> list = new List<addorder>();
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            foreach (DataRow item in dt.Rows)
            {
                addorder ad = new addorder();
                ad.DetailID = Convert.ToInt32(item["DetailID"].ToString());
                ad.ProductsName = item["ProductsName"].ToString();
                ad.OutID = item["OutID"].ToString();
                ad.CreateDate = item["CreateDate"].ToString();
                ad.HouseName = item["HouseName"].ToString();
                ad.SubareaName = item["SubareaName"].ToString();
                ad.TradeDate = item["TradeDate"].ToString();
                ad.Quantity = Convert.ToInt32(item["Quantity"].ToString());
                ad.Price = item["Price"].ToString();
                ad.StateName = item["StateName"].ToString();
                list.Add(ad);
            }
            return list;
        }
        //判断条件,多者满足其中之一即可,通过outid 和createtime 来查询
        public static List<addorder> GetSele(int rows, int page,string outid, string create, string tradetime)
        {
            string sqlstr = string.Format(@"select top {0} outs.DetailID, p.ProductsName,out.OutID,out.CreateDate,st.HouseName,
sto.SubareaName,out.TradeDate,outs.Quantity,outs.Price,s.StateName
from t_OutStock out,t_OutStockDetail outs,t_Products p,t_Ste s,t_StoreHouse st
,t_StoreHouseDetail sto where out.OutID=outs.OutID and p.ProductsID=outs.ProductsID
and s.StateID=out.State and out.StoreHouseID=st.HouseID and out.HouseDetailID=sto.ID
and outs.DetailID not in (select top {1} DetailID
from t_OutStock out,t_OutStockDetail outs,t_Products p,t_Ste s,t_StoreHouse st
,t_StoreHouseDetail sto where out.OutID=outs.OutID and p.ProductsID=outs.ProductsID
and s.StateID=out.State and out.StoreHouseID=st.HouseID and out.HouseDetailID=sto.ID)and out.OutID='{2}' 
and out.CreateDate between '{3}' and '{4}'", rows, (page - 1) * rows, outid, create, tradetime);
            List<addorder> list = new List<addorder>();
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            foreach (DataRow item in dt.Rows)
            {
                addorder ad = new addorder();
                ad.DetailID = Convert.ToInt32(item["DetailID"].ToString());
                ad.ProductsName = item["ProductsName"].ToString();
                ad.OutID = item["OutID"].ToString();
                ad.CreateDate = item["CreateDate"].ToString();
                ad.HouseName = item["HouseName"].ToString();
                ad.SubareaName = item["SubareaName"].ToString();
                ad.TradeDate = item["TradeDate"].ToString();
                ad.Quantity = Convert.ToInt32(item["Quantity"].ToString());
                ad.Price = item["Price"].ToString();
                ad.StateName = item["StateName"].ToString();
                list.Add(ad);
            }
            return list;
        }
        //判断条件,多者满足其中之一即可,通过outid 和statename 来查询
        public static List<addorder> GetSelec(int rows,int page, string outid,int statename)
        {
            string sqlstr = string.Format(@"select top {0} outs.DetailID, p.ProductsName,out.OutID,out.CreateDate,st.HouseName,
sto.SubareaName,out.TradeDate,outs.Quantity,outs.Price,s.StateName
from t_OutStock out,t_OutStockDetail outs,t_Products p,t_Ste s,t_StoreHouse st
,t_StoreHouseDetail sto where out.OutID=outs.OutID and p.ProductsID=outs.ProductsID
and s.StateID=out.State and out.StoreHouseID=st.HouseID and out.HouseDetailID=sto.ID
and outs.DetailID not in (select top {1} DetailID
from t_OutStock out,t_OutStockDetail outs,t_Products p,t_Ste s,t_StoreHouse st
,t_StoreHouseDetail sto where out.OutID=outs.OutID and p.ProductsID=outs.ProductsID
and s.StateID=out.State and out.StoreHouseID=st.HouseID and out.HouseDetailID=sto.ID) 
and out.OutID='{2}' and s.StateID='{3}'", rows, (page - 1) * rows, outid, statename);
            List<addorder> list = new List<addorder>();
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            foreach (DataRow item in dt.Rows)
            {
                addorder ad = new addorder();
                ad.DetailID = Convert.ToInt32(item["DetailID"].ToString());
                ad.ProductsName = item["ProductsName"].ToString();
                ad.OutID = item["OutID"].ToString();
                ad.CreateDate = item["CreateDate"].ToString();
                ad.HouseName = item["HouseName"].ToString();
                ad.SubareaName = item["SubareaName"].ToString();
                ad.TradeDate = item["TradeDate"].ToString();
                ad.Quantity = Convert.ToInt32(item["Quantity"].ToString());
                ad.Price = item["Price"].ToString();
                ad.StateName = item["StateName"].ToString();
                list.Add(ad);
            }
            return list;
        }
        //判断条件,多者满足其中之一即可,通过statename 和createtime 来查询
        public static List<addorder> GetSelectd(int rows, int page, string create, string tradetime,int statename)
        {
            string sqlstr = string.Format(@"select top {0} outs.DetailID, p.ProductsName,out.OutID,out.CreateDate,st.HouseName,
sto.SubareaName,out.TradeDate,outs.Quantity,outs.Price,s.StateName
from t_OutStock out,t_OutStockDetail outs,t_Products p,t_Ste s,t_StoreHouse st
,t_StoreHouseDetail sto where out.OutID=outs.OutID and p.ProductsID=outs.ProductsID
and s.StateID=out.State and out.StoreHouseID=st.HouseID and out.HouseDetailID=sto.ID
and outs.DetailID not in (select top {1} DetailID
from t_OutStock out,t_OutStockDetail outs,t_Products p,t_Ste s,t_StoreHouse st
,t_StoreHouseDetail sto where out.OutID=outs.OutID and p.ProductsID=outs.ProductsID
and s.StateID=out.State and out.StoreHouseID=st.HouseID and out.HouseDetailID=sto.ID) 
and out.CreateDate between '{2}' and '{3}' and s.StateID='{4}'", rows, (page - 1) * rows, create, tradetime, statename);
            List<addorder> list = new List<addorder>();
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            foreach (DataRow item in dt.Rows)
            {
                addorder ad = new addorder();
                ad.DetailID = Convert.ToInt32(item["DetailID"].ToString());
                ad.ProductsName = item["ProductsName"].ToString();
                ad.OutID = item["OutID"].ToString();
                ad.CreateDate = item["CreateDate"].ToString();
                ad.HouseName = item["HouseName"].ToString();
                ad.SubareaName = item["SubareaName"].ToString();
                ad.TradeDate = item["TradeDate"].ToString();
                ad.Quantity = Convert.ToInt32(item["Quantity"].ToString());
                ad.Price = item["Price"].ToString();
                ad.StateName = item["StateName"].ToString();
                list.Add(ad);
            }
            return list;
        }
       //修改
        public static bool GteUpdata(addorder ad)
        {
            string sqlstr = string.Format(@"update t_OutStock set State='{0}' where OutID='{1}'",ad.State,ad.OutID);
            bool dt = DBHelper.ExecuteNon(sqlstr);
            return dt;
        }
        //删除
        public static bool GetDelete(string outid)
        {
            string sqlstr = string.Format(@"delete from t_OutStock where OutID in({0})", outid);
            bool dt = DBHelper.ExecuteNon(sqlstr);
            return dt;
        }
        //删除
        public static bool GetDelete1(string outid)
        {
            string sqlstr = string.Format(@"delete  from t_OutStockDetail  where OutID in({0})", outid);
            bool dt = DBHelper.ExecuteNon(sqlstr);
            return dt;
        }
    }
}
