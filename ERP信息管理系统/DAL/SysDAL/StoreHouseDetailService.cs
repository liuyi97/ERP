using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Model.SysModel;
using System.Data;

namespace DAL.SysDAL
{
    public class StoreHouseDetailService
    {
        public static List<StoreHouseDetail> StoreHouseDetailDrop()
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select * from t_StoreHouse");
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<StoreHouseDetail> ll = new List<StoreHouseDetail>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                StoreHouseDetail sh = new StoreHouseDetail();
                sh.HouseID = Convert.ToInt32(item["HouseID"].ToString());
                sh.HouseName = item["HouseName"].ToString();
                ll.Add(sh);
            }
            return ll;
        }
        public static List<StoreHouseDetail> StoreHouseDetailALL(int index, int rows)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select top {0} tl.HouseID,tl.ID,t.HouseName,tl.SubareaName,tl.Description,tl.State from t_StoreHouse t,t_StoreHouseDetail tl where t.HouseID=tl.HouseID and ID not in(select top {1} ID from t_StoreHouse t,t_StoreHouseDetail tl where t.HouseID=tl.HouseID)", index, index * (rows - 1));
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<StoreHouseDetail> ll = new List<StoreHouseDetail>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                StoreHouseDetail sh = new StoreHouseDetail();
                sh.HouseID = Convert.ToInt32(item["HouseID"].ToString());
                sh.ID = Convert.ToInt32(item["ID"].ToString());
                sh.HouseName = item["HouseName"].ToString();
                sh.SubareaName = item["SubareaName"].ToString();
                sh.Description = item["Description"].ToString();
                sh.State = item["State"].ToString();
                ll.Add(sh);
            }
            return ll;
        }
        public static int StoreHouseDetailzong()
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = "select * from t_StoreHouse t,t_StoreHouseDetail tl where t.HouseID=tl.HouseID";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            return ds.Tables[0].Rows.Count;
        }
        public static int StoreHouseDetailInsert(StoreHouseDetail s)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("insert into t_StoreHouseDetail values('{0}','{1}','{2}','{3}')",s.HouseID, s.SubareaName, s.Description,s.State);
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }
        public static int StoreHouseDetailDelete(int id)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = "delete from t_StoreHouseDetail where ID=" + id;
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }
        public static int StoreHouseDetailUpdate(StoreHouseDetail s)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("update t_StoreHouseDetail set HouseID='{0}' ,  SubareaName='{1}' ,  Description='{2}' ,  State='{3}'  where ID='{4}'", s.HouseID,s.SubareaName, s.Description,s.State, s.ID);
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }
        public static List<StoreHouseDetail> StoreHouseDetailID(int id)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select tl.HouseID,tl.ID,t.HouseName,tl.SubareaName,tl.Description,tl.State from t_StoreHouse t,t_StoreHouseDetail tl where t.HouseID=tl.HouseID and ID='{0}'", id);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<StoreHouseDetail> ll = new List<StoreHouseDetail>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                StoreHouseDetail sh = new StoreHouseDetail();
                sh.HouseID = Convert.ToInt32(item["HouseID"].ToString());
                sh.ID = Convert.ToInt32(item["ID"].ToString());
                sh.HouseName = item["HouseName"].ToString();
                sh.SubareaName = item["SubareaName"].ToString();
                sh.Description = item["Description"].ToString();
                sh.State = item["State"].ToString();
                ll.Add(sh);
            }
            return ll;
        }
    }
}
