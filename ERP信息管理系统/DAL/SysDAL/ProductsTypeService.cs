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
    public class ProductsTypeService
    {
        public static int ProductsTypeInsert(ProductsType s)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("insert into t_ProductsType values('{0}','{1}','{2}')", s.TypeName,s.State,s.Description);
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }
        public static List<ProductsType> ProductsTypeALL(int index, int rows)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select top {0} * from t_ProductsType where TypeID not in(select top {1} TypeID from t_ProductsType)", index, index * (rows - 1));
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<ProductsType> ll = new List<ProductsType>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ProductsType sh = new ProductsType();
                sh.TypeID = Convert.ToInt32(item["TypeID"].ToString());
                sh.TypeName = item["TypeName"].ToString();
                sh.State = item["State"].ToString();
                sh.Description = item["Description"].ToString();
                ll.Add(sh);
            }
            return ll;
        }
        public static int ProductsTypezong()
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = "select * from t_ProductsType";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            return ds.Tables[0].Rows.Count;
        }

        public static int ProductsTypeDelete(int id)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = "delete from t_ProductsType where TypeID=" + id;
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }
        public static int ProductsTypeUpdate(ProductsType s)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("update t_ProductsType set TypeName='{0}' ,  Description='{1}' ,  State='{2}' where TypeID='{3}'", s.TypeName, s.Description, s.State, s.TypeID);
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }
        public static List<ProductsType> ProductsTypeID(int id)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select * from t_ProductsType where TypeID='{0}'", id);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<ProductsType> ll = new List<ProductsType>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ProductsType sh = new ProductsType();
                sh.TypeName = item["TypeName"].ToString();
                sh.State = item["State"].ToString();
                sh.Description = item["Description"].ToString();
                ll.Add(sh);
            }
            return ll;
        }

    }
}
