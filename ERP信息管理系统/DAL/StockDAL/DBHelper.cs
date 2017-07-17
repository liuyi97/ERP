using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace DAL.NewFolder1
{
  public  class DBHelper
    {
        public static string constr = "Data Source=.;Initial Catalog=ERP_DB;Integrated Security=True";
        //查询DataTable
        public static DataTable GetDataTable(string sqlstr)
        {
            SqlConnection conn = new SqlConnection(constr);
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(sqlstr, conn);
            dap.Fill(ds);
            return ds.Tables[0];

        }

        //增删改
        public static bool ExecuteNon(string sqlstr)
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand com = new SqlCommand(sqlstr, conn);
            int rows = com.ExecuteNonQuery();
            conn.Close();
            return rows>0;
        }
    }
}