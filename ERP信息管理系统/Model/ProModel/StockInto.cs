using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.InventoryModule
{
    public class StockInto
    {
        //仓库盘点所需字段
        public string InventoryID { get; set; }  //盘点单号
        public string CreatDate { get; set; }    //创建日期
        public int StoreHouseID { get; set; }    //库房
        public int HouseDetailID { get; set; }   //库区
        public int ProductsID { get; set; }      //商品
        public int RealityNum { get; set; }      //实际数量
        public int BillNum { get; set; }         //账面数量
        public int AdjustNum { get; set; }       //调整数量
        public string UserName { get; set; }     //经办人
        public string Description { get; set; }  //备注

        public string TradeDate { get; set; }     ///执行日期
        public string AuditingUser { get; set; } ///我不知道是啥
        public string Operator { get; set; }    ///操作啥啥啥的
        public int State { get; set; }          ///状态
                                            
    }
}
