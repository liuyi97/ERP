using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ProductOut
{
    public class SaveOutMessage
    {
        //出库表保存信息
        public string OutID { get; set; } // 订单编号
        public string CreateDate { get; set; }//订单创建日期
        public int OutType { get; set; }   //出库类型
        public int StoreHouseID { get; set; } //库房
        public int HouseDetailID { get; set; }//库区
        public string UserName { get; set; }  //制单人
        public string TradeDate { get; set; }//入库日期
        public double TotalPrice { get; set; } //总计金额
        public double AlreadyPay { get; set; } //已付款
        public string Description { get; set; }//备注
        public string AuditingUser { get; set; }//不知道是什么
        public int State { get; set; }//状态
        public string HouseStore { get; set; }//库房库区
    }
}
