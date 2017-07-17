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
    public class ProductsService
    {
        public static List<Products> ProductsALL(int index, int rows)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select top {0} * from t_Products where ProductsID not in(select top {1} ProductsID from t_Products)", index, index * (rows - 1));
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<Products> ll = new List<Products>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Products sh = new Products();
                sh.ProductsID = Convert.ToInt32(item["ProductsID"].ToString());
                sh.ProductsName = item["ProductsName"].ToString();
                sh.TypeID = Convert.ToInt32(item["TypeID"].ToString());
                sh.BrandID = Convert.ToInt32(item["BrandID"].ToString());
                sh.BeginEnterDate = item["BeginEnterDate"].ToString();
                sh.FinalEnterDate = item["FinalEnterDate"].ToString();
                sh.LatelyOFSDate = item["LatelyOFSDate"].ToString();
                sh.LoadingDate = item["LoadingDate"].ToString();
                sh.Cost = Convert.ToDouble(item["Cost"].ToString());
                sh.Price = Convert.ToDouble(item["Price"].ToString());
                sh.UnshelveDate = item["UnshelveDate"].ToString();
                sh.ProductsUints = item["ProductsUints"].ToString();
                sh.Color = item["Color"].ToString();
                sh.Weight = item["Weight"].ToString();
                sh.Material = item["Material"].ToString();
                sh.Spec = item["Spec"].ToString();
                sh.UpperLimit = Convert.ToInt32(item["UpperLimit"].ToString());
                sh.LowerLimit = Convert.ToInt32(item["LowerLimit"].ToString());
                sh.PhotoUrl = item["PhotoUrl"].ToString();
                sh.TotalSalesNum = Convert.ToInt32(item["TotalSalesNum"].ToString());
                sh.StocksNum = Convert.ToInt32(item["StocksNum"].ToString());
                sh.State = item["State"].ToString();
                sh.Description = item["Description"].ToString();
                ll.Add(sh);
            }
            return ll;
        }

        public static int Productszong()
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = "select * from t_Products";
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            return ds.Tables[0].Rows.Count;
        }

        public static List<Products> ProductsALL1(int index, int rows,string d1,string d2,string t)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select top {0} * from t_Products where t_Products.TypeID='{1}' and t_Products.BrandID='{2}' and t_Products.ProductsName like '%{3}%' and ProductsID not in(select top {4} ProductsID from t_Products where t_Products.TypeID='{5}' and t_Products.BrandID='{6}' and t_Products.ProductsName like '%{7}%')", index, d2, d1, t, index * (rows - 1), d2, d1, t);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<Products> ll = new List<Products>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Products sh = new Products();
                sh.ProductsID = Convert.ToInt32(item["ProductsID"].ToString());
                sh.ProductsName = item["ProductsName"].ToString();
                sh.TypeID = Convert.ToInt32(item["TypeID"].ToString());
                sh.BrandID = Convert.ToInt32(item["BrandID"].ToString());
                sh.BeginEnterDate = item["BeginEnterDate"].ToString();
                sh.FinalEnterDate = item["FinalEnterDate"].ToString();
                sh.LatelyOFSDate = item["LatelyOFSDate"].ToString();
                sh.LoadingDate = item["LoadingDate"].ToString();
                sh.Cost = Convert.ToDouble(item["Cost"].ToString());
                sh.Price = Convert.ToDouble(item["Price"].ToString());
                sh.UnshelveDate = item["UnshelveDate"].ToString();
                sh.ProductsUints = item["ProductsUints"].ToString();
                sh.Color = item["Color"].ToString();
                sh.Weight = item["Weight"].ToString();
                sh.Material = item["Material"].ToString();
                sh.Spec = item["Spec"].ToString();
                sh.UpperLimit = Convert.ToInt32(item["UpperLimit"].ToString());
                sh.LowerLimit = Convert.ToInt32(item["LowerLimit"].ToString());
                sh.PhotoUrl = item["PhotoUrl"].ToString();
                sh.TotalSalesNum = Convert.ToInt32(item["TotalSalesNum"].ToString());
                sh.StocksNum = Convert.ToInt32(item["StocksNum"].ToString());
                sh.State = item["State"].ToString();
                sh.Description = item["Description"].ToString();
                ll.Add(sh);
            }
            return ll;
        }

        public static int Productszong1(string d1, string d2, string t)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select * from t_Products where t_Products.TypeID='{0}' and t_Products.TypeID='{1}' and t_Products.ProductsName like '%{2}%'", d2, d1, t);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            return ds.Tables[0].Rows.Count;
        }

        public static List<Products> ProductsALL2(int index, int rows, string d1, string d2)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select top {0} * from t_Products where t_Products.TypeID='{1}' and t_Products.BrandID='{2}' and ProductsID not in(select top {3} ProductsID from t_Products where t_Products.TypeID='{4}' and t_Products.BrandID='{5}')", index, d2, d1, index * (rows - 1), d2, d1);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<Products> ll = new List<Products>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Products sh = new Products();
                sh.ProductsID = Convert.ToInt32(item["ProductsID"].ToString());
                sh.ProductsName = item["ProductsName"].ToString();
                sh.TypeID = Convert.ToInt32(item["TypeID"].ToString());
                sh.BrandID = Convert.ToInt32(item["BrandID"].ToString());
                sh.BeginEnterDate = item["BeginEnterDate"].ToString();
                sh.FinalEnterDate = item["FinalEnterDate"].ToString();
                sh.LatelyOFSDate = item["LatelyOFSDate"].ToString();
                sh.LoadingDate = item["LoadingDate"].ToString();
                sh.Cost = Convert.ToDouble(item["Cost"].ToString());
                sh.Price = Convert.ToDouble(item["Price"].ToString());
                sh.UnshelveDate = item["UnshelveDate"].ToString();
                sh.ProductsUints = item["ProductsUints"].ToString();
                sh.Color = item["Color"].ToString();
                sh.Weight = item["Weight"].ToString();
                sh.Material = item["Material"].ToString();
                sh.Spec = item["Spec"].ToString();
                sh.UpperLimit = Convert.ToInt32(item["UpperLimit"].ToString());
                sh.LowerLimit = Convert.ToInt32(item["LowerLimit"].ToString());
                sh.PhotoUrl = item["PhotoUrl"].ToString();
                sh.TotalSalesNum = Convert.ToInt32(item["TotalSalesNum"].ToString());
                sh.StocksNum = Convert.ToInt32(item["StocksNum"].ToString());
                sh.State = item["State"].ToString();
                sh.Description = item["Description"].ToString();
                ll.Add(sh);
            }
            return ll;
        }

        public static int Productszong2(string d1, string d2)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select * from t_Products where t_Products.TypeID='{0}' and t_Products.BrandID='{1}'", d2, d1);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            return ds.Tables[0].Rows.Count;
        }

        public static List<Products> ProductsALL3(int index, int rows, string d1, string t)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select top {0} * from t_Products where t_Products.TypeID='{1}' and t_Products.ProductsName like '%{2}%' and ProductsID not in(select top {3} ProductsID from t_Products where t_Products.TypeID='{4}' and t_Products.ProductsName like '%{5}%')", index, d1, t, index * (rows - 1), d1, t);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<Products> ll = new List<Products>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Products sh = new Products();
                sh.ProductsID = Convert.ToInt32(item["ProductsID"].ToString());
                sh.ProductsName = item["ProductsName"].ToString();
                sh.TypeID = Convert.ToInt32(item["TypeID"].ToString());
                sh.BrandID = Convert.ToInt32(item["BrandID"].ToString());
                sh.BeginEnterDate = item["BeginEnterDate"].ToString();
                sh.FinalEnterDate = item["FinalEnterDate"].ToString();
                sh.LatelyOFSDate = item["LatelyOFSDate"].ToString();
                sh.LoadingDate = item["LoadingDate"].ToString();
                sh.Cost = Convert.ToDouble(item["Cost"].ToString());
                sh.Price = Convert.ToDouble(item["Price"].ToString());
                sh.UnshelveDate = item["UnshelveDate"].ToString();
                sh.ProductsUints = item["ProductsUints"].ToString();
                sh.Color = item["Color"].ToString();
                sh.Weight = item["Weight"].ToString();
                sh.Material = item["Material"].ToString();
                sh.Spec = item["Spec"].ToString();
                sh.UpperLimit = Convert.ToInt32(item["UpperLimit"].ToString());
                sh.LowerLimit = Convert.ToInt32(item["LowerLimit"].ToString());
                sh.PhotoUrl = item["PhotoUrl"].ToString();
                sh.TotalSalesNum = Convert.ToInt32(item["TotalSalesNum"].ToString());
                sh.StocksNum = Convert.ToInt32(item["StocksNum"].ToString());
                sh.State = item["State"].ToString();
                sh.Description = item["Description"].ToString();
                ll.Add(sh);
            }
            return ll;
        }

        public static int Productszong3(string d1, string t)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select * from t_Products where t_Products.TypeID='{0}' and t_Products.ProductsName like '%{1}%'", d1, t);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            return ds.Tables[0].Rows.Count;
        }

        public static List<Products> ProductsALL4(int index, int rows, string d1)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select top {0} * from t_Products where t_Products.TypeID='{1}' and ProductsID not in(select top {2} ProductsID from t_Products where t_Products.TypeID='{3}')", index, d1, index * (rows - 1), d1);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<Products> ll = new List<Products>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Products sh = new Products();
                sh.ProductsID = Convert.ToInt32(item["ProductsID"].ToString());
                sh.ProductsName = item["ProductsName"].ToString();
                sh.TypeID = Convert.ToInt32(item["TypeID"].ToString());
                sh.BrandID = Convert.ToInt32(item["BrandID"].ToString());
                sh.BeginEnterDate = item["BeginEnterDate"].ToString();
                sh.FinalEnterDate = item["FinalEnterDate"].ToString();
                sh.LatelyOFSDate = item["LatelyOFSDate"].ToString();
                sh.LoadingDate = item["LoadingDate"].ToString();
                sh.Cost = Convert.ToDouble(item["Cost"].ToString());
                sh.Price = Convert.ToDouble(item["Price"].ToString());
                sh.UnshelveDate = item["UnshelveDate"].ToString();
                sh.ProductsUints = item["ProductsUints"].ToString();
                sh.Color = item["Color"].ToString();
                sh.Weight = item["Weight"].ToString();
                sh.Material = item["Material"].ToString();
                sh.Spec = item["Spec"].ToString();
                sh.UpperLimit = Convert.ToInt32(item["UpperLimit"].ToString());
                sh.LowerLimit = Convert.ToInt32(item["LowerLimit"].ToString());
                sh.PhotoUrl = item["PhotoUrl"].ToString();
                sh.TotalSalesNum = Convert.ToInt32(item["TotalSalesNum"].ToString());
                sh.StocksNum = Convert.ToInt32(item["StocksNum"].ToString());
                sh.State = item["State"].ToString();
                sh.Description = item["Description"].ToString();
                ll.Add(sh);
            }
            return ll;
        }

        public static int Productszong4(string d1)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select * from t_Products where t_Products.TypeID='{0}'", d1);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            return ds.Tables[0].Rows.Count;
        }

        public static List<Products> ProductsALL5(int index, int rows, string d2, string t)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select top {0} * from t_Products where t_Products.BrandID='{1}' and t_Products.ProductsName like '%{2}%' and ProductsID not in(select top {3} ProductsID from t_Products where t_Products.BrandID='{4}' and t_Products.ProductsName like '%{5}%')", index, d2, t, index * (rows - 1), d2, t);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<Products> ll = new List<Products>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Products sh = new Products();
                sh.ProductsID = Convert.ToInt32(item["ProductsID"].ToString());
                sh.ProductsName = item["ProductsName"].ToString();
                sh.TypeID = Convert.ToInt32(item["TypeID"].ToString());
                sh.BrandID = Convert.ToInt32(item["BrandID"].ToString());
                sh.BeginEnterDate = item["BeginEnterDate"].ToString();
                sh.FinalEnterDate = item["FinalEnterDate"].ToString();
                sh.LatelyOFSDate = item["LatelyOFSDate"].ToString();
                sh.LoadingDate = item["LoadingDate"].ToString();
                sh.Cost = Convert.ToDouble(item["Cost"].ToString());
                sh.Price = Convert.ToDouble(item["Price"].ToString());
                sh.UnshelveDate = item["UnshelveDate"].ToString();
                sh.ProductsUints = item["ProductsUints"].ToString();
                sh.Color = item["Color"].ToString();
                sh.Weight = item["Weight"].ToString();
                sh.Material = item["Material"].ToString();
                sh.Spec = item["Spec"].ToString();
                sh.UpperLimit = Convert.ToInt32(item["UpperLimit"].ToString());
                sh.LowerLimit = Convert.ToInt32(item["LowerLimit"].ToString());
                sh.PhotoUrl = item["PhotoUrl"].ToString();
                sh.TotalSalesNum = Convert.ToInt32(item["TotalSalesNum"].ToString());
                sh.StocksNum = Convert.ToInt32(item["StocksNum"].ToString());
                sh.State = item["State"].ToString();
                sh.Description = item["Description"].ToString();
                ll.Add(sh);
            }
            return ll;
        }

        public static int Productszong5( string d2, string t)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select * from t_Products where t_Products.BrandID='{0}' and t_Products.ProductsName like '%{1}%'", d2, t);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            return ds.Tables[0].Rows.Count;
        }

        public static List<Products> ProductsALL6(int index, int rows, string d2)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select top {0} * from t_Products where t_Products.BrandID='{1}' and ProductsID not in(select top {2} ProductsID from t_Products where t_Products.BrandID='{3}' )", index, d2, index * (rows - 1), d2);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<Products> ll = new List<Products>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Products sh = new Products();
                sh.ProductsID = Convert.ToInt32(item["ProductsID"].ToString());
                sh.ProductsName = item["ProductsName"].ToString();
                sh.TypeID = Convert.ToInt32(item["TypeID"].ToString());
                sh.BrandID = Convert.ToInt32(item["BrandID"].ToString());
                sh.BeginEnterDate = item["BeginEnterDate"].ToString();
                sh.FinalEnterDate = item["FinalEnterDate"].ToString();
                sh.LatelyOFSDate = item["LatelyOFSDate"].ToString();
                sh.LoadingDate = item["LoadingDate"].ToString();
                sh.Cost = Convert.ToDouble(item["Cost"].ToString());
                sh.Price = Convert.ToDouble(item["Price"].ToString());
                sh.UnshelveDate = item["UnshelveDate"].ToString();
                sh.ProductsUints = item["ProductsUints"].ToString();
                sh.Color = item["Color"].ToString();
                sh.Weight = item["Weight"].ToString();
                sh.Material = item["Material"].ToString();
                sh.Spec = item["Spec"].ToString();
                sh.UpperLimit = Convert.ToInt32(item["UpperLimit"].ToString());
                sh.LowerLimit = Convert.ToInt32(item["LowerLimit"].ToString());
                sh.PhotoUrl = item["PhotoUrl"].ToString();
                sh.TotalSalesNum = Convert.ToInt32(item["TotalSalesNum"].ToString());
                sh.StocksNum = Convert.ToInt32(item["StocksNum"].ToString());
                sh.State = item["State"].ToString();
                sh.Description = item["Description"].ToString();
                ll.Add(sh);
            }
            return ll;
        }

        public static int Productszong6(string d2)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select * from t_Products where t_Products.BrandID='{0}'", d2);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            return ds.Tables[0].Rows.Count;
        }

        public static List<Products> ProductsALL7(int index, int rows, string t)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select top {0} * from t_Products where t_Products.ProductsName like '%{1}%' and ProductsID not in(select top {2} ProductsID from t_Products where t_Products.ProductsName like '%{3}%')", index, t, index * (rows - 1), t);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<Products> ll = new List<Products>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Products sh = new Products();
                sh.ProductsID = Convert.ToInt32(item["ProductsID"].ToString());
                sh.ProductsName = item["ProductsName"].ToString();
                sh.TypeID = Convert.ToInt32(item["TypeID"].ToString());
                sh.BrandID = Convert.ToInt32(item["BrandID"].ToString());
                sh.BeginEnterDate = item["BeginEnterDate"].ToString();
                sh.FinalEnterDate = item["FinalEnterDate"].ToString();
                sh.LatelyOFSDate = item["LatelyOFSDate"].ToString();
                sh.LoadingDate = item["LoadingDate"].ToString();
                sh.Cost = Convert.ToDouble(item["Cost"].ToString());
                sh.Price = Convert.ToDouble(item["Price"].ToString());
                sh.UnshelveDate = item["UnshelveDate"].ToString();
                sh.ProductsUints = item["ProductsUints"].ToString();
                sh.Color = item["Color"].ToString();
                sh.Weight = item["Weight"].ToString();
                sh.Material = item["Material"].ToString();
                sh.Spec = item["Spec"].ToString();
                sh.UpperLimit = Convert.ToInt32(item["UpperLimit"].ToString());
                sh.LowerLimit = Convert.ToInt32(item["LowerLimit"].ToString());
                sh.PhotoUrl = item["PhotoUrl"].ToString();
                sh.TotalSalesNum = Convert.ToInt32(item["TotalSalesNum"].ToString());
                sh.StocksNum = Convert.ToInt32(item["StocksNum"].ToString());
                sh.State = item["State"].ToString();
                sh.Description = item["Description"].ToString();
                ll.Add(sh);
            }
            return ll;
        }

        public static int Productszong7( string t)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select * from t_Products where t_Products.ProductsName like '%{0}%'", t);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            return ds.Tables[0].Rows.Count;
        }

        public static List<ProductsType> ProductsTypeDrop()
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select  * from t_ProductsType");
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<ProductsType> ll = new List<ProductsType>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ProductsType sh = new ProductsType();
                sh.TypeID = Convert.ToInt32(item["TypeID"].ToString());
                sh.TypeName = item["TypeName"].ToString();
                ll.Add(sh);
            }
            return ll;
        }

        public static List<ProductsBrand> ProductsBrandDrop()
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select * from t_ProductsBrand");
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<ProductsBrand> ll = new List<ProductsBrand>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ProductsBrand sh = new ProductsBrand();
                sh.BrandID = Convert.ToInt32(item["BrandID"].ToString());
                sh.BrandName = item["BrandName"].ToString();
                ll.Add(sh);
            }
            return ll;
        }

        public static int ProductsDelete(int id)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = "delete from t_Products where ProductsID=" + id;
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }

        public static int ProductsInsert(Products s)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("insert into t_Products(ProductsName,TypeID,BrandID,Color,ProductsUints,Cost,Weight,Price,Spec,Material,UpperLimit,LowerLimit,BeginEnterDate,FinalEnterDate,LoadingDate,LatelyOFSDate,UnshelveDate,Description) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}')", s.ProductsName, s.TypeID, s.BrandID, s.Color, s.ProductsUints, s.Cost, s.Weight, s.Price, s.Spec, s.Material, s.UpperLimit, s.LowerLimit, s.BeginEnterDate, s.FinalEnterDate, s.LoadingDate, s.LatelyOFSDate, s.UnshelveDate, s.Description);
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }

        public static int ProductsUpdate(Products s)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("update t_Products set ProductsName='{0}',TypeID='{1}',BrandID='{2}',Color='{3}',ProductsUints='{4}',Cost='{5}',Weight='{6}',Price='{7}',Spec='{8}',Material='{9}',UpperLimit='{10}',LowerLimit='{11}',BeginEnterDate='{12}',FinalEnterDate='{13}',LoadingDate='{14}',LatelyOFSDate='{15}',UnshelveDate='{16}',Description='{17}' where ProductsID='{18}'", s.ProductsName, s.TypeID, s.BrandID, s.Color, s.ProductsUints, s.Cost, s.Weight, s.Price, s.Spec, s.Material, s.UpperLimit, s.LowerLimit, s.BeginEnterDate, s.FinalEnterDate, s.LoadingDate, s.LatelyOFSDate, s.UnshelveDate, s.Description,s.ProductsID);
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }

        public static List<Products> ProductsID(int id)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select * from t_Products p,t_ProductsBrand pd,t_ProductsType pt where p.BrandID=pd.BrandID and p.TypeID=pt.TypeID and ProductsID={0} ", id);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            List<Products> ll = new List<Products>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Products sh = new Products();
                sh.ProductsID = Convert.ToInt32(item["ProductsID"].ToString());
                sh.ProductsName = item["ProductsName"].ToString();
                sh.TypeID = Convert.ToInt32(item["TypeID"].ToString());
                sh.TypeName = item["TypeName"].ToString();
                sh.BrandID = Convert.ToInt32(item["BrandID"].ToString());
                sh.BrandName = item["BrandName"].ToString();
                sh.BeginEnterDate = item["BeginEnterDate"].ToString();
                sh.FinalEnterDate = item["FinalEnterDate"].ToString();
                sh.LatelyOFSDate = item["LatelyOFSDate"].ToString();
                sh.LoadingDate = item["LoadingDate"].ToString();
                sh.Cost = Convert.ToDouble(item["Cost"].ToString());
                sh.Price = Convert.ToDouble(item["Price"].ToString());
                sh.UnshelveDate = item["UnshelveDate"].ToString();
                sh.ProductsUints = item["ProductsUints"].ToString();
                sh.Color = item["Color"].ToString();
                sh.Weight = item["Weight"].ToString();
                sh.Material = item["Material"].ToString();
                sh.Spec = item["Spec"].ToString();
                sh.UpperLimit = Convert.ToInt32(item["UpperLimit"].ToString());
                sh.LowerLimit = Convert.ToInt32(item["LowerLimit"].ToString());
                sh.PhotoUrl = item["PhotoUrl"].ToString();
                sh.TotalSalesNum = Convert.ToInt32(item["TotalSalesNum"].ToString());
                sh.StocksNum = Convert.ToInt32(item["StocksNum"].ToString());
                sh.State = item["State"].ToString();
                sh.Description = item["Description"].ToString();
                ll.Add(sh);
            }
            return ll;
        }
        public static int ProductsTuPianUpdate(Products s) {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("update t_Products set PhotoUrl='{0}' where ProductsID='{1}'", s.PhotoUrl, s.ProductsID);
            int rows = db.ExecuteNonQuery(CommandType.Text, sql);
            return rows;
        }
        public static DataTable ProductserjiList(int id)
        {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("select * from t_Products_UserType t,t_UserTypeSubClass tu,t_UserType tut where t.SubClassID=tu.SubClassID and tu.UserTypeID=tut.TypeID and t.ProductsID='{0}'",id);
            DataSet rows = db.ExecuteDataSet(CommandType.Text, sql);
            return rows.Tables[0];
        }
        public static int tiaojiaUpdate(int typeid, double price) {
            Database db = DatabaseFactory.CreateDatabase("Constr");
            string sql = string.Format("update t_Products_UserType set price ='{0}' where TypeID='{1}'",price,typeid);
            int rows = db.ExecuteNonQuery(CommandType.Text,sql);
            return rows;
        }
    }
}
