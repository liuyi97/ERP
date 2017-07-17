using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 订单明细
    /// </summary>
    public class SaveIntoMessage
    {
       public string  AppendID { get; set; } // 订单编号
       public string CreateDate { get; set; }//订单创建日期
       public string UserName { get; set; }  //制单人
       public int StoreHouseID { get; set; } //库房
       public int HouseDetailID { get; set; }//库区
       public double TotalPrice { get; set; } //总计金额
       public int State { get; set; }//状态
       public string TradeDate { get; set; }//入库日期
       public string Description { get;set; }//备注

       public int AppendType { get; set; }//添加信息类型
       public double AlreadyPay { get; set; } //已付款
       public string AuditingUser { get; set; }//不知道是什么
       public string HouseStore { get; set; }//库房库区

    }
}
