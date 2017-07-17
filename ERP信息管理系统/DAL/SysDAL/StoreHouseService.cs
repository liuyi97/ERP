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
    public class StoreHouseService
    {
        public static int StoreHouseInsert(StoreHouse s) {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("insert into t_StoreHouse values('{0}','{1}')",s.HouseName,s.Description);
            int rows=db.ExecuteNonQuery(CommandType.Text,sql);
            return rows;
        }
        public static List<StoreHouse> StoreHouseALL(int index,int rows) {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select top {0} * from t_StoreHouse where HouseID not in(select top {1} HouseID from t_StoreHouse)", index,index*(rows-1));
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<StoreHouse> ll = new List<StoreHouse>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                StoreHouse sh = new StoreHouse();
                sh.HouseID = Convert.ToInt32(item["HouseID"].ToString());
                sh.HouseName = item["HouseName"].ToString();
                sh.Description = item["Description"].ToString();
                ll.Add(sh);
            }
            return ll;
        }
        public static int StoreHousezong() {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = "select * from t_StoreHouse";
            DataSet ds = db.ExecuteDataSet(CommandType.Text,sql);
            return ds.Tables[0].Rows.Count;
        }

        public static int StoreHouseDelete(int id) {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = "delete from t_StoreHouse where HouseID="+id;
            int rows = db.ExecuteNonQuery(CommandType.Text,sql);
            return rows;
        }
        public static int StoreHouseUpdate(StoreHouse s) {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("update t_StoreHouse set HouseName='{0}' ,  Description='{1}' where HouseID='{2}'",s.HouseName,s.Description,s.HouseID);
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }
        public static List<StoreHouse> StoreHouseID(int id)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select * from t_StoreHouse where HouseID='{0}'", id);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<StoreHouse> ll = new List<StoreHouse>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                StoreHouse sh = new StoreHouse();
                sh.HouseName = item["HouseName"].ToString();
                sh.Description = item["Description"].ToString();
                ll.Add(sh);
            }
            return ll;
        }
    }
}
