using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductMessage
    {
        //商品入库
        public int BuyOrderID { get; set; }         //订单编号
        public string BeginEnterDate { get; set; }  //制单日期
        //引用  库房选择
        public int HouseID { get; set; }  //库房编号
        public string HouseName { get; set; }  //库房名称
        //引用  库房下面的库区详情
        public string SubareaName { get; set; } 
       

    }
}
