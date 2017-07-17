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
    public class GroupService
    {
        public static int GroupInsert(Group s)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("insert into t_Group values('{0}','{1}')", s.GroupName, s.Description);
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }
        public static List<Group> GroupALL(int index, int rows)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select top {0} * from t_Group where GroupID not in(select top {1} GroupID from t_Group)", index, index * (rows - 1));
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<Group> ll = new List<Group>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Group sh = new Group();
                sh.GroupID = Convert.ToInt32(item["GroupID"].ToString());
                sh.GroupName = item["GroupName"].ToString();
                sh.Description = item["Description"].ToString();
                ll.Add(sh);
            }
            return ll;
        }
  
        public static int Groupzong()
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = "select * from t_Group";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            return ds.Tables[0].Rows.Count;
        }

        public static int GroupDelete(int id)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = "delete from t_Group where GroupID=" + id;
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }
        public static int GroupUpdate(Group s)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("update t_Group set GroupName='{0}' ,  Description='{1}' where GroupID='{2}'", s.GroupName, s.Description, s.GroupID);
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }
        public static List<Group> GroupID(int id)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select * from t_Group where GroupID='{0}'", id);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<Group> ll = new List<Group>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Group sh = new Group();
                sh.GroupName = item["GroupName"].ToString();
                sh.Description = item["Description"].ToString();
                ll.Add(sh);
            }
            return ll;
        }
        //public static DataTable xuan(int index,int rows) {
        //    Database db = DatabaseFactory.CreateDatabase("Constr");
        //    string sq = string.Format("select top {0} * from t_Authority where AuthorityID not in(select top {1} AuthorityID from t_Authority order by TypeID ) order by TypeID", index, index * (rows - 1));
        //    DataSet ds = db.ExecuteDataSet(CommandType.Text,sq);
        //    return ds.Tables[0];
        //}
        public static DataTable xuan()
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sq = string.Format("select * from t_Authority order by TypeID");
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sq);
            return ds.Tables[0];
        }
        public static int xuanzong() {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sq = string.Format("select * from t_Authority");
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sq);
            return ds.Tables[0].Rows.Count;
        }
        public static DataTable ckxuan(int id) {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sq = string.Format("select AuthorityID from t_GroupAuthority where GroupID='{0}'", id);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sq);
            return ds.Tables[0];
        }
        public static int ckzeng(int id1, int id2) {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("insert into t_GroupAuthority values('{0}','{1}')", id1,id2);
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }
        public static int ckshan(int id1, int id2) {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("delete from t_GroupAuthority where AuthorityID='{0}' and GroupID='{1}'", id1, id2);
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }
    }
}
