using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DAL
{
   public  static class t_AuthorityService
    {
        public static DataTable getindexa(int a)
        {
            string sql = string.Format(@"select distinct dd.AuthorityID,dd.WebUrl, dd.TypeID,dd.AuthorityName ,dd.GroupID  from t_User u join
(select  t.AuthorityID,t.WebUrl, t.AuthorityName, g.GroupID, t.TypeID from t_Authority
  t join t_GroupAuthority g on t.AuthorityID = g.AuthorityID)
  dd  on u.GroupID = dd.GroupID and dd.GroupID='{0}' and dd.TypeID=0", a);
            DataTable dt = DBHelper.GetDatatable(sql);
            return dt;
        }
        public static DataTable getindexb(int a)
        {
            string sql = string.Format(@"select distinct dd.AuthorityID,dd.WebUrl, dd.TypeID,dd.AuthorityName ,dd.GroupID  from t_User u join
             (select  t.AuthorityID,t.WebUrl, t.AuthorityName, g.GroupID, t.TypeID from t_Authority
            t join t_GroupAuthority g on t.AuthorityID = g.AuthorityID)
              dd  on u.GroupID = dd.GroupID and dd.GroupID='{0}' and dd.TypeID=1", a);
            DataTable dt = DBHelper.GetDatatable(sql);
            return dt;
        }
        public static DataTable getindexc(int a)
        {
            string sql = string.Format(@"select distinct dd.AuthorityID,dd.WebUrl, dd.TypeID,dd.AuthorityName ,dd.GroupID  from t_User u join
             (select  t.AuthorityID, t.WebUrl,t.AuthorityName, g.GroupID, t.TypeID from t_Authority
            t join t_GroupAuthority g on t.AuthorityID = g.AuthorityID)
              dd  on u.GroupID = dd.GroupID and dd.GroupID='{0}' and dd.TypeID=3", a);
            DataTable dt = DBHelper.GetDatatable(sql);
            return dt;
        }
        public static DataTable getindexd(int a)
        {
            string sql = string.Format(@"select distinct dd.AuthorityID,dd.WebUrl, dd.TypeID,dd.AuthorityName ,dd.GroupID  from t_User u join
             (select  t.AuthorityID, t.WebUrl, t.AuthorityName, g.GroupID, t.TypeID from t_Authority
            t join t_GroupAuthority g on t.AuthorityID = g.AuthorityID)
              dd  on u.GroupID = dd.GroupID and dd.GroupID='{0}' and dd.TypeID=4", a);
            DataTable dt = DBHelper.GetDatatable(sql);
            return dt;
        }
    }
}
