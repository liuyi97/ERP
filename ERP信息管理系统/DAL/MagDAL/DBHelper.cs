using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    class DBHelper
    {
        public static string connStr = "Data Source=.;Initial Catalog=ERP_DB;Integrated Security=True";

        public static SqlConnection conn = null;

        public static void InitConn()
        {
            if (conn == null)
            {
                conn = new SqlConnection(connStr);
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Open();
            }
            if (conn.State == ConnectionState.Broken)
            {
                conn.Close();
                conn.Open();
            }
        }

        public static DataTable GetDatatable(string sql)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            sda.Fill(dt);
            conn.Close();
            return dt;
        }

        public static bool ExecuteSql(string sql)
        {
            InitConn();
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = cmd.ExecuteNonQuery();
            return result > 0;
        }

        public static DataTable ExcuteProcedure(String proName, SqlParameter[] paras)
        {
            InitConn();
            SqlCommand cmd = new SqlCommand(proName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            for (int i = 0; i < paras.Length; i++)
            {
                cmd.Parameters.Add(paras[i]);
            }
            sda.Fill(dt);
            return dt;
        }
    }
}
