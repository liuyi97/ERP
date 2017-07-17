using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.MagMdl;
using System.Data;
namespace DAL.MagDAL
{
    public static  class t_TransferringOrderService
    {
        public static List<t_TransferringOrder> getinfo(int index,int count)
        {
            string sql = string.Format(@"select  top {0} * from 
                   (select t.ID, ss.HouseName+'-'+ SubareaName  gg , t.Quantity,t.UserName ,t.ProductsID ,e.StateName,t.State
                    ,p.ProductsName from  t_TransferringOrder t, t_Products p,t_Ste e,
                   (select  SubareaName , t.HouseID ,ID,HouseName from t_StoreHouse 
                   t,t_StoreHouseDetail h where t.HouseID=h.HouseID) ss where ss.ID=t.InHouseID
                    and p.ProductsID=t.ProductsID and e.StateID=t.State) a ,
                   (select  t.ID ,ss.HouseName+'-'+ SubareaName kk  from  t_TransferringOrder t, 
                   (select  SubareaName , t.HouseID ,ID,HouseName from t_StoreHouse 
                   t,t_StoreHouseDetail h where t.HouseID=h.HouseID) ss where ss.ID=t.OutHouseID) b
                   where b.ID=a.ID and a.ID not in 
                   (select top {1} b.ID   from (select t.ID, ss.HouseName+'-'+ SubareaName  kk , t.Quantity,t.UserName ,t.ProductsID ,e.StateName,t.State
                    ,p.ProductsName from  t_TransferringOrder t, t_Products p,t_Ste e,
                   (select  SubareaName , t.HouseID ,ID,HouseName from t_StoreHouse 
                   t,t_StoreHouseDetail h where t.HouseID=h.HouseID) ss where ss.ID=t.InHouseID
                    and p.ProductsID=t.ProductsID and e.StateID=t.State) a ,
                   (select  t.ID ,ss.HouseName+'-'+ SubareaName  调出  from  t_TransferringOrder t, 
                   (select  SubareaName , t.HouseID ,ID,HouseName from t_StoreHouse 
                   t,t_StoreHouseDetail h where t.HouseID=h.HouseID) ss where ss.ID=t.OutHouseID) b
                   where b.ID=a.ID )", count, (index-1)*count);
                   DataTable dt = DBHelper.GetDatatable(sql);
                  List<t_TransferringOrder> list = new List<t_TransferringOrder>();
            foreach (DataRow item in dt.Rows)
            {
                t_TransferringOrder tran = new t_TransferringOrder();
                tran.ID = item["ID"].ToString();
                tran.inStoreName = item["gg"].ToString();
                tran.outStoreName = item["kk"].ToString();
                tran.Productname = item["ProductsName"].ToString();
                tran.Username = item["UserName"].ToString();
                tran.State = item["StateName"].ToString();
                list.Add(tran);
            }
            return list;
        }
        public static bool updatedate(string s)
        {
            string sql = string.Format(@"update t_TransferringOrder set  State = 2 where ID in ({0})", s);
            bool dt = DBHelper.ExecuteSql(sql);
            return dt;
        }

        public static List<t_TransferringOrder> getinfo(int index, int count ,int dataid)
        {
            string sql = string.Format(@"select  top {0} * from 
                   (select t.ID, ss.HouseName+'-'+ SubareaName  gg , t.Quantity,t.UserName ,t.ProductsID ,e.StateName,t.State
                    ,p.ProductsName from  t_TransferringOrder t, t_Products p,t_Ste e,
                   (select  SubareaName , t.HouseID ,ID,HouseName from t_StoreHouse 
                   t,t_StoreHouseDetail h where t.HouseID=h.HouseID) ss where ss.ID=t.InHouseID
                    and p.ProductsID=t.ProductsID and e.StateID=t.State) a ,
                   (select  t.ID ,ss.HouseName+'-'+ SubareaName kk  from  t_TransferringOrder t, 
                   (select  SubareaName , t.HouseID ,ID,HouseName from t_StoreHouse 
                   t,t_StoreHouseDetail h where t.HouseID=h.HouseID) ss where ss.ID=t.OutHouseID) b
                   where b.ID=a.ID and a.ID not in 
                   (select top {1} b.ID   from (select t.ID, ss.HouseName+'-'+ SubareaName  kk , t.Quantity,t.UserName ,t.ProductsID ,e.StateName,t.State
                    ,p.ProductsName from  t_TransferringOrder t, t_Products p,t_Ste e,
                   (select  SubareaName , t.HouseID ,ID,HouseName from t_StoreHouse 
                   t,t_StoreHouseDetail h where t.HouseID=h.HouseID) ss where ss.ID=t.InHouseID
                    and p.ProductsID=t.ProductsID and e.StateID=t.State) a ,
                   (select  t.ID ,ss.HouseName+'-'+ SubareaName  调出  from  t_TransferringOrder t, 
                   (select  SubareaName , t.HouseID ,ID,HouseName from t_StoreHouse 
                   t,t_StoreHouseDetail h where t.HouseID=h.HouseID) ss where ss.ID=t.OutHouseID) b
                   where b.ID=a.ID )", count, (index - 1) * count);
            DataTable dt = DBHelper.GetDatatable(sql);
            List<t_TransferringOrder> list = new List<t_TransferringOrder>();
            foreach (DataRow item in dt.Rows)
            {
                t_TransferringOrder tran = new t_TransferringOrder();
                tran.ID = item["ID"].ToString();
                tran.inStoreName = item["gg"].ToString();
                tran.outStoreName = item["kk"].ToString();
                tran.Productname = item["ProductsName"].ToString();
                tran.Username = item["UserName"].ToString();
                tran.State = item["StateName"].ToString();
                list.Add(tran);
            }
            return list;
        }
        public static int getgetindex()
        {
            string sql = string.Format(@"select  * from 
                   (select t.ID, ss.HouseName+'-'+ SubareaName  gg , t.Quantity,t.UserName ,t.ProductsID ,e.StateName,t.State
                    ,p.ProductsName from  t_TransferringOrder t, t_Products p,t_Ste e,
                   (select  SubareaName , t.HouseID ,ID,HouseName from t_StoreHouse 
                   t,t_StoreHouseDetail h where t.HouseID=h.HouseID) ss where ss.ID=t.InHouseID
                    and p.ProductsID=t.ProductsID and e.StateID=t.State) a ,
                   (select  t.ID ,ss.HouseName+'-'+ SubareaName 调出  from  t_TransferringOrder t, 
                   (select  SubareaName , t.HouseID ,ID,HouseName from t_StoreHouse 
                   t,t_StoreHouseDetail h where t.HouseID=h.HouseID) ss where ss.ID=t.OutHouseID) b
                   where b.ID=a.ID");
            DataTable dt = DBHelper.GetDatatable(sql);
            return dt.Rows.Count;
        }
        public static bool _TransferringOrderDel(string s)
        {
            string sql = string.Format("delete from t_TransferringOrder where ID=" + s);
            bool dt = DBHelper.ExecuteSql(sql);
            return dt;
        }
        }
}
