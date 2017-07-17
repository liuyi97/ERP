using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models.MagMdl;
namespace DAL.MagDAL
{
   public   class t_ProductsStockService
    {
        public static List<t_ProductsStock> productinfogetid(int id)
        {
            string sql = string.Format(@"select HouseName  ,SubareaName  ,Num  from t_ProductsStock p ,t_StoreHouse s,t_StoreHouseDetail h where p.HouseDetailID=s.HouseID and s.HouseID= h.ID  and p.ProductsID=" + id);
            DataTable dt = DBHelper.GetDatatable(sql);
            List<t_ProductsStock> list = new List<t_ProductsStock>();
            foreach (DataRow item in dt.Rows)
            {
                t_ProductsStock pro = new t_ProductsStock();
                pro.HouseName = item["HouseName"].ToString();
                pro.SubareaName = item["SubareaName"].ToString();
                pro.num= Convert.ToInt32( item["num"].ToString());
                list.Add(pro);
            }
            return list;
        }
        public static int getcount(int id)
        {
            string sql = string.Format(@"select HouseName  ,SubareaName  ,Num  from t_ProductsStock p ,t_StoreHouse s,t_StoreHouseDetail h where p.HouseDetailID=s.HouseID and s.HouseID= h.ID  and p.ProductsID=" + id);
            DataTable dt = DBHelper.GetDatatable(sql);
            return dt.Rows.Count;
        }
        }
}
