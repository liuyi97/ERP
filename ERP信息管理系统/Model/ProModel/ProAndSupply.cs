using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class ProAndSupply
    {
        //引用  商品
        public int ProductsID { get; set; } //商品ID
        public string ProductsName { get; set; }  //商品名称
        public int BillNum { get; set; }  //账面数量
        //引用  供应商
        public int SupplierID { get; set; } //编号
        public string SupplierName { get; set; } //供应商名称
        public string Area { get; set; }// 地区
    }
}
