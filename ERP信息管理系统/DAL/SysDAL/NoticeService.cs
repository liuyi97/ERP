using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model.SysModel;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DAL.SysDAL
{
    public class NoticeService
    {
        public static int NoticeInsert(int type,string Title,string UserName,string CreateDate,string Info) {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("insert into t_Notice values('{0}','{1}','{2}','{3}','{4}')",type,Title,UserName,CreateDate,Info);
            int rows = db.ExecuteNonQuery(CommandType.Text,sql);
            return rows;
        }
        public static DataTable LogAll(int index,int rows) {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select top {0} * from t_log where LogID not in(select top {1} LogID from t_log)",index,rows);
            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        }
        public static int LogZong() {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = "select * from t_log";
            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0].Rows.Count;
        }
        public static int LogInsert(string time,string del) {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("insert into t_log values('{0}','{1}')",time,del);
            return db.ExecuteNonQuery(CommandType.Text, sql);
        }
    }
}
