using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MagMdl
{
   public  class t_BuyReceipt
    {
        public string ReceiptOrderID { get; set; }
        public string ReceiptOrderDate { get; set; }
        public int StoreHouseID { get; set; }
        public int HouseDetailID { get; set; }
        public string BuyOrderID { get; set; }
        public string Identitys { get; set; }
        public string UserName { get; set; }
        public int TradeDate { get; set; }
        public int TotalPrice { get; set; }
        public int AlreadyPay { get; set; }
        public string Description { get; set; }
        public int State { get; set; }
        public string HouseName { get; set; }
        public string StateName { get; set; }
        public string SubareaName { get; set; }
    }
}
