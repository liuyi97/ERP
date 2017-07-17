using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.MagMdl;
using System.Data;
namespace DAL.MagDAL
{
    public  class StockStatusSerive
    {

        public static int StockStatuscount()
        {
            string sql = "";
            sql = string.Format(@"select  *
 from t_Products  p , t_ProductsStock d ,t_StoreHouse h ,t_StoreHouseDetail t where
p.ProductsID=d.ProductsID and t.HouseID=h.HouseID and t.ID= d.HouseDetailID");
            DataTable dt = DBHelper.GetDatatable(sql);
            return dt.Rows.Count;
        }
        public static int StockStatuscounta(string SubName, string StoreName, int index, int count)
        {
            string sql = "";
            sql = string.Format(@"select top {0} h.HouseName,t.SubareaName ,p.ProductsName,p.ProductsID,p.UpperLimit,p.LowerLimit,
p.Cost ,d.Num from t_Products  p , t_ProductsStock d ,t_StoreHouse h ,t_StoreHouseDetail t where
p.ProductsID=d.ProductsID and t.HouseID=h.HouseID and t.ID= d.HouseDetailID and p.ProductsID not
               in(select top {1} P.ProductsID from  t_Products  p , t_ProductsStock d ,t_StoreHouse h ,t_StoreHouseDetail t where
p.ProductsID=d.ProductsID and t.HouseID=h.HouseID and t.ID= d.HouseDetailID order by P.ProductsID) and SubareaName='{2}'  and HouseName='{3}'  order by P.ProductsID
                 ", count, (index - 1) * count, SubName, StoreName);
            DataTable dt = DBHelper.GetDatatable(sql);
            return dt.Rows.Count;
        }
        public static List<StockStatus> StockStatusinfo(int index, int count)
        {
            string sql = "";
             sql = string.Format(@"select top {0} h.HouseName,t.SubareaName ,p.ProductsName,p.ProductsID,p.UpperLimit,p.LowerLimit,
p.Cost ,d.Num from t_Products  p , t_ProductsStock d ,t_StoreHouse h ,t_StoreHouseDetail t where
p.ProductsID=d.ProductsID and t.HouseID=h.HouseID and t.ID= d.HouseDetailID and d.ID not
               in(select top {1} d.ID from  t_Products  p , t_ProductsStock d ,t_StoreHouse h ,t_StoreHouseDetail t where
p.ProductsID=d.ProductsID and t.HouseID=h.HouseID and t.ID= d.HouseDetailID order by d.ID) order by d.ID
                 ", count, (index - 1) * count);
            DataTable dt = DBHelper.GetDatatable(sql);
            List<StockStatus> list = new List<StockStatus>();
            foreach (DataRow item in dt.Rows)
            {
                StockStatus e = new StockStatus();
                e.Cost = Convert.ToDouble(item["Cost"].ToString());
                e.downlimit =Convert.ToInt32( item["LowerLimit"]);
                e.HouseName = item["HouseName"].ToString();  
                e.SubareaName = item["SubareaName"].ToString();
                e.productID = Convert.ToInt32( item["ProductsID"]);
                e.ProductName = item["ProductsName"].ToString();
                e.num = Convert.ToInt32(item["num"]);
                list.Add(e);
            }
            return list;
        }

        public static List<t_StoreHouse> getA()
        {
            string sqlstr = string.Format("select * from t_StoreHouse");
            DataTable dt = DBHelper.GetDatatable(sqlstr);
            List<t_StoreHouse> list = new List<t_StoreHouse>();
            foreach (DataRow item in dt.Rows)
            {
                t_StoreHouse a = new t_StoreHouse();
                a.HouseID = Convert.ToInt32( item["HouseID"]);
                a.HouseName = item["HouseName"].ToString(); 
                list.Add(a);
            }
            return list;
        }
        public static List<t_StoreHouseDetail> getA(int index)
        {
            string sqlstr = string.Format("select * from  t_StoreHouseDetail where HouseID={0}",index);
            DataTable dt = DBHelper.GetDatatable(sqlstr);
            List<t_StoreHouseDetail> list = new List<t_StoreHouseDetail>();
            foreach (DataRow item in dt.Rows)
            {
                t_StoreHouseDetail a = new t_StoreHouseDetail();
                a.HouseID = Convert.ToInt32(item["ID"]);
                a.SubareaName = item["SubareaName"].ToString(); ;
                list.Add(a);
            }
            return list;
        }
        //StockStatusgetStoreName
        public static List<StockStatus> StockStatusgetStoreName(string SubName,string StoreName ,int index ,int count)
        {
            string sql = "";
            sql = string.Format(@"select top {0} h.HouseName,t.SubareaName ,p.ProductsName,p.ProductsID,p.UpperLimit,p.LowerLimit,
p.Cost ,d.Num from t_Products  p , t_ProductsStock d ,t_StoreHouse h ,t_StoreHouseDetail t where
p.ProductsID=d.ProductsID and t.HouseID=h.HouseID and t.ID= d.HouseDetailID and p.ProductsID not
               in(select top {1} P.ProductsID from  t_Products  p , t_ProductsStock d ,t_StoreHouse h ,t_StoreHouseDetail t where
p.ProductsID=d.ProductsID and t.HouseID=h.HouseID and t.ID= d.HouseDetailID order by P.ProductsID) and SubareaName='{2}'  and HouseName='{3}'  order by P.ProductsID
                 ", count, (index - 1) * count, SubName ,StoreName);
            DataTable dt = DBHelper.GetDatatable(sql);
            List<StockStatus> list = new List<StockStatus>();
            foreach (DataRow item in dt.Rows)
            {
                StockStatus e = new StockStatus();
                e.Cost = Convert.ToInt32(item["Cost"]);
                e.downlimit = Convert.ToInt32(item["LowerLimit"]);
                e.HouseName = item["HouseName"].ToString();
                e.SubareaName = item["SubareaName"].ToString();
                e.productID = Convert.ToInt32(item["ProductsID"]);
                e.ProductName = item["ProductsName"].ToString();
                e.num = Convert.ToInt32(item["num"]);
                list.Add(e);
            }
            return list;
        }
    }
}
