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
    public class UserTypeService
    {
        public static List<UserType> StoreHouseDetailDrop()
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select * from t_UserType");
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<UserType> ll = new List<UserType>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                UserType sh = new UserType();
                sh.UserTypeID = Convert.ToInt32(item["TypeID"].ToString());
                sh.TypeName = item["TypeName"].ToString();
                ll.Add(sh);
            }
            return ll;
        }
        public static List<UserType> UserTypeALL(int index, int rows)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select top {0} * from t_UserTypeSubClass tl,t_UserType t where t.TypeID=tl.UserTypeID and SubClassID not in(select top {1} SubClassID from t_UserType t,t_UserTypeSubClass tl where t.TypeID=tl.UserTypeID)", index, index * (rows - 1));
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<UserType> ll = new List<UserType>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                UserType sh = new UserType();
                sh.SubClassID = Convert.ToInt32(item["SubClassID"].ToString());
                sh.UserTypeID = Convert.ToInt32(item["UserTypeID"].ToString());
                sh.SubClassName = item["SubClassName"].ToString();
                sh.TypeName = item["TypeName"].ToString();
                sh.State = item["State"].ToString();
                ll.Add(sh);
            }
            return ll;
        }
        public static int UserTypezong()
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = "select * from t_UserTypeSubClass tl,t_UserType t where t.TypeID=tl.UserTypeID";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            return ds.Tables[0].Rows.Count;
        }
        public static int UserTypeInsert(UserType s)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("insert into t_UserTypeSubClass values('{0}','{1}','{2}')", s.UserTypeID, s.SubClassName, s.State);
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }
        public static int UserTypeDelete(int id)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = "delete from t_UserTypeSubClass where SubClassID=" + id;
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }
        public static int UserTypeUpdate(UserType s)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("update t_UserTypeSubClass set UserTypeID='{0}' ,  SubClassName='{1}',  State='{2}'  where SubClassID='{3}'", s.UserTypeID, s.SubClassName, s.State, s.SubClassID);
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }
        public static List<UserType> UserTypeID(int id)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select * from t_UserTypeSubClass tl,t_UserType t where t.TypeID=tl.UserTypeID and SubClassID='{0}'", id);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<UserType> ll = new List<UserType>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                UserType sh = new UserType();
                sh.SubClassID = Convert.ToInt32(item["SubClassID"].ToString());
                sh.UserTypeID = Convert.ToInt32(item["UserTypeID"].ToString());
                sh.SubClassName = item["SubClassName"].ToString();
                sh.TypeName = item["TypeName"].ToString();
                sh.State = item["State"].ToString();
                ll.Add(sh);
            }
            return ll;
        }
    }
}
