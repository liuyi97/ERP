using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;


namespace DAL
{
     public   class t_UserService
    {
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <returns></returns>
        public static int getLogin(t_User u)
        {
            string sql = string.Format(@"select *from t_User where UserName='{0}' and Password='{1}'",u.UserName,u.Password);
            DataTable ds = DBHelper.GetDatatable(sql);
            return ds.Rows.Count;            
        }
        public static int getLoginTypeid(t_User u)
        {
            string sql = string.Format("select GroupID from t_User where UserName='{0}' and Password='{1}'", u.UserName, u.Password);
            DataTable ds = DBHelper.GetDatatable(sql);
            t_User f = new t_User();
        
            foreach (DataRow item in ds.Rows)
            {
                f.TypeID = Convert.ToInt32(item["GroupID"]);
            }
            return f.TypeID;
        }
    }
}
