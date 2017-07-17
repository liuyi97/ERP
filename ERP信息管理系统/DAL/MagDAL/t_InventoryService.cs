using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.MagMdl;
using System.Data;
namespace DAL.MagDAL
{
   public   class t_InventoryService
    {
        public static int t_Inventorycount()
        {
            string sql = "";
            sql = string.Format(@" select i.InventoryID, p.ProductsName,i.CreateDate, t.HouseName+'-'+ d.SubareaName ,i.BillNum,i.AdjustNum,i.RealityNum ,e.StateName from  t_Ste e , t_Inventory i,t_StoreHouse t,t_StoreHouseDetail d ,t_Products p
            where i.HouseDetailID=t.HouseID and i.StoreHouseID=d.ID and i.ProductsID=p.ProductsID and i.State =e.StateID");
            DataTable dt = DBHelper.GetDatatable(sql);
            return dt.Rows.Count;
        }
        public static List<t_Inventory> t_InventoryInfo(int index, int count)
        {
            string sql = "";
            sql = string.Format(@"select top {0} i.InventoryID ,p.ProductsName,i.CreateDate, t.HouseName+'-'+ d.SubareaName gg ,i.BillNum
   ,i.AdjustNum,i.RealityNum ,e.StateName from  t_Ste e , t_Inventory i,t_StoreHouse t,t_StoreHouseDetail d ,t_Products p
where i.HouseDetailID=t.HouseID and i.StoreHouseID=d.ID and i.ProductsID=p.ProductsID and i.State =e.StateID and  i.InventoryID not
               in(select top {1} InventoryID from  t_Ste e , t_Inventory i,t_StoreHouse t,t_StoreHouseDetail d ,t_Products p
where i.HouseDetailID=t.HouseID and i.StoreHouseID=d.ID and i.ProductsID=p.ProductsID and i.State =e.StateID) 
                 ", count, (index - 1) * count);
            DataTable dt = DBHelper.GetDatatable(sql);
            List<t_Inventory> list = new List<t_Inventory>();
            foreach (DataRow item in dt.Rows)
            {
                t_Inventory e = new t_Inventory();
                e.InventoryID =(item["InventoryID"].ToString());
                e.productName = (item["ProductsName"].ToString());
                e.CreateDate= (item["CreateDate"].ToString());
                e.zugename = item["gg"].ToString();
                e.StateName = item["StateName"].ToString();
                e.RealityNum = Convert.ToInt32(item["RealityNum"]);
                e.AdjustNum = Convert.ToInt32( item["AdjustNum"]);
                e.BillNum = Convert.ToInt32(item["BillNum"]);
                list.Add(e);
            }
            return list;
        }
        public static bool t_Inventorysheng(string s)
        {
            string sql = string.Format(@"update t_Inventory set  State = 2 where InventoryID in ({0})", s);
            bool dt = DBHelper.ExecuteSql(sql);
            return dt;
        }
        public static List<t_Inventory> t_InventoryDataid(int index, int count, int dataid)
        {
            string sql = "";
            sql = string.Format(@"select  top {0} i.InventoryID ,p.ProductsName,i.CreateDate, ddd.HouseName+'-'+ ddd.SubareaName gg ,i.BillNum
   ,i.AdjustNum,i.RealityNum ,e.StateName from  t_Ste e , t_Inventory i,t_Products p,
   (select T. HouseID,ID,HouseName,SubareaName from t_StoreHouse t,t_StoreHouseDetail d where t.HouseID=d.HouseID) ddd
where  ddd.ID =i.HouseDetailID and ddd.HouseID=i.StoreHouseID  and  i.ProductsID=p.ProductsID and i.State =e.StateID
    and  i.InventoryID not
     in(select top {1} InventoryID from  t_Ste e , t_Inventory i,t_Products p,
   (select T. HouseID,ID,HouseName,SubareaName from t_StoreHouse t,t_StoreHouseDetail d where t.HouseID=d.HouseID) ddd
where ddd.ID =i.HouseDetailID and ddd.HouseID=i.StoreHouseID  and  i.ProductsID=p.ProductsID and i.State =e.StateID)  
and i.State={2}  ", count, (index - 1) * count, dataid);
            DataTable dt = DBHelper.GetDatatable(sql);
            List<t_Inventory> list = new List<t_Inventory>();
            foreach (DataRow item in dt.Rows)
            {
                t_Inventory e = new t_Inventory();
                e.InventoryID = (item["InventoryID"].ToString());
                e.productName = (item["ProductsName"].ToString());
                e.CreateDate = (item["CreateDate"].ToString());
                e.zugename = item["gg"].ToString();
                e.StateName = item["StateName"].ToString();
                e.RealityNum = Convert.ToInt32(item["RealityNum"]);
                e.AdjustNum = Convert.ToInt32(item["AdjustNum"]);
                e.BillNum = Convert.ToInt32(item["BillNum"]);
                list.Add(e);
            }
            return list;
        }
        public static int t_InventoryDataidcount(int index, int count, int dataid)
        {
            string sql = "";
            sql = string.Format(@"select i.InventoryID ,p.ProductsName,i.CreateDate, ddd.HouseName+'-'+ ddd.SubareaName gg ,i.BillNum
   ,i.AdjustNum,i.RealityNum ,e.StateName from  t_Ste e , t_Inventory i,t_Products p,
   (select T. HouseID,ID,HouseName,SubareaName from t_StoreHouse t,t_StoreHouseDetail d where t.HouseID=d.HouseID) ddd
where  ddd.ID =i.HouseDetailID and ddd.HouseID=i.StoreHouseID  and  i.ProductsID=p.ProductsID and i.State =e.StateID
and i.State={0} ", dataid);
            DataTable dt = DBHelper.GetDatatable(sql);
            return dt.Rows.Count;
        }

        public static List<t_Inventory> t_InventoryGetid(int index, int count, string Getid)
        {
            string sql = "";
            sql = string.Format(@"select  top {0} i.InventoryID ,p.ProductsName,i.CreateDate, ddd.HouseName+'-'+ ddd.SubareaName gg ,i.BillNum
   ,i.AdjustNum,i.RealityNum ,e.StateName from  t_Ste e , t_Inventory i,t_Products p,
   (select T. HouseID,ID,HouseName,SubareaName from t_StoreHouse t,t_StoreHouseDetail d where t.HouseID=d.HouseID) ddd
where  ddd.ID =i.HouseDetailID and ddd.HouseID=i.StoreHouseID  and  i.ProductsID=p.ProductsID and i.State =e.StateID
    and  i.InventoryID not
               in(select top {1} InventoryID from  t_Ste e , t_Inventory i,t_Products p,
   (select T. HouseID,ID,HouseName,SubareaName from t_StoreHouse t,t_StoreHouseDetail d where t.HouseID=d.HouseID) ddd
where ddd.ID =i.HouseDetailID and ddd.HouseID=i.StoreHouseID  and  i.ProductsID=p.ProductsID and i.State =e.StateID) and i.InventoryID='{2}'
                 ", count, (index - 1) * count, Getid);
            DataTable dt = DBHelper.GetDatatable(sql);
            List<t_Inventory> list = new List<t_Inventory>();
            foreach (DataRow item in dt.Rows)
            {
                t_Inventory e = new t_Inventory();
                e.InventoryID = (item["InventoryID"].ToString());
                e.productName = (item["ProductsName"].ToString());
                e.CreateDate = (item["CreateDate"].ToString());
                e.zugename = item["gg"].ToString();
                e.StateName = item["StateName"].ToString();
                e.RealityNum = Convert.ToInt32(item["RealityNum"]);
                e.AdjustNum = Convert.ToInt32(item["AdjustNum"]);
                e.BillNum = Convert.ToInt32(item["BillNum"]);
                list.Add(e);
            }
            return list;
        }
        public static int t_InventoryGetidcount(int index, int count, string Getid)
        {
            string sql = "";
            sql = string.Format(@"select  top {0} i.InventoryID ,p.ProductsName,i.CreateDate, ddd.HouseName+'-'+ ddd.SubareaName gg ,i.BillNum
   ,i.AdjustNum,i.RealityNum ,e.StateName from  t_Ste e , t_Inventory i,t_Products p,
   (select T. HouseID,ID,HouseName,SubareaName from t_StoreHouse t,t_StoreHouseDetail d where t.HouseID=d.HouseID) ddd
where  ddd.ID =i.HouseDetailID and ddd.HouseID=i.StoreHouseID  and  i.ProductsID=p.ProductsID and i.State =e.StateID
    and  i.InventoryID not
               in(select top {1} InventoryID from  t_Ste e , t_Inventory i,t_Products p,
   (select T. HouseID,ID,HouseName,SubareaName from t_StoreHouse t,t_StoreHouseDetail d where t.HouseID=d.HouseID) ddd
where ddd.ID =i.HouseDetailID and ddd.HouseID=i.StoreHouseID  and  i.ProductsID=p.ProductsID and i.State =e.StateID) and i.InventoryID='{2}'
                 ", count, (index - 1) * count, Getid);
            DataTable dt = DBHelper.GetDatatable(sql);
            return dt.Rows.Count;
        }
        public static List<t_Inventory> t_Inventorybegin(int index, int count, string begin,string end)
        {
            string sql = "";
            sql = string.Format(@"select  top {0} i.InventoryID ,p.ProductsName,i.CreateDate, ddd.HouseName+'-'+ ddd.SubareaName gg ,i.BillNum
   ,i.AdjustNum,i.RealityNum ,e.StateName from  t_Ste e , t_Inventory i,t_Products p,
   (select T. HouseID,ID,HouseName,SubareaName from t_StoreHouse t,t_StoreHouseDetail d where t.HouseID=d.HouseID) ddd
where  ddd.ID =i.HouseDetailID and ddd.HouseID=i.StoreHouseID  and  i.ProductsID=p.ProductsID and i.State =e.StateID
    and  i.InventoryID not
               in(select top {1} InventoryID from  t_Ste e , t_Inventory i,t_Products p,
   (select T. HouseID,ID,HouseName,SubareaName from t_StoreHouse t,t_StoreHouseDetail d where t.HouseID=d.HouseID) ddd
where ddd.ID =i.HouseDetailID and ddd.HouseID=i.StoreHouseID  and  i.ProductsID=p.ProductsID and i.State =e.StateID) and i.CreateDate between '{2}' and '{3}'
                 ", count, (index - 1) * count,begin,end );
            DataTable dt = DBHelper.GetDatatable(sql);
            List<t_Inventory> list = new List<t_Inventory>();
            foreach (DataRow item in dt.Rows)
            {
                t_Inventory e = new t_Inventory();
                e.InventoryID = (item["InventoryID"].ToString());
                e.productName = (item["ProductsName"].ToString());
                e.CreateDate = (item["CreateDate"].ToString());
                e.zugename = item["gg"].ToString();
                e.StateName = item["StateName"].ToString();
                e.RealityNum = Convert.ToInt32(item["RealityNum"]);
                e.AdjustNum = Convert.ToInt32(item["AdjustNum"]);
                e.BillNum = Convert.ToInt32(item["BillNum"]);
                list.Add(e);
            }
            return list;
        }
        public static int t_Inventorybegincount(int index, int count, string begin, string end)
        {
            string sql = "";
            sql = string.Format(@"select  top {0} i.InventoryID ,p.ProductsName,i.CreateDate, ddd.HouseName+'-'+ ddd.SubareaName gg ,i.BillNum
   ,i.AdjustNum,i.RealityNum ,e.StateName from  t_Ste e , t_Inventory i,t_Products p,
   (select T. HouseID,ID,HouseName,SubareaName from t_StoreHouse t,t_StoreHouseDetail d where t.HouseID=d.HouseID) ddd
where  ddd.ID =i.HouseDetailID and ddd.HouseID=i.StoreHouseID  and  i.ProductsID=p.ProductsID and i.State =e.StateID
    and  i.InventoryID not
               in(select top {1} InventoryID from  t_Ste e , t_Inventory i,t_Products p,
   (select T. HouseID,ID,HouseName,SubareaName from t_StoreHouse t,t_StoreHouseDetail d where t.HouseID=d.HouseID) ddd
where ddd.ID =i.HouseDetailID and ddd.HouseID=i.StoreHouseID  and  i.ProductsID=p.ProductsID and i.State =e.StateID) and i.CreateDate between '{2}' and '{3}'
                 ", count, (index - 1) * count, begin, end);
            DataTable dt = DBHelper.GetDatatable(sql);
            return dt.Rows.Count;
        }
        public static bool t_InventoryDel(string s)
        {
            string sql = string.Format("delete from t_Inventory where InventoryID=" + s);
            bool dt = DBHelper.ExecuteSql(sql);
            return dt;
        }
    }
}
