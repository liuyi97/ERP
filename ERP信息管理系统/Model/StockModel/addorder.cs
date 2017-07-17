using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.NewFolder1
{
    //添加采购订单类
  public  class addorder
    {
        public string BuyOrderID { get; set; } //订单编号
        public string BuyOrderDate { get; set; }//制单日期
        public string userName { get; set; }//业务代表
        public int StoreHouseID { get; set; }//库房id
        public string HouseName { get; set; }//库房名
        public int HouseDetailID { get; set; }//库区id
        public string SubareaName { get; set; }//库区名
        public string SignDate { get; set; }//签订日期
        public string TradeDate { get; set; }//交货日期
        public string TradeAddress { get ; set; }//地址
        public string TotalPrice { get; set; }//总金额
        public string Delegate { get; set; }//备注
        public int ProductsID { get; set; }//商品id
        public string ProductsName { get; set; }//商品名
        public string Price { get; set; }//价格
        public int Quantity { get; set; }//数量
        public string TaxRate { get; set; }//税率
        public string DiscountRate { get; set; }//折扣率
        public string SupplierID { get; set; }//供应商id
        public string SupplierName { get; set; }//供应商
        public string Description { get; set; }//描述
        public string State { get; set; }//状态
        public string StateName { get; set; }//状态名
        public string ReceiptOrderID { get; set; }//入库单号
        public string ReceiptOrderDate { get; set; }//制单日期
        public string BuyReceiptID { get; set; }//采购单号
        public string CreateDate { get; set; }//制单日期
        public string Ticket{ get; set; }//票号
         public string RealPay { get; set; }//实付金额
        public string AttachPay { get; set; }//附加金额
        public string PayType { get; set; }//支付类型
        public string BuyReturnID { get; set; }//订单编号
        public string BuyReturnDate { get; set; }//订单日期
        public string AlreadyPay { get; set; }//预支付金额
        public string OutID { get; set; }//
        public int DetailID { get; set; }//
        public string SalesOutID { get; set; }
    }
}
