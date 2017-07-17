using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
     public  class t_BuyReturn
    {
        public string BuyReturnID { get; set; }
        public string BuyReturnDate { get; set; }
        public int StoreHouseID { get; set; }
        public int HouseDetailID { get; set; }
        public string ReceiptOrderID { get; set; }
        public string Identitys { get; set; }
        public string UserName { get; set; }
        public string TradeDate { get; set; }
        public double TotalPrice { get; set; }
        public string AlreadyPay { get; set; }
        public string Description { get; set; }
        public int State { get; set; }
        public string HouseName { get; set; }
        public string SubareaName { get; set; }
        public string StateName { get; set; }

    }
}
