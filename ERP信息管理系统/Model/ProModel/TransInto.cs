using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Transfers
{
  public  class TransInto
    {
      public string  ID { get; set; } //单号
      public string Date { get; set; }//制单日期
      public int OutHouseID { get; set; } //出库ID
      public int InHouseID { get; set; }//入库ID
      public int ProductsID { get; set; }//产品ID
      public int Quantity { get; set; }//数量
      public double Price { get; set; }//价格
      public string UserName { get; set; }//用户名 
      public string TradeDate { get; set; }//制单日期
      public string Description { get; set; }//描述
      public string Ticket { get; set; } //票号

      public string Operator { get; set; }//操作人
      public string AuditingUser { get; set; }//也不知道是啥
      public int State { get; set; }//状态

    }
}
