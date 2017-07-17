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
    public class ProductsBrandService
    {
        public static int ProductsBrandInsert(ProductsBrand s)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("insert into t_ProductsBrand values('{0}','{1}','{2}')", s.BrandName, s.Description, s.State);
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }
        public static List<ProductsBrand> ProductsBrandALL(int index, int rows)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select top {0} * from t_ProductsBrand where BrandID not in(select top {1} BrandID from t_ProductsBrand)", index, index * (rows - 1));
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<ProductsBrand> ll = new List<ProductsBrand>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ProductsBrand sh = new ProductsBrand();
                sh.BrandID = Convert.ToInt32(item["BrandID"].ToString());
                sh.BrandName = item["BrandName"].ToString();
                sh.State = item["State"].ToString();
                sh.Description = item["Description"].ToString();
                ll.Add(sh);
            }
            return ll;
        }
        public static int ProductsBrandzong()
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = "select * from t_ProductsBrand";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            return ds.Tables[0].Rows.Count;
        }

        public static int ProductsBrandDelete(int id)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = "delete from t_ProductsBrand where BrandID=" + id;
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }
        public static int ProductsBrandUpdate(ProductsBrand s)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("update t_ProductsBrand set BrandName='{0}' ,  Description='{1}' ,  State='{2}' where BrandID='{3}'", s.BrandName, s.Description, s.State, s.BrandID);
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }
        public static List<ProductsBrand> ProductsBrandID(int id)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select * from t_ProductsBrand where BrandID='{0}'", id);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<ProductsBrand> ll = new List<ProductsBrand>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ProductsBrand sh = new ProductsBrand();
                sh.BrandName = item["BrandName"].ToString();
                sh.State = item["State"].ToString();
                sh.Description = item["Description"].ToString();
                ll.Add(sh);
            }
            return ll;
        }
    }
}
