using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.NewFolder1;
using System.Data;
namespace DAL.NewFolder1
{
  public  class adminSaleService
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
            string sqlstr = string.Format(@" select SalesOutID from t_SalesOut");
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            return dt;
        }
        //分页显示总行数
        public static List<addorder> GetAll(int rows, int page)
        {
            string sqlstr = string.Format(@"select top {0} sa.SalesOutID,p.ProductsName,sa.CreateDate,st.HouseName,sto.SubareaName,
sa.TradeDate,sale.Quantity,sale.Price,s.StateName from t_SalesOut sa,t_SalesOutDetail sale,
t_Products p,t_StoreHouse st,t_StoreHouseDetail sto,t_Ste s where sa.SalesOutID=sale.SalesOutID
and sale.ProductsID=p.ProductsID and sale.StoreHouseID=st.HouseID 
and sale.HouseDetailID=sto.ID and sa.State=s.StateID and sale.DetailID not in
(select top {1} DetailID from t_SalesOut sa,t_SalesOutDetail sale,t_Products p,t_StoreHouse st,
t_StoreHouseDetail sto,t_Ste s where sa.SalesOutID=sale.SalesOutID
and sale.ProductsID=p.ProductsID and sale.StoreHouseID=st.HouseID 
and sale.HouseDetailID=sto.ID and sa.State=s.StateID )", rows, (page - 1) * rows);
            List<addorder> list = new List<addorder>();
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            foreach (DataRow item in dt.Rows)
            {
                addorder ad = new addorder();
                ad.SalesOutID =item["SalesOutID"].ToString();
                ad.ProductsName = item["ProductsName"].ToString();
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
        //获取总行数
        public static int GetHang()
        {
            string sqlstr = @"select * from t_SalesOut sa,t_SalesOutDetail sale,
t_Products p,t_StoreHouse st,t_StoreHouseDetail sto,t_Ste s where sa.SalesOutID=sale.SalesOutID
and sale.ProductsID=p.ProductsID and sale.StoreHouseID=st.HouseID 
and sale.HouseDetailID=sto.ID and sa.State=s.StateID";
            DataTable rows = DBHelper.GetDataTable(sqlstr);
            return rows.Rows.Count;
        }
        //判断条件,都满足的情况下
        public static List<addorder> GetSelect(int rows, int page, string saleid, string create, string trade, int statename)
        {
            string sqlstr = string.Format(@"select top {0} sa.SalesOutID,p.ProductsName,sa.CreateDate,st.HouseName,sto.SubareaName,
sa.TradeDate,sale.Quantity,sale.Price,s.StateName from t_SalesOut sa,t_SalesOutDetail sale,
t_Products p,t_StoreHouse st,t_StoreHouseDetail sto,t_Ste s where sa.SalesOutID=sale.SalesOutID
and sale.ProductsID=p.ProductsID and sale.StoreHouseID=st.HouseID 
and sale.HouseDetailID=sto.ID and sa.State=s.StateID and sale.DetailID not in
(select top {1} DetailID from t_SalesOut sa,t_SalesOutDetail sale,t_Products p,t_StoreHouse st,
t_StoreHouseDetail sto,t_Ste s where sa.SalesOutID=sale.SalesOutID
and sale.ProductsID=p.ProductsID and sale.StoreHouseID=st.HouseID 
and sale.HouseDetailID=sto.ID and sa.State=s.StateID ) and sa.SalesOutID='{2}' 
and sa.CreateDate between '{3}' and '{4}' and s.StateID='{5}'", rows, (page - 1) * rows, saleid, create, trade, statename);
            List<addorder> list = new List<addorder>();
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            foreach (DataRow item in dt.Rows)
            {
                addorder ad = new addorder();
                ad.ProductsName = item["ProductsName"].ToString();
                ad.SalesOutID = item["SalesOutID"].ToString();
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
        public static List<addorder> GetS(int rows, int page, int statename)
        {
            string sqlstr = string.Format(@"select top {0} sa.SalesOutID,p.ProductsName,sa.CreateDate,st.HouseName,sto.SubareaName,
sa.TradeDate,sale.Quantity,sale.Price,s.StateName from t_SalesOut sa,t_SalesOutDetail sale,
t_Products p,t_StoreHouse st,t_StoreHouseDetail sto,t_Ste s where sa.SalesOutID=sale.SalesOutID
and sale.ProductsID=p.ProductsID and sale.StoreHouseID=st.HouseID 
and sale.HouseDetailID=sto.ID and sa.State=s.StateID and sale.DetailID not in
(select top {1} DetailID from t_SalesOut sa,t_SalesOutDetail sale,t_Products p,t_StoreHouse st,
t_StoreHouseDetail sto,t_Ste s where sa.SalesOutID=sale.SalesOutID
and sale.ProductsID=p.ProductsID and sale.StoreHouseID=st.HouseID 
and sale.HouseDetailID=sto.ID and sa.State=s.StateID ) and s.StateID='{2}'", rows, (page - 1) * rows, statename);
            List<addorder> list = new List<addorder>();
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            foreach (DataRow item in dt.Rows)
            {
                addorder ad = new addorder();
                ad.ProductsName = item["ProductsName"].ToString();
                ad.SalesOutID = item["SalesOutID"].ToString();
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
        public static List<addorder> GetSe(int rows, int page, string saleid)
        {
            string sqlstr = string.Format(@"select top {0} sa.SalesOutID,p.ProductsName,sa.CreateDate,st.HouseName,sto.SubareaName,
sa.TradeDate,sale.Quantity,sale.Price,s.StateName from t_SalesOut sa,t_SalesOutDetail sale,
t_Products p,t_StoreHouse st,t_StoreHouseDetail sto,t_Ste s where sa.SalesOutID=sale.SalesOutID
and sale.ProductsID=p.ProductsID and sale.StoreHouseID=st.HouseID 
and sale.HouseDetailID=sto.ID and sa.State=s.StateID and sale.DetailID not in
(select top {1} DetailID from t_SalesOut sa,t_SalesOutDetail sale,t_Products p,t_StoreHouse st,
t_StoreHouseDetail sto,t_Ste s where sa.SalesOutID=sale.SalesOutID
and sale.ProductsID=p.ProductsID and sale.StoreHouseID=st.HouseID 
and sale.HouseDetailID=sto.ID and sa.State=s.StateID ) and sa.SalesOutID='{2}'", rows, (page - 1) * rows, saleid);
            List<addorder> list = new List<addorder>();
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            foreach (DataRow item in dt.Rows)
            {
                addorder ad = new addorder();
                ad.ProductsName = item["ProductsName"].ToString();
                ad.SalesOutID = item["SalesOutID"].ToString();
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
        public static List<addorder> GetSel(int rows, int page, string create, string tradetime)
        {
            string sqlstr = string.Format(@"select top {0} sa.SalesOutID,p.ProductsName,sa.CreateDate,st.HouseName,sto.SubareaName,
sa.TradeDate,sale.Quantity,sale.Price,s.StateName from t_SalesOut sa,t_SalesOutDetail sale,
t_Products p,t_StoreHouse st,t_StoreHouseDetail sto,t_Ste s where sa.SalesOutID=sale.SalesOutID
and sale.ProductsID=p.ProductsID and sale.StoreHouseID=st.HouseID 
and sale.HouseDetailID=sto.ID and sa.State=s.StateID and sale.DetailID not in
(select top {1} DetailID from t_SalesOut sa,t_SalesOutDetail sale,t_Products p,t_StoreHouse st,
t_StoreHouseDetail sto,t_Ste s where sa.SalesOutID=sale.SalesOutID
and sale.ProductsID=p.ProductsID and sale.StoreHouseID=st.HouseID 
and sale.HouseDetailID=sto.ID and sa.State=s.StateID )
and sa.CreateDate between '{2}' and '{3}'", rows, (page - 1) * rows, create, tradetime);
            List<addorder> list = new List<addorder>();
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            foreach (DataRow item in dt.Rows)
            {
                addorder ad = new addorder();
                ad.ProductsName = item["ProductsName"].ToString();
                ad.SalesOutID = item["SalesOutID"].ToString();
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
        public static List<addorder> GetSele(int rows, int page, string saleid, string create, string tradetime)
        {
            string sqlstr = string.Format(@"select top {0} sa.SalesOutID,p.ProductsName,sa.CreateDate,st.HouseName,sto.SubareaName,
sa.TradeDate,sale.Quantity,sale.Price,s.StateName from t_SalesOut sa,t_SalesOutDetail sale,
t_Products p,t_StoreHouse st,t_StoreHouseDetail sto,t_Ste s where sa.SalesOutID=sale.SalesOutID
and sale.ProductsID=p.ProductsID and sale.StoreHouseID=st.HouseID 
and sale.HouseDetailID=sto.ID and sa.State=s.StateID and sale.DetailID not in
(select top {1} DetailID from t_SalesOut sa,t_SalesOutDetail sale,t_Products p,t_StoreHouse st,
t_StoreHouseDetail sto,t_Ste s where sa.SalesOutID=sale.SalesOutID
and sale.ProductsID=p.ProductsID and sale.StoreHouseID=st.HouseID 
and sale.HouseDetailID=sto.ID and sa.State=s.StateID ) and sa.SalesOutID='{2}' 
and sa.CreateDate between '{3}' and '{4}'", rows, (page - 1) * rows, saleid, create, tradetime);
            List<addorder> list = new List<addorder>();
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            foreach (DataRow item in dt.Rows)
            {
                addorder ad = new addorder();
                //ad.DetailID = Convert.ToInt32(item["DetailID"].ToString());
                ad.ProductsName = item["ProductsName"].ToString();
                ad.SalesOutID = item["SalesOutID"].ToString();
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
        public static List<addorder> GetSelec(int rows, int page, string saleid, int statename)
        {
            string sqlstr = string.Format(@"select top {0} sa.SalesOutID,p.ProductsName,sa.CreateDate,st.HouseName,sto.SubareaName,
sa.TradeDate,sale.Quantity,sale.Price,s.StateName from t_SalesOut sa,t_SalesOutDetail sale,
t_Products p,t_StoreHouse st,t_StoreHouseDetail sto,t_Ste s where sa.SalesOutID=sale.SalesOutID
and sale.ProductsID=p.ProductsID and sale.StoreHouseID=st.HouseID
and sale.HouseDetailID=sto.ID and sa.State=s.StateID and sale.DetailID not in
(select top {1} DetailID from t_SalesOut sa,t_SalesOutDetail sale,t_Products p,t_StoreHouse st,
t_StoreHouseDetail sto,t_Ste s where sa.SalesOutID=sale.SalesOutID
and sale.ProductsID=p.ProductsID and sale.StoreHouseID=st.HouseID
and sale.HouseDetailID=sto.ID and sa.State=s.StateID ) and sa.SalesOutID='{2}'
and s.StateID='{3}'", rows, (page - 1) * rows, saleid, statename);
            List<addorder> list = new List<addorder>();
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            foreach (DataRow item in dt.Rows)
            {
                addorder ad = new addorder();
                ad.ProductsName = item["ProductsName"].ToString();
                ad.SalesOutID = item["SalesOutID"].ToString();
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
        public static List<addorder> GetSelectd(int rows, int page, string create, string tradetime, int statename)
        {
            string sqlstr = string.Format(@"select top {0} sa.SalesOutID,p.ProductsName,sa.CreateDate,st.HouseName,sto.SubareaName,
sa.TradeDate,sale.Quantity,sale.Price,s.StateName from t_SalesOut sa,t_SalesOutDetail sale,
t_Products p,t_StoreHouse st,t_StoreHouseDetail sto,t_Ste s where sa.SalesOutID=sale.SalesOutID
and sale.ProductsID=p.ProductsID and sale.StoreHouseID=st.HouseID 
and sale.HouseDetailID=sto.ID and sa.State=s.StateID and sale.DetailID not in
(select top {1} DetailID from t_SalesOut sa,t_SalesOutDetail sale,t_Products p,t_StoreHouse st,
t_StoreHouseDetail sto,t_Ste s where sa.SalesOutID=sale.SalesOutID
and sale.ProductsID=p.ProductsID and sale.StoreHouseID=st.HouseID 
and sale.HouseDetailID=sto.ID and sa.State=s.StateID ) 
and sa.CreateDate between '{2}' and '{3}' and s.StateID='{4}'", rows, (page - 1) * rows, create, tradetime, statename);
            List<addorder> list = new List<addorder>();
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            foreach (DataRow item in dt.Rows)
            {
                addorder ad = new addorder();
                ad.ProductsName = item["ProductsName"].ToString();
                ad.SalesOutID = item["SalesOutID"].ToString();
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
            string sqlstr = string.Format(@"update t_SalesOut set State='{0}' where SalesOutID='{1}'", ad.State, ad.SalesOutID);
            bool dt = DBHelper.ExecuteNon(sqlstr);
            return dt;
        }
        //删除
        public static bool GetDelete(string saleid)
        {
            string sqlstr = string.Format(@"delete from t_SalesOut where SalesOutID in({0})", saleid);
            bool dt = DBHelper.ExecuteNon(sqlstr);
            return dt;
        }
        //删除
        public static bool GetDelete1(string saleid)
        {
            string sqlstr = string.Format(@"delete from t_SalesOutDetail  where SalesOutID in({0})", saleid);
            bool dt = DBHelper.ExecuteNon(sqlstr);
            return dt;
        }
    }
}
