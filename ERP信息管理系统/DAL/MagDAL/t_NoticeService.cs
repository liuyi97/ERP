using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL.MagDAL
{
    public static class t_NoticeService
    {
        public static DataTable geta()
        {
            string sql = "select *from t_Notice where Type=0";
            DataTable dt = DBHelper.GetDatatable(sql);
            return dt;
        }
        public static DataTable getb()
        {
            string sql = "select *from t_Notice where Type=1";
            DataTable dt = DBHelper.GetDatatable(sql);
            return dt;
        }
        public static DataTable getc()
        {
            string sql = "select *from t_Notice where Type=2";
            DataTable dt = DBHelper.GetDatatable(sql);
            return dt;
        }
        public static DataTable getid(int id)
        {
            string sql = "select *from t_Notice where NoticeID=" + id;
            DataTable dt = DBHelper.GetDatatable(sql);
            return dt;

        }
    }
}
