using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.NewFolder1;
using System.Data;
namespace DAL.NewFolder1
{
    //商品采购总体信息展示datagrid中
  public  class ProductDetail
    {
        public static List<addorder> GetProductSel(int count,int index)
        {
            string sqlstr = string.Format(@"select top {0}  pr.ProductsID ,ProductsName ,su.SupplierName ,buyo.Quantity ,
buy.TotalPrice ,buyo.DiscountRate ,buyo.TaxRate ,buyo.Price 
from t_BuyOrder buy,t_BuyOrderDetail buyo,t_Products pr,t_Supplier su
where buy.BuyOrderID=buyo.BuyOrderID and buyo.ProductsID=pr.ProductsID
and su.SupplierID=buyo.SupplierID 
and buyo.DetailID not in (select top {1} buyo.DetailID
from t_BuyOrder buy,t_BuyOrderDetail buyo,t_Products pr,t_Supplier su
where buy.BuyOrderID=buyo.BuyOrderID and buyo.ProductsID=pr.ProductsID 
and su.SupplierID=buyo.SupplierID order by buyo.DetailID ) order by buyo.DetailID", count, (index - 1) * count);
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            List<addorder> list = new List<addorder>();
            foreach (DataRow item in dt.Rows)
            {
                addorder ad = new addorder();
                ad.ProductsID =Convert.ToInt32( item["ProductsID"].ToString());
                ad.ProductsName = item["ProductsName"].ToString();
                ad.SupplierName = item["SupplierName"].ToString();
                ad.Quantity = Convert.ToInt32(item["Quantity"].ToString());
                ad.TotalPrice = item["TotalPrice"].ToString();
                ad.DiscountRate =item["DiscountRate"].ToString();
                ad.TaxRate =item["TaxRate"].ToString();
                ad.Price = item["Price"].ToString();
                list.Add(ad);
            }
            return list;
        }
        //总数
        public static int  GetProductSum()
        {
            string sqlstr = string.Format(@"select * from t_BuyOrderDetail");
            DataTable dt = DBHelper.GetDataTable(sqlstr);
            return dt.Rows.Count;
        }
    }
}
