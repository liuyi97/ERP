using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ProductOut
{
    /// <summary>
    /// 保存到数据库的出库信息
    /// </summary>
    public class SaveOutDetail
    {
        public int DetailID { get; set; }
        public string OutID { get; set; }//订单编号
        public int ProductsID { get; set; }//商品ID
        public string ProductsName { get; set; }//商品名
        public int SupplierID { get; set; }//供应商ID
        public string SupplierName { get; set; }//供应商名
        public int Quantity { get; set; }//数量
        public double Price { get; set; }//单价       
        public double Total { get; set; }//总价
        public string Description { get; set; }//描述



        //public string ProductsName { get; set; }//商品名
        //public int SupplierID { get; set; }//供应商ID
        //public string SupplierName { get; set; }//供应商名
        //public double Total { get; set; }//总价
        
    }
}
